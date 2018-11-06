using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using GTA;
using GTA.Native;
using NativeUI;
using SPGunLocker.Classes;

namespace SPGunLocker
{
    public class Main : Script
    {
        #region Script Variables
        public static Dictionary<Guid, Locker> GunLockers = new Dictionary<Guid, Locker>();
        public bool GunLockersLoaded = false;

        int LastHeartbeat = 0;
        int HoldingTime = 0;
        Guid? InteractableLockerGuid = null;
        InteractionType MenuInteractionType = InteractionType.Put;

        MenuPool SPGLMenuPool = null;
        UIMenu SPGLMainMenu = null;
        UIMenu SPGLWeaponsMenu = null;
        #endregion

        #region Config Variables
        int GunLockerPrice = 2500;
        int InteractionControl = 51;
        #endregion

        public Main()
        {
            // Load settings
            try
            {
                string configFile = Path.Combine("scripts", "spgunlocker_config.ini");
                ScriptSettings config = ScriptSettings.Load(configFile);

                if (File.Exists(configFile))
                {
                    InteractionControl = config.GetValue("CONFIG", "InteractionControl", 51);
                    GunLockerPrice = config.GetValue("CONFIG", "GunLockerPrice", 2500);
                }
                else
                {
                    config.SetValue("CONFIG", "InteractionControl", InteractionControl);
                    config.SetValue("CONFIG", "GunLockerPrice", GunLockerPrice);
                }

                config.Save();
            }
            catch (Exception e)
            {
                UI.Notify($"~r~SPGunLocker settings error: {e.Message}");
            }

            // Create menus
            SPGLMenuPool = new MenuPool();

            SPGLMainMenu = new UIMenu("", "~b~GUN LOCKER", Point.Empty, "shopui_title_gr_gunmod", "shopui_title_gr_gunmod");
            SPGLWeaponsMenu = new UIMenu("", "~b~GUN LOCKER: ~w~WEAPONS", Point.Empty, "shopui_title_gr_gunmod", "shopui_title_gr_gunmod");

            UIMenuItem putLinkItem = new UIMenuItem("Put", "Put a weapon to the gun locker.");
            UIMenuItem takeLinkItem = new UIMenuItem("Take", "Take a weapon from the gun locker.");
            SPGLMainMenu.AddItem(putLinkItem);
            SPGLMainMenu.AddItem(takeLinkItem);
            SPGLMainMenu.AddItem(new UIMenuItem("Refund", "Return the gun locker and get your money back."));

            SPGLMainMenu.BindMenuToItem(SPGLWeaponsMenu, putLinkItem);
            SPGLMainMenu.BindMenuToItem(SPGLWeaponsMenu, takeLinkItem);

            SPGLMenuPool.Add(SPGLMainMenu);
            SPGLMenuPool.Add(SPGLWeaponsMenu);

            // Event handlers
            Tick += Script_Tick;
            Aborted += Script_Aborted;
            SPGLMainMenu.OnItemSelect += MainMenu_OnItemSelect;
            SPGLWeaponsMenu.OnItemSelect += WeaponsMenu_OnItemSelect;
        }

        #region Event: Tick
        public void Script_Tick(object sender, EventArgs e)
        {
            // Workaround for gun locker props not being created on mod init
            if (!GunLockersLoaded && !Game.IsLoading && Game.Player.CanControlCharacter)
            {
                GunLockersLoaded = true;
                Methods.LoadAddonWeapons();
                Methods.LoadGunLockers();
            }

            // Process script menus
            SPGLMenuPool.ProcessMenus();

            int gameTime = Game.GameTime;
            if (gameTime - LastHeartbeat >= Constants.HeartbeatInterval)
            {
                // Find the closest gun locker
                InteractableLockerGuid = Game.Player.Character.IsOnFoot ? Methods.FindInteractableGunLocker(Game.Player.Character.Position) : null;

                // Hide the menus if the player can't interact with a gun locker
                if (InteractableLockerGuid == null && SPGLMenuPool.IsAnyMenuOpen()) SPGLMenuPool.CloseAllMenus();

                LastHeartbeat = gameTime;
            }

            // Draw a helptext if the player can interact with a gun locker
            if (InteractableLockerGuid != null && !SPGLMenuPool.IsAnyMenuOpen())
            {
                Methods.DisplayHelpText($"Press {HelpTextKeys.Get(InteractionControl)} to interact with the Gun Locker.");
            }

            // Handle script controls
            if (Game.IsControlJustPressed(2, (Control)InteractionControl))
            {
                if (InteractableLockerGuid != null && GunLockers.ContainsKey(InteractableLockerGuid.Value))
                {
                    if (SPGLMenuPool.IsAnyMenuOpen())
                    {
                        SPGLMenuPool.CloseAllMenus();
                    }
                    else
                    {
                        SPGLMainMenu.RefreshIndex();
                        SPGLMainMenu.Visible = true;

                        // Update the weapons menu
                        SPGLWeaponsMenu.Clear();

                        for (int i = 0; i < Constants.MaxWeapons; i++)
                        {
                            string title = $"Empty Slot ({Methods.GetSlotWeaponType(i)})";

                            if (GunLockers[ InteractableLockerGuid.Value ].Weapons[i] != null)
                            {
                                title = Weapons.GetDisplayName(GunLockers[ InteractableLockerGuid.Value ].Weapons[i].Hash);
                            }

                            SPGLWeaponsMenu.AddItem(new UIMenuItem(title));
                        }
                    }
                }
                else
                {
                    if (Game.Player.Character.IsOnFoot) HoldingTime = gameTime;
                }
            }

            if (Game.IsControlJustReleased(2, (Control)InteractionControl)) HoldingTime = 0;

            // Handle holding the interaction key to spawn a gun locker
            if (HoldingTime > 0)
            {
                int diff = gameTime - HoldingTime;
                if (diff >= 500 && InteractableLockerGuid == null)
                {
                    Methods.DrawText($"Buying a Gun Locker: ~b~{(diff * 100) / Constants.RequiredHoldingTime}% ~g~(${GunLockerPrice})", 0, 0.45f, Color.White, 0.05f, 0.05f);

                    if (diff >= Constants.RequiredHoldingTime)
                    {
                        HoldingTime = 0;

                        if (Game.Player.Money >= GunLockerPrice)
                        {
                            Game.Player.Money -= GunLockerPrice;

                            Locker newLocker = new Locker
                            {
                                RefundValue = GunLockerPrice,
                                Position = Game.Player.Character.Position + Game.Player.Character.ForwardVector * Constants.PropDistance,
                                Rotation = Game.Player.Character.Rotation
                            };

                            newLocker.CreateProp();
                            newLocker.Save();

                            GunLockers.Add(newLocker.ID, newLocker);
                        }
                        else
                        {
                            UI.Notify("~r~You can't afford a gun locker.");
                        }
                    }
                }
            }
        }
        #endregion

