using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using GTA;
using GTA.Math;
using GTA.Native;
using SPGunLocker.Classes;

namespace SPGunLocker
{
    public static class Methods
    {
        public static void LoadGunLockers()
        {
            try
            {
                string gunLockersPath = Path.Combine("scripts", Constants.SaveFolder);
                if (Directory.Exists(gunLockersPath))
                {
                    string[] files = Directory.GetFiles(gunLockersPath, "*.xml", SearchOption.TopDirectoryOnly);
                    foreach (string file in files)
                    {
                        try
                        {
                            Locker tempLocker = XmlUtil.Deserialize<Locker>(File.ReadAllText(file));
                            tempLocker.CreateProp();

                            Main.GunLockers.Add(tempLocker.ID, tempLocker);
                        }
                        catch (Exception e)
                        {
                            UI.Notify($"~r~SPGunLocker reading error: {e.Message} ({file})");
                        }
                    }
                }
                else
                {
                    Directory.CreateDirectory(gunLockersPath);
                }
            }
            catch (Exception e)
            {
                UI.Notify($"~r~SPGunLocker loading error: {e.Message}");
            }
        }

        public static void LoadAddonWeapons()
        {
            try
            {
                string addonsPath = Path.Combine("scripts", Constants.AddonFolder);
                if (Directory.Exists(addonsPath))
                {
                    string[] files = Directory.GetFiles(addonsPath, "*.xml", SearchOption.TopDirectoryOnly);
                    foreach (string file in files)
                    {
                        try
                        {
                            Addon tempAddon = XmlUtil.Deserialize<Addon>(File.ReadAllText(file));

                            foreach (AddonWeapon weapon in tempAddon.Weapons)
                            {
                                Weapons.Add(
                                    (WeaponHash)Game.GenerateHash(weapon.WeaponName),

                                    new AllowedWeapon(
                                        weapon.DisplayName,
                                        weapon.SlotType,
                                        weapon.AvailableComponents,
                                        Tuple.Create(weapon.AttachmentPositionOffset, weapon.AttachmentRotationOffset)
                                    )
                                );
                            }

                            Constants.LuxuryComponents.AddRange(tempAddon.LuxuryComponents.ConvertAll(c => Game.GenerateHash(c)));
                        }
                        catch (Exception e)
                        {
                            UI.Notify($"~r~SPGunLocker addon reading error: {e.Message} ({file})");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                UI.Notify($"~r~SPGunLocker addon loading error: {e.Message}");
            }
        }

        public static Guid? FindInteractableGunLocker(Vector3 position)
        {
            foreach (Locker locker in Main.GunLockers.Values)
            {
                if (locker.InteractionPosition.DistanceTo(position) <= 1.1f)
                {
                    return locker.ID;
                }
            }

            return null;
        }

        public static void DisplayHelpText(string message)
        {
            Function.Call(Hash._SET_TEXT_COMPONENT_FORMAT, "CELL_EMAIL_BCON");
            Function.Call(Hash._ADD_TEXT_COMPONENT_STRING, message);
            Function.Call(Hash._0x238FFE5C7B0498A6, 0, 0, 1, -1);
        }

        public static void DrawText(string text, int font, float scale, Color color, float drawX, float drawY)
        {
            Function.Call(Hash.SET_TEXT_FONT, font);
            Function.Call(Hash.SET_TEXT_SCALE, scale, scale);
            Function.Call(Hash.SET_TEXT_COLOUR, color.R, color.G, color.B, color.A);
            Function.Call(Hash.SET_TEXT_OUTLINE);

            Function.Call(Hash._SET_TEXT_ENTRY, "STRING");
            Function.Call(Hash._ADD_TEXT_COMPONENT_STRING, text);
            Function.Call(Hash._DRAW_TEXT, drawX, drawY);
        }

        public static WeaponSlotType GetSlotWeaponType(int slot)
        {
            switch (slot)
            {
                case 0:
                case 1:
                    return WeaponSlotType.Small;

                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    return WeaponSlotType.Big;

                case 7:
                case 8:
                case 9:
                    return WeaponSlotType.Throwable;

                default:
                    return WeaponSlotType.None;
            }
        }

        public static List<int> GetWeaponComponents(WeaponHash weapon)
        {
            int localPlayer = Game.Player.Character.Handle;
            return Weapons.GetComponents(weapon).Where(c => Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, localPlayer, (int)weapon, c)).ToList();
        }

        public static int GetWeaponLuxuryModel(List<int> weaponComponents)
        {
            foreach (int component in Constants.LuxuryComponents)
            {
                if (weaponComponents.Contains(component))
                {
                    return Function.Call<int>(Hash.GET_WEAPON_COMPONENT_TYPE_MODEL, component);
                }
            }

            return 0;
        }

        public static void RequestWeaponAsset(WeaponHash weapon, int timeoutMs = 1000)
        {
            int end = Game.GameTime + timeoutMs;

            Function.Call(Hash.REQUEST_WEAPON_ASSET, (int)weapon, 31, 0);
            while (!Function.Call<bool>(Hash.HAS_WEAPON_ASSET_LOADED, (int)weapon) && Game.GameTime < end) Script.Yield();
        }

        public static void RequestModel(int model, int timeoutMs = 1000)
        {
            int end = Game.GameTime + timeoutMs;

            Function.Call(Hash.REQUEST_MODEL, model);
            while (!Function.Call<bool>(Hash.HAS_MODEL_LOADED, model) && Game.GameTime < end) Script.Yield();
        }
    }
}
