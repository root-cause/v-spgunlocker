using System;
using System.Collections.Generic;
using GTA;
using GTA.Math;

namespace SPGunLocker.Classes
{
    public class AllowedWeapon
    {
        public string DisplayName { get; set; }
        public WeaponSlotType SlotType { get; set; }
        public List<int> AvailableComponents { get; set; } = new List<int>();
        public Tuple<Vector3, Vector3> AttachmentExtra { get; set; } = Tuple.Create(Vector3.Zero, Vector3.Zero);

        public AllowedWeapon(string displayName, WeaponSlotType slotType)
        {
            DisplayName = displayName;
            SlotType = slotType;
        }

        public AllowedWeapon(string displayName, WeaponSlotType slotType, List<string> availableComponents) : this(displayName, slotType)
        {
            AvailableComponents = availableComponents.ConvertAll(c => Game.GenerateHash(c));
        }

        public AllowedWeapon(string displayName, WeaponSlotType slotType, Tuple<Vector3, Vector3> attachmentExtra) : this(displayName, slotType)
        {
            AttachmentExtra = attachmentExtra;
        }

        public AllowedWeapon(string displayName, WeaponSlotType slotType, List<string> availableComponents, Tuple<Vector3, Vector3> attachmentExtra) : this(displayName, slotType, availableComponents)
        {
            AttachmentExtra = attachmentExtra;
        }
    }
}
