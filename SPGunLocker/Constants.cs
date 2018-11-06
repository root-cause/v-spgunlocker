using System;
using System.Collections.Generic;
using GTA;
using GTA.Math;

namespace SPGunLocker
{
    public static class Constants
    {
        public static readonly string SaveFolder = "gunlockers";
        public static readonly string AddonFolder = "gunlockers_addons";
        public static readonly int MaxWeapons = 10;
        public static readonly float PropDistance = 1f;
        public static readonly int RequiredHoldingTime = 2000;
        public static readonly int HeartbeatInterval = 250;

        public static readonly Tuple<Vector3, Vector3>[] AttachmentOffsets =
        {
            // Small weapons
            Tuple.Create(new Vector3(-0.320000082f, -0.220000058f, 0.390000045f), new Vector3(-90f, 0f, 0f)),
            Tuple.Create(new Vector3(-0.0300000459f, -0.220000058f, 0.390000045f), new Vector3(-90f, 0f, 0f)),

            // Shotguns/rifles/big guns
            Tuple.Create(new Vector3(-0.395999849f, 0.0399998389f, 0.7960006f), new Vector3(0f, -70f, 90f)),
            Tuple.Create(new Vector3(-0.285999954f, 0.0399998389f, 0.7960006f), new Vector3(0f, -70f, 90f)),
            Tuple.Create(new Vector3(-0.174999937f, 0.0399998389f, 0.7960006f), new Vector3(0f, -70f, 90f)),
            Tuple.Create(new Vector3(-0.0549998768f, 0.0399998389f, 0.7960006f), new Vector3(0f, -70f, 90f)),
            Tuple.Create(new Vector3(0.055000145f, 0.0399998389f, 0.7960006f), new Vector3(0f, -70f, 90f)),

            // Throwables
            Tuple.Create(new Vector3(-0.24999997f, 0f, 1.40000021f), Vector3.Zero),
            Tuple.Create(new Vector3(0f, 0f, 1.40000021f), Vector3.Zero),
            Tuple.Create(new Vector3(0.200000018f, 0f, 1.40000021f), Vector3.Zero),
        };

        public static readonly List<int> LuxuryComponents = new List<int>
        {
            Game.GenerateHash("COMPONENT_PISTOL_VARMOD_LUXE"),
            Game.GenerateHash("COMPONENT_COMBATPISTOL_VARMOD_LOWRIDER"),
            Game.GenerateHash("COMPONENT_APPISTOL_VARMOD_LUXE"),
            Game.GenerateHash("COMPONENT_PISTOL50_VARMOD_LUXE"),
            Game.GenerateHash("COMPONENT_SNSPISTOL_VARMOD_LOWRIDER"),
            Game.GenerateHash("COMPONENT_HEAVYPISTOL_VARMOD_LUXE"),
            Game.GenerateHash("COMPONENT_MICROSMG_VARMOD_LUXE"),
            Game.GenerateHash("COMPONENT_SMG_VARMOD_LUXE"),
            Game.GenerateHash("COMPONENT_ASSAULTSMG_VARMOD_LOWRIDER"),
            Game.GenerateHash("COMPONENT_PUMPSHOTGUN_VARMOD_LOWRIDER"),
            Game.GenerateHash("COMPONENT_ASSAULTRIFLE_VARMOD_LUXE"),
            Game.GenerateHash("COMPONENT_CARBINERIFLE_VARMOD_LUXE"),
            Game.GenerateHash("COMPONENT_ADVANCEDRIFLE_VARMOD_LUXE"),
            Game.GenerateHash("COMPONENT_SPECIALCARBINE_VARMOD_LOWRIDER"),
            Game.GenerateHash("COMPONENT_BULLPUPRIFLE_VARMOD_LOW"),
            Game.GenerateHash("COMPONENT_MARKSMANRIFLE_VARMOD_LUXE"),
            Game.GenerateHash("COMPONENT_REVOLVER_VARMOD_BOSS"),
            Game.GenerateHash("COMPONENT_REVOLVER_VARMOD_GOON")
        };
    }
}
