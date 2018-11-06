using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using GTA;
using GTA.Math;
using GTA.Native;

namespace SPGunLocker.Classes
{
    [Serializable]
    public class LockerWeapon
    {
        #region Properties
        [XmlIgnore]
        public WeaponHash Hash { get; set; }

        [XmlElement("Hash")]
        public string HashString
        {
            get
            {
                return Hash.ToString();
            }

            set
            {
                // spaghetti time
                WeaponHash tempHash;
                if (Enum.TryParse(value, out tempHash))
                {
                    Hash = tempHash;
                }
                else
                {
                    int hashValue = -1;
                    if (int.TryParse(value, out hashValue))
                    {
                        Hash = (WeaponHash)hashValue;
                    }
                    else
                    {
                        UI.Notify($"~r~{value} is an invalid weapon.");
                    }
                }
            }
        }

        public int Ammo { get; set; }

        public int Tint { get; set; }
        public List<int> Components { get; set; } = new List<int>();

        [XmlIgnore]
        private Prop _worldProp;
        #endregion

        #region Methods
        public void CreateProp(Prop rackProp, int slot)
        {
            // Load the weapon model
            Methods.RequestWeaponAsset(Hash, 2000);

            // Use the luxury model if the weapon has the luxury component
            int luxeModel = Methods.GetWeaponLuxuryModel(Components);
            if (luxeModel != 0) Methods.RequestModel(luxeModel);

            _worldProp = Function.Call<Prop>(GTA.Native.Hash.CREATE_WEAPON_OBJECT, (int)Hash, -1, rackProp.Position.X, rackProp.Position.Y, rackProp.Position.Z, true, 1.0f, luxeModel, 0, 1);

            // Apply tint
            Function.Call(GTA.Native.Hash.SET_WEAPON_OBJECT_TINT_INDEX, _worldProp.Handle, Tint);

            // Apply components
            foreach (int component in Components)
            {
                int componentModel = Function.Call<int>(GTA.Native.Hash.GET_WEAPON_COMPONENT_TYPE_MODEL, component);
                if (componentModel != 0)
                {
                    Methods.RequestModel(componentModel);

                    Function.Call(GTA.Native.Hash.GIVE_WEAPON_COMPONENT_TO_WEAPON_OBJECT, _worldProp.Handle, component);
                    Function.Call(GTA.Native.Hash.SET_MODEL_AS_NO_LONGER_NEEDED, componentModel);
                }
            }

            // Attach to the gun locker prop
            Tuple<Vector3, Vector3> attachmentOffset = Weapons.GetOffsets(Hash);

            _worldProp.AttachTo(
                rackProp,
                0,
                Constants.AttachmentOffsets[slot].Item1 + attachmentOffset.Item1,
                Constants.AttachmentOffsets[slot].Item2 + attachmentOffset.Item2
            );

            // Free the requested stuff
            if (luxeModel != 0) Function.Call(GTA.Native.Hash.SET_MODEL_AS_NO_LONGER_NEEDED, luxeModel);
            Function.Call(GTA.Native.Hash.REMOVE_WEAPON_ASSET, (int)Hash);
        }

        public void DestroyProp()
        {
            _worldProp?.Delete();
        }
        #endregion
    }
}
