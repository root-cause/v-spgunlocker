using System;
using System.IO;
using System.Xml.Serialization;
using GTA;
using GTA.Math;

namespace SPGunLocker.Classes
{
    [Serializable]
    public class Locker
    {
        #region Properties
        public Guid ID { get; set; } = Guid.NewGuid();
        public int RefundValue { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public LockerWeapon[] Weapons { get; set; } = new LockerWeapon[ Constants.MaxWeapons ];

        [XmlIgnore]
        public Prop WorldProp { get; set; }

        [XmlIgnore]
        public string FilePath => Path.Combine("scripts", Constants.SaveFolder, $"{ID}.xml");

        [XmlIgnore]
        public Vector3 InteractionPosition { get; set; }
        #endregion

        #region Methods
        public void CreateProp()
        {
            WorldProp = World.CreateProp("bkr_prop_gunlocker_01a", Position - new Vector3(0f, 0f, 1f), Rotation, false, false);
            for (int i = 0; i < Weapons.Length; i++) Weapons[i]?.CreateProp(WorldProp, i);

            InteractionPosition = WorldProp.GetOffsetInWorldCoords(new Vector3(0f, -0.65f, 0f));
        }

        public void DestroyProp()
        {
            for (int i = 0; i < Weapons.Length; i++) Weapons[i]?.DestroyProp();
            WorldProp?.Delete();
        }

        public void Save()
        {
            File.WriteAllText(Path.Combine("scripts", Constants.SaveFolder, $"{ID}.xml"), this.Serialize());
        }
        #endregion
    }
}
