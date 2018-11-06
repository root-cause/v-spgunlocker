using System.Collections.Generic;

namespace SPGunLocker.Classes
{
    public class Addon
    {
        public List<AddonWeapon> Weapons { get; set; } = new List<AddonWeapon>();
        public List<string> LuxuryComponents { get; set; } = new List<string>();
    }
}