        #region Event: Aborted
        public void Script_Aborted(object sender, EventArgs e)
        {
            // Destroy the gun locker entities
            foreach (Locker locker in GunLockers.Values) locker.DestroyProp();
            GunLockers.Clear();

            SPGLMenuPool = null;
            SPGLMainMenu = null;
            SPGLWeaponsMenu = null;
        }
        #endregion

        #region Event: MainMenu_OnItemSelect
        public void MainMenu_OnItemSelect(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            switch (index)
            {
                // Put a weapon
                case 0:
                {
                    MenuInteractionType = InteractionType.Put;
                    SPGLWeaponsMenu.RefreshIndex();
                    break;
                }

                // Take a weapon
                case 1:
                {
                    MenuInteractionType = InteractionType.Take;
                    SPGLWeaponsMenu.RefreshIndex();
                    break;
                }

                // Refund
                case 2:
                {
                    if (InteractableLockerGuid == null || !GunLockers.ContainsKey(InteractableLockerGuid.Value)) return;
                    Locker locker = GunLockers[ InteractableLockerGuid.Value ];

                    if (locker.Weapons.Count(w => w != null) > 0)
                    {
                        UI.Notify("~r~Take out the stored weapons first.");
                        return;
                    }

                    Game.Player.Money += locker.RefundValue;
                    UI.Notify($"Returned the gun locker for ~g~${locker.RefundValue}.");

                    SPGLMenuPool.CloseAllMenus();
                    locker.DestroyProp();
                    GunLockers.Remove(InteractableLockerGuid.Value);
                    File.Delete(locker.FilePath);

                    InteractableLockerGuid = null;
                    break;
                }
            }
        }
        #endregion

        #region Event: WeaponsMenu_OnItemSelect
        public void WeaponsMenu_OnItemSelect(UIMenu menu, UIMenuItem selectedItem, int index)
        {
            if (InteractableLockerGuid == null || !GunLockers.ContainsKey(InteractableLockerGuid.Value)) return;
            if (index < 0 || index >= Constants.MaxWeapons) return;
            Locker locker = GunLockers[ InteractableLockerGuid.Value ];

            switch (MenuInteractionType)
            {
                case InteractionType.Put:
                {
                    if (locker.Weapons[index] != null)
                    {
                        UI.Notify("~r~Selected slot is occupied.");
                        return;
                    }

                    Weapon currentWeapon = Game.Player.Character.Weapons.Current;
                    if (!Weapons.IsAllowed(currentWeapon.Hash))
                    {
                        UI.Notify("~r~You can't store this weapon.");
                        return;
                    }

                    if (Methods.GetSlotWeaponType(index) != Weapons.GetSlotType(currentWeapon.Hash))
                    {
                        UI.Notify("~r~You can't store this weapon on the selected slot.");
                        return;
                    }

                    locker.Weapons[index] = new LockerWeapon
                    {
                        Hash = currentWeapon.Hash,
                        Ammo = currentWeapon.Ammo,
                        Tint = (int)currentWeapon.Tint,
                        Components = Methods.GetWeaponComponents(currentWeapon.Hash)
                    };

                    locker.Weapons[index].CreateProp(locker.WorldProp, index);
                    locker.Save();

                    selectedItem.Text = Weapons.GetDisplayName(currentWeapon.Hash);
                    selectedItem.Description = string.Empty;

                    Game.Player.Character.Weapons.Remove(currentWeapon);
                    break;
                }

                case InteractionType.Take:
                {
                    if (locker.Weapons[index] == null)
                    {
                        UI.Notify("~r~Selected slot is empty.");
                        return;
                    }

                    LockerWeapon lockerWeapon = locker.Weapons[index];

                    Game.Player.Character.Weapons.Give(
                        lockerWeapon.Hash,
                        lockerWeapon.Ammo,
                        true,
                        true
                    );

                    Game.Player.Character.Weapons[ lockerWeapon.Hash ].Tint = (WeaponTint)lockerWeapon.Tint;

                    foreach (WeaponComponent component in lockerWeapon.Components)
                    {
                        Game.Player.Character.Weapons[ lockerWeapon.Hash ].SetComponent(component, true);
                    }

                    lockerWeapon.DestroyProp();
                    locker.Weapons[index] = null;
                    locker.Save();

                    selectedItem.Text = $"Empty Slot ({Methods.GetSlotWeaponType(index)})";
                    break;
                }
            }
        }
        #endregion
    }
}
