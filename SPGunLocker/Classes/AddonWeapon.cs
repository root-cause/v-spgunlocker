using System.Collections.Generic;
using GTA.Math;

namespace SPGunLocker.Classes
{
    public class AddonWeapon
    {
        public string WeaponName { get; set; }
        public string DisplayName { get; set; }
        public WeaponSlotType SlotType { get; set; }
        public List<string> AvailableComponents { get; set; } = new List<string>();
        public Vector3 AttachmentPositionOffset { get; set; } = Vector3.Zero;
        public Vector3 AttachmentRotationOffset { get; set; } = Vector3.Zero;
    }
}
