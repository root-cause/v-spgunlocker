using System;
using System.Collections.Generic;
using GTA;
using GTA.Math;
using GTA.Native;
using SPGunLocker.Classes;

namespace SPGunLocker
{
    public static class Constants
    {
        public static readonly string SaveFolder = "gunlockers";
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

        public static readonly int[] LuxuryComponents =
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

        #region Big Mistake
        public static readonly Dictionary<WeaponHash, AllowedWeapon> AllowedWeapons = new Dictionary<WeaponHash, AllowedWeapon>
        {
            // Pistols
            { WeaponHash.Pistol, new AllowedWeapon("Pistol", WeaponSlotType.Small, new List<string> {
                "COMPONENT_PISTOL_CLIP_01",
                "COMPONENT_PISTOL_CLIP_02",
                "COMPONENT_AT_PI_FLSH",
                "COMPONENT_AT_PI_SUPP_02",
                "COMPONENT_PISTOL_VARMOD_LUXE"
            }) },

            { WeaponHash.PistolMk2, new AllowedWeapon("Pistol Mk II", WeaponSlotType.Small, new List<string> {
                "COMPONENT_PISTOL_MK2_CLIP_01",
                "COMPONENT_PISTOL_MK2_CLIP_02",
                "COMPONENT_PISTOL_MK2_CLIP_TRACER",
                "COMPONENT_PISTOL_MK2_CLIP_INCENDIARY",
                "COMPONENT_PISTOL_MK2_CLIP_HOLLOWPOINT",
                "COMPONENT_PISTOL_MK2_CLIP_FMJ",
                "COMPONENT_AT_PI_RAIL",
                "COMPONENT_AT_PI_FLSH_02",
                "COMPONENT_AT_PI_SUPP_02",
                "COMPONENT_AT_PI_COMP",
                "COMPONENT_PISTOL_MK2_CAMO",
                "COMPONENT_PISTOL_MK2_CAMO_02",
                "COMPONENT_PISTOL_MK2_CAMO_03",
                "COMPONENT_PISTOL_MK2_CAMO_04",
                "COMPONENT_PISTOL_MK2_CAMO_05",
                "COMPONENT_PISTOL_MK2_CAMO_06",
                "COMPONENT_PISTOL_MK2_CAMO_07",
                "COMPONENT_PISTOL_MK2_CAMO_08",
                "COMPONENT_PISTOL_MK2_CAMO_09",
                "COMPONENT_PISTOL_MK2_CAMO_10",
                "COMPONENT_PISTOL_MK2_CAMO_IND_01",
                "COMPONENT_PISTOL_MK2_CAMO_SLIDE",
                "COMPONENT_PISTOL_MK2_CAMO_02_SLIDE",
                "COMPONENT_PISTOL_MK2_CAMO_03_SLIDE",
                "COMPONENT_PISTOL_MK2_CAMO_04_SLIDE",
                "COMPONENT_PISTOL_MK2_CAMO_05_SLIDE",
                "COMPONENT_PISTOL_MK2_CAMO_06_SLIDE",
                "COMPONENT_PISTOL_MK2_CAMO_07_SLIDE",
                "COMPONENT_PISTOL_MK2_CAMO_08_SLIDE",
                "COMPONENT_PISTOL_MK2_CAMO_09_SLIDE",
                "COMPONENT_PISTOL_MK2_CAMO_10_SLIDE",
                "COMPONENT_PISTOL_MK2_CAMO_IND_01_SLIDE"
            }) },

            { WeaponHash.CombatPistol, new AllowedWeapon("Combat Pistol", WeaponSlotType.Small, new List<string> {
                "COMPONENT_COMBATPISTOL_CLIP_01",
                "COMPONENT_COMBATPISTOL_CLIP_02",
                "COMPONENT_AT_PI_FLSH",
                "COMPONENT_AT_PI_SUPP",
                "COMPONENT_COMBATPISTOL_VARMOD_LOWRIDER"
            }) },

            { WeaponHash.APPistol, new AllowedWeapon("AP Pistol", WeaponSlotType.Small, new List<string> {
                "COMPONENT_APPISTOL_CLIP_01",
                "COMPONENT_APPISTOL_CLIP_02",
                "COMPONENT_AT_PI_FLSH",
                "COMPONENT_AT_PI_SUPP",
                "COMPONENT_APPISTOL_VARMOD_LUXE"
            }) },

            { WeaponHash.StunGun, new AllowedWeapon("Stun Gun", WeaponSlotType.Small) },

            { WeaponHash.Pistol50, new AllowedWeapon("Pistol .50", WeaponSlotType.Small, new List<string> {
                "COMPONENT_PISTOL50_CLIP_01",
                "COMPONENT_PISTOL50_CLIP_02",
                "COMPONENT_AT_PI_FLSH",
                "COMPONENT_AT_AR_SUPP_02",
                "COMPONENT_PISTOL50_VARMOD_LUXE"
            }) },

            { WeaponHash.SNSPistol, new AllowedWeapon("SNS Pistol", WeaponSlotType.Small, new List<string> {
                "COMPONENT_SNSPISTOL_CLIP_01",
                "COMPONENT_SNSPISTOL_CLIP_02",
                "COMPONENT_SNSPISTOL_VARMOD_LOWRIDER"
            }) },

            { WeaponHash.SNSPistolMk2, new AllowedWeapon("SNS Pistol Mk II", WeaponSlotType.Small, new List<string> {
                "COMPONENT_SNSPISTOL_MK2_CLIP_01",
                "COMPONENT_SNSPISTOL_MK2_CLIP_02",
                "COMPONENT_SNSPISTOL_MK2_CLIP_TRACER",
                "COMPONENT_SNSPISTOL_MK2_CLIP_INCENDIARY",
                "COMPONENT_SNSPISTOL_MK2_CLIP_HOLLOWPOINT",
                "COMPONENT_SNSPISTOL_MK2_CLIP_FMJ",
                "COMPONENT_AT_PI_FLSH_03",
                "COMPONENT_AT_PI_RAIL_02",
                "COMPONENT_AT_PI_SUPP_02",
                "COMPONENT_AT_PI_COMP_02",
                "COMPONENT_SNSPISTOL_MK2_CAMO",
                "COMPONENT_SNSPISTOL_MK2_CAMO_02",
                "COMPONENT_SNSPISTOL_MK2_CAMO_03",
                "COMPONENT_SNSPISTOL_MK2_CAMO_04",
                "COMPONENT_SNSPISTOL_MK2_CAMO_05",
                "COMPONENT_SNSPISTOL_MK2_CAMO_06",
                "COMPONENT_SNSPISTOL_MK2_CAMO_07",
                "COMPONENT_SNSPISTOL_MK2_CAMO_08",
                "COMPONENT_SNSPISTOL_MK2_CAMO_09",
                "COMPONENT_SNSPISTOL_MK2_CAMO_10",
                "COMPONENT_SNSPISTOL_MK2_CAMO_IND_01",
                "COMPONENT_SNSPISTOL_MK2_CAMO_SLIDE",
                "COMPONENT_SNSPISTOL_MK2_CAMO_02_SLIDE",
                "COMPONENT_SNSPISTOL_MK2_CAMO_03_SLIDE",
                "COMPONENT_SNSPISTOL_MK2_CAMO_04_SLIDE",
                "COMPONENT_SNSPISTOL_MK2_CAMO_05_SLIDE",
                "COMPONENT_SNSPISTOL_MK2_CAMO_06_SLIDE",
                "COMPONENT_SNSPISTOL_MK2_CAMO_07_SLIDE",
                "COMPONENT_SNSPISTOL_MK2_CAMO_08_SLIDE",
                "COMPONENT_SNSPISTOL_MK2_CAMO_09_SLIDE",
                "COMPONENT_SNSPISTOL_MK2_CAMO_10_SLIDE",
                "COMPONENT_SNSPISTOL_MK2_CAMO_IND_01_SLIDE"
            }) },

            { WeaponHash.HeavyPistol, new AllowedWeapon("Heavy Pistol", WeaponSlotType.Small, new List<string> {
                "COMPONENT_HEAVYPISTOL_CLIP_01",
                "COMPONENT_HEAVYPISTOL_CLIP_02",
                "COMPONENT_AT_PI_FLSH",
                "COMPONENT_AT_PI_SUPP",
                "COMPONENT_HEAVYPISTOL_VARMOD_LUXE"
            }) },

            { WeaponHash.VintagePistol, new AllowedWeapon("Vintage Pistol", WeaponSlotType.Small, new List<string> {
                "COMPONENT_VINTAGEPISTOL_CLIP_01",
                "COMPONENT_VINTAGEPISTOL_CLIP_02",
                "COMPONENT_AT_PI_SUPP"
            }) },

            { WeaponHash.FlareGun, new AllowedWeapon("Flare Gun", WeaponSlotType.Small) },

            { WeaponHash.Revolver, new AllowedWeapon("Heavy Revolver", WeaponSlotType.Small, new List<string> {
                "COMPONENT_REVOLVER_CLIP_01",
                "COMPONENT_REVOLVER_VARMOD_BOSS",
                "COMPONENT_REVOLVER_VARMOD_GOON"
            }) },

            { WeaponHash.RevolverMk2, new AllowedWeapon("Heavy Revolver Mk II", WeaponSlotType.Small, new List<string> {
                "COMPONENT_REVOLVER_MK2_CLIP_01",
                "COMPONENT_REVOLVER_MK2_CLIP_TRACER",
                "COMPONENT_REVOLVER_MK2_CLIP_INCENDIARY",
                "COMPONENT_REVOLVER_MK2_CLIP_HOLLOWPOINT",
                "COMPONENT_REVOLVER_MK2_CLIP_FMJ",
                "COMPONENT_AT_SIGHTS",
                "COMPONENT_AT_SCOPE_MACRO_MK2",
                "COMPONENT_AT_PI_FLSH",
                "COMPONENT_AT_PI_COMP_03",
                "COMPONENT_REVOLVER_MK2_CAMO",
                "COMPONENT_REVOLVER_MK2_CAMO_02",
                "COMPONENT_REVOLVER_MK2_CAMO_03",
                "COMPONENT_REVOLVER_MK2_CAMO_04",
                "COMPONENT_REVOLVER_MK2_CAMO_05",
                "COMPONENT_REVOLVER_MK2_CAMO_06",
                "COMPONENT_REVOLVER_MK2_CAMO_07",
                "COMPONENT_REVOLVER_MK2_CAMO_08",
                "COMPONENT_REVOLVER_MK2_CAMO_09",
                "COMPONENT_REVOLVER_MK2_CAMO_10",
                "COMPONENT_REVOLVER_MK2_CAMO_IND_01"
            }) },

            { WeaponHash.DoubleActionRevolver, new AllowedWeapon("Double-Action Revolver", WeaponSlotType.Small) },

            // SMGs
            { WeaponHash.MicroSMG, new AllowedWeapon("Micro SMG", WeaponSlotType.Small, new List<string> {
                "COMPONENT_MICROSMG_CLIP_01",
                "COMPONENT_MICROSMG_CLIP_02",
                "COMPONENT_AT_PI_FLSH",
                "COMPONENT_AT_SCOPE_MACRO",
                "COMPONENT_AT_AR_SUPP_02",
                "COMPONENT_MICROSMG_VARMOD_LUXE"
            }) },

            { WeaponHash.SMG, new AllowedWeapon("SMG", WeaponSlotType.Big, new List<string> {
                "COMPONENT_SMG_CLIP_01",
                "COMPONENT_SMG_CLIP_02",
                "COMPONENT_SMG_CLIP_03",
                "COMPONENT_AT_AR_FLSH",
                "COMPONENT_AT_SCOPE_MACRO_02",
                "COMPONENT_AT_PI_SUPP",
                "COMPONENT_SMG_VARMOD_LUXE"
            }) },

            { WeaponHash.SMGMk2, new AllowedWeapon("SMG Mk II", WeaponSlotType.Small, new List<string> {
                "COMPONENT_SMG_MK2_CLIP_01",
                "COMPONENT_SMG_MK2_CLIP_02",
                "COMPONENT_SMG_MK2_CLIP_TRACER",
                "COMPONENT_SMG_MK2_CLIP_INCENDIARY",
                "COMPONENT_SMG_MK2_CLIP_HOLLOWPOINT",
                "COMPONENT_SMG_MK2_CLIP_FMJ",
                "COMPONENT_AT_AR_FLSH",
                "COMPONENT_AT_SIGHTS_SMG",
                "COMPONENT_AT_SCOPE_MACRO_02_SMG_MK2",
                "COMPONENT_AT_SCOPE_SMALL_SMG_MK2",
                "COMPONENT_AT_PI_SUPP",
                "COMPONENT_AT_MUZZLE_01",
                "COMPONENT_AT_MUZZLE_02",
                "COMPONENT_AT_MUZZLE_03",
                "COMPONENT_AT_MUZZLE_04",
                "COMPONENT_AT_MUZZLE_05",
                "COMPONENT_AT_MUZZLE_06",
                "COMPONENT_AT_MUZZLE_07",
                "COMPONENT_AT_SB_BARREL_01",
                "COMPONENT_AT_SB_BARREL_02",
                "COMPONENT_SMG_MK2_CAMO",
                "COMPONENT_SMG_MK2_CAMO_02",
                "COMPONENT_SMG_MK2_CAMO_03",
                "COMPONENT_SMG_MK2_CAMO_04",
                "COMPONENT_SMG_MK2_CAMO_05",
                "COMPONENT_SMG_MK2_CAMO_06",
                "COMPONENT_SMG_MK2_CAMO_07",
                "COMPONENT_SMG_MK2_CAMO_08",
                "COMPONENT_SMG_MK2_CAMO_09",
                "COMPONENT_SMG_MK2_CAMO_10",
                "COMPONENT_SMG_MK2_CAMO_IND_01"
            }) },

            { WeaponHash.AssaultSMG, new AllowedWeapon("Assault SMG", WeaponSlotType.Big, new List<string> {
                "COMPONENT_ASSAULTSMG_CLIP_01",
                "COMPONENT_ASSAULTSMG_CLIP_02",
                "COMPONENT_AT_AR_FLSH",
                "COMPONENT_AT_SCOPE_MACRO",
                "COMPONENT_AT_AR_SUPP_02",
                "COMPONENT_ASSAULTSMG_VARMOD_LOWRIDER"
            }, Tuple.Create(new Vector3(0f, 0f, 0.15f), Vector3.Zero)) },

            { WeaponHash.CombatPDW, new AllowedWeapon("Combat PDW", WeaponSlotType.Big, new List<string> {
                "COMPONENT_COMBATPDW_CLIP_01",
                "COMPONENT_COMBATPDW_CLIP_02",
                "COMPONENT_COMBATPDW_CLIP_03",
                "COMPONENT_AT_AR_FLSH",
                "COMPONENT_AT_AR_AFGRIP",
                "COMPONENT_AT_SCOPE_SMALL"
            }) },

            { WeaponHash.MachinePistol, new AllowedWeapon("Machine Pistol", WeaponSlotType.Small, new List<string> {
                "COMPONENT_MACHINEPISTOL_CLIP_01",
                "COMPONENT_MACHINEPISTOL_CLIP_02",
                "COMPONENT_MACHINEPISTOL_CLIP_03",
                "COMPONENT_AT_PI_SUPP"
            }) },

            { WeaponHash.MiniSMG, new AllowedWeapon("Mini SMG", WeaponSlotType.Small, new List<string> {
                "COMPONENT_MINISMG_CLIP_01",
                "COMPONENT_MINISMG_CLIP_02"
            }) },

            // Shotguns
            { WeaponHash.PumpShotgun, new AllowedWeapon("Pump Shotgun", WeaponSlotType.Big, new List<string> {
                "COMPONENT_AT_AR_FLSH",
                "COMPONENT_AT_SR_SUPP",
                "COMPONENT_PUMPSHOTGUN_VARMOD_LOWRIDER"
            }) },

            { WeaponHash.PumpShotgunMk2, new AllowedWeapon("Pump Shotgun Mk II", WeaponSlotType.Big, new List<string> {
                "COMPONENT_PUMPSHOTGUN_MK2_CLIP_01",
                "COMPONENT_PUMPSHOTGUN_MK2_CLIP_INCENDIARY",
                "COMPONENT_PUMPSHOTGUN_MK2_CLIP_ARMORPIERCING",
                "COMPONENT_PUMPSHOTGUN_MK2_CLIP_HOLLOWPOINT",
                "COMPONENT_PUMPSHOTGUN_MK2_CLIP_EXPLOSIVE",
                "COMPONENT_AT_SIGHTS",
                "COMPONENT_AT_SCOPE_MACRO_MK2",
                "COMPONENT_AT_SCOPE_SMALL_MK2",
                "COMPONENT_AT_AR_FLSH",
                "COMPONENT_AT_SR_SUPP_03",
                "COMPONENT_AT_MUZZLE_08",
                "COMPONENT_PUMPSHOTGUN_MK2_CAMO",
                "COMPONENT_PUMPSHOTGUN_MK2_CAMO_02",
                "COMPONENT_PUMPSHOTGUN_MK2_CAMO_03",
                "COMPONENT_PUMPSHOTGUN_MK2_CAMO_04",
                "COMPONENT_PUMPSHOTGUN_MK2_CAMO_05",
                "COMPONENT_PUMPSHOTGUN_MK2_CAMO_06",
                "COMPONENT_PUMPSHOTGUN_MK2_CAMO_07",
                "COMPONENT_PUMPSHOTGUN_MK2_CAMO_08",
                "COMPONENT_PUMPSHOTGUN_MK2_CAMO_09",
                "COMPONENT_PUMPSHOTGUN_MK2_CAMO_10",
                "COMPONENT_PUMPSHOTGUN_MK2_CAMO_IND_01"
            }) },

            { WeaponHash.AssaultShotgun, new AllowedWeapon("Assault Shotgun", WeaponSlotType.Big, new List<string> {
                "COMPONENT_ASSAULTSHOTGUN_CLIP_01",
                "COMPONENT_ASSAULTSHOTGUN_CLIP_02",
                "COMPONENT_AT_AR_FLSH",
                "COMPONENT_AT_AR_SUPP",
                "COMPONENT_AT_AR_AFGRIP"
            }, Tuple.Create(new Vector3(0f, 0f, -0.07f), Vector3.Zero)) },

            { WeaponHash.BullpupShotgun, new AllowedWeapon("Bullpup Shotgun", WeaponSlotType.Big, new List<string> {
                "COMPONENT_AT_AR_FLSH",
                "COMPONENT_AT_AR_SUPP_02",
                "COMPONENT_AT_AR_AFGRIP"
            }) },

            { WeaponHash.HeavyShotgun, new AllowedWeapon("Heavy Shotgun", WeaponSlotType.Big, new List<string> {
                "COMPONENT_HEAVYSHOTGUN_CLIP_01",
                "COMPONENT_HEAVYSHOTGUN_CLIP_02",
                "COMPONENT_HEAVYSHOTGUN_CLIP_03",
                "COMPONENT_AT_AR_FLSH",
                "COMPONENT_AT_AR_SUPP_02",
                "COMPONENT_AT_AR_AFGRIP"
            }) },

            { WeaponHash.SweeperShotgun, new AllowedWeapon("Sweeper Shotgun", WeaponSlotType.Small) },

            // Rifles
            { WeaponHash.AssaultRifle, new AllowedWeapon("Assault Rifle", WeaponSlotType.Big, new List<string> {
                "COMPONENT_ASSAULTRIFLE_CLIP_01",
                "COMPONENT_ASSAULTRIFLE_CLIP_02",
                "COMPONENT_ASSAULTRIFLE_CLIP_03",
                "COMPONENT_AT_AR_FLSH",
                "COMPONENT_AT_SCOPE_MACRO",
                "COMPONENT_AT_AR_SUPP_02",
                "COMPONENT_AT_AR_AFGRIP",
                "COMPONENT_ASSAULTRIFLE_VARMOD_LUXE"
            }) },

            { WeaponHash.AssaultrifleMk2, new AllowedWeapon("Assault Rifle Mk II", WeaponSlotType.Big, new List<string> {
                "COMPONENT_ASSAULTRIFLE_MK2_CLIP_01",
                "COMPONENT_ASSAULTRIFLE_MK2_CLIP_02",
                "COMPONENT_ASSAULTRIFLE_MK2_CLIP_TRACER",
                "COMPONENT_ASSAULTRIFLE_MK2_CLIP_INCENDIARY",
                "COMPONENT_ASSAULTRIFLE_MK2_CLIP_ARMORPIERCING",
                "COMPONENT_ASSAULTRIFLE_MK2_CLIP_FMJ",
                "COMPONENT_AT_AR_AFGRIP_02",
                "COMPONENT_AT_AR_FLSH",
                "COMPONENT_AT_SIGHTS",
                "COMPONENT_AT_SCOPE_MACRO_MK2",
                "COMPONENT_AT_SCOPE_MEDIUM_MK2",
                "COMPONENT_AT_AR_SUPP_02",
                "COMPONENT_AT_MUZZLE_01",
                "COMPONENT_AT_MUZZLE_02",
                "COMPONENT_AT_MUZZLE_03",
                "COMPONENT_AT_MUZZLE_04",
                "COMPONENT_AT_MUZZLE_05",
                "COMPONENT_AT_MUZZLE_06",
                "COMPONENT_AT_MUZZLE_07",
                "COMPONENT_AT_AR_BARREL_01",
                "COMPONENT_AT_AR_BARREL_02",
                "COMPONENT_ASSAULTRIFLE_MK2_CAMO",
                "COMPONENT_ASSAULTRIFLE_MK2_CAMO_02",
                "COMPONENT_ASSAULTRIFLE_MK2_CAMO_03",
                "COMPONENT_ASSAULTRIFLE_MK2_CAMO_04",
                "COMPONENT_ASSAULTRIFLE_MK2_CAMO_05",
                "COMPONENT_ASSAULTRIFLE_MK2_CAMO_06",
                "COMPONENT_ASSAULTRIFLE_MK2_CAMO_07",
                "COMPONENT_ASSAULTRIFLE_MK2_CAMO_08",
                "COMPONENT_ASSAULTRIFLE_MK2_CAMO_09",
                "COMPONENT_ASSAULTRIFLE_MK2_CAMO_10",
                "COMPONENT_ASSAULTRIFLE_MK2_CAMO_IND_01"
            }) },

            { WeaponHash.CarbineRifle, new AllowedWeapon("Carbine Rifle", WeaponSlotType.Big, new List<string> {
                "COMPONENT_CARBINERIFLE_CLIP_01",
                "COMPONENT_CARBINERIFLE_CLIP_02",
                "COMPONENT_CARBINERIFLE_CLIP_03",
                "COMPONENT_AT_AR_FLSH",
                "COMPONENT_AT_SCOPE_MEDIUM",
                "COMPONENT_AT_AR_SUPP",
                "COMPONENT_AT_AR_AFGRIP",
                "COMPONENT_CARBINERIFLE_VARMOD_LUXE"
            }) },

            { WeaponHash.CarbineRifleMk2, new AllowedWeapon("Carbine Rifle Mk II", WeaponSlotType.Big, new List<string> {
                "COMPONENT_CARBINERIFLE_MK2_CLIP_01",
                "COMPONENT_CARBINERIFLE_MK2_CLIP_02",
                "COMPONENT_CARBINERIFLE_MK2_CLIP_TRACER",
                "COMPONENT_CARBINERIFLE_MK2_CLIP_INCENDIARY",
                "COMPONENT_CARBINERIFLE_MK2_CLIP_ARMORPIERCING",
                "COMPONENT_CARBINERIFLE_MK2_CLIP_FMJ",
                "COMPONENT_AT_AR_AFGRIP_02",
                "COMPONENT_AT_AR_FLSH",
                "COMPONENT_AT_SIGHTS",
                "COMPONENT_AT_SCOPE_MACRO_MK2",
                "COMPONENT_AT_SCOPE_MEDIUM_MK2",
                "COMPONENT_AT_AR_SUPP",
                "COMPONENT_AT_MUZZLE_01",
                "COMPONENT_AT_MUZZLE_02",
                "COMPONENT_AT_MUZZLE_03",
                "COMPONENT_AT_MUZZLE_04",
                "COMPONENT_AT_MUZZLE_05",
                "COMPONENT_AT_MUZZLE_06",
                "COMPONENT_AT_MUZZLE_07",
                "COMPONENT_AT_CR_BARREL_01",
                "COMPONENT_AT_CR_BARREL_02",
                "COMPONENT_CARBINERIFLE_MK2_CAMO",
                "COMPONENT_CARBINERIFLE_MK2_CAMO_02",
                "COMPONENT_CARBINERIFLE_MK2_CAMO_03",
                "COMPONENT_CARBINERIFLE_MK2_CAMO_04",
                "COMPONENT_CARBINERIFLE_MK2_CAMO_05",
                "COMPONENT_CARBINERIFLE_MK2_CAMO_06",
                "COMPONENT_CARBINERIFLE_MK2_CAMO_07",
                "COMPONENT_CARBINERIFLE_MK2_CAMO_08",
                "COMPONENT_CARBINERIFLE_MK2_CAMO_09",
                "COMPONENT_CARBINERIFLE_MK2_CAMO_10",
                "COMPONENT_CARBINERIFLE_MK2_CAMO_IND_01"
            }) },

            { WeaponHash.AdvancedRifle, new AllowedWeapon("Advanced Rifle", WeaponSlotType.Big, new List<string> {
                "COMPONENT_ADVANCEDRIFLE_CLIP_01",
                "COMPONENT_ADVANCEDRIFLE_CLIP_02",
                "COMPONENT_AT_AR_FLSH",
                "COMPONENT_AT_SCOPE_SMALL",
                "COMPONENT_AT_AR_SUPP",
                "COMPONENT_ADVANCEDRIFLE_VARMOD_LUXE"
            }, Tuple.Create(new Vector3(0f, 0f, 0.14f), Vector3.Zero)) },

            { WeaponHash.SpecialCarbine, new AllowedWeapon("Special Carbine", WeaponSlotType.Big, new List<string> {
                "COMPONENT_SPECIALCARBINE_CLIP_01",
                "COMPONENT_SPECIALCARBINE_CLIP_02",
                "COMPONENT_SPECIALCARBINE_CLIP_03",
                "COMPONENT_AT_AR_FLSH",
                "COMPONENT_AT_SCOPE_MEDIUM",
                "COMPONENT_AT_AR_SUPP_02",
                "COMPONENT_AT_AR_AFGRIP",
                "COMPONENT_SPECIALCARBINE_VARMOD_LOWRIDER"
            }) },

            { WeaponHash.SpecialCarbineMk2, new AllowedWeapon("Special Carbine Mk II", WeaponSlotType.Big, new List<string> {
                "COMPONENT_SPECIALCARBINE_MK2_CLIP_01",
                "COMPONENT_SPECIALCARBINE_MK2_CLIP_02",
                "COMPONENT_SPECIALCARBINE_MK2_CLIP_TRACER",
                "COMPONENT_SPECIALCARBINE_MK2_CLIP_INCENDIARY",
                "COMPONENT_SPECIALCARBINE_MK2_CLIP_ARMORPIERCING",
                "COMPONENT_SPECIALCARBINE_MK2_CLIP_FMJ",
                "COMPONENT_AT_AR_FLSH",
                "COMPONENT_AT_SIGHTS",
                "COMPONENT_AT_SCOPE_MACRO_MK2",
                "COMPONENT_AT_SCOPE_MEDIUM_MK2",
                "COMPONENT_AT_AR_SUPP_02",
                "COMPONENT_AT_MUZZLE_01",
                "COMPONENT_AT_MUZZLE_02",
                "COMPONENT_AT_MUZZLE_03",
                "COMPONENT_AT_MUZZLE_04",
                "COMPONENT_AT_MUZZLE_05",
                "COMPONENT_AT_MUZZLE_06",
                "COMPONENT_AT_MUZZLE_07",
                "COMPONENT_AT_AR_AFGRIP_02",
                "COMPONENT_AT_SC_BARREL_01",
                "COMPONENT_AT_SC_BARREL_02",
                "COMPONENT_SPECIALCARBINE_MK2_CAMO",
                "COMPONENT_SPECIALCARBINE_MK2_CAMO_02",
                "COMPONENT_SPECIALCARBINE_MK2_CAMO_03",
                "COMPONENT_SPECIALCARBINE_MK2_CAMO_04",
                "COMPONENT_SPECIALCARBINE_MK2_CAMO_05",
                "COMPONENT_SPECIALCARBINE_MK2_CAMO_06",
                "COMPONENT_SPECIALCARBINE_MK2_CAMO_07",
                "COMPONENT_SPECIALCARBINE_MK2_CAMO_08",
                "COMPONENT_SPECIALCARBINE_MK2_CAMO_09",
                "COMPONENT_SPECIALCARBINE_MK2_CAMO_10",
                "COMPONENT_SPECIALCARBINE_MK2_CAMO_IND_01"
            }) },

            { WeaponHash.BullpupRifle, new AllowedWeapon("Bullpup Rifle", WeaponSlotType.Big, new List<string> {
                "COMPONENT_BULLPUPRIFLE_CLIP_01",
                "COMPONENT_BULLPUPRIFLE_CLIP_02",
                "COMPONENT_AT_AR_FLSH",
                "COMPONENT_AT_SCOPE_SMALL",
                "COMPONENT_AT_AR_SUPP",
                "COMPONENT_AT_AR_AFGRIP",
                "COMPONENT_BULLPUPRIFLE_VARMOD_LOW"
            }) },

            { WeaponHash.BullpupRifleMk2, new AllowedWeapon("Bullpup Rifle Mk II", WeaponSlotType.Big, new List<string> {
                "COMPONENT_BULLPUPRIFLE_MK2_CLIP_01",
                "COMPONENT_BULLPUPRIFLE_MK2_CLIP_02",
                "COMPONENT_BULLPUPRIFLE_MK2_CLIP_TRACER",
                "COMPONENT_BULLPUPRIFLE_MK2_CLIP_INCENDIARY",
                "COMPONENT_BULLPUPRIFLE_MK2_CLIP_ARMORPIERCING",
                "COMPONENT_BULLPUPRIFLE_MK2_CLIP_FMJ",
                "COMPONENT_AT_AR_FLSH",
                "COMPONENT_AT_SIGHTS",
                "COMPONENT_AT_SCOPE_MACRO_02_MK2",
                "COMPONENT_AT_SCOPE_SMALL_MK2",
                "COMPONENT_AT_BP_BARREL_01",
                "COMPONENT_AT_BP_BARREL_02",
                "COMPONENT_AT_AR_SUPP",
                "COMPONENT_AT_MUZZLE_01",
                "COMPONENT_AT_MUZZLE_02",
                "COMPONENT_AT_MUZZLE_03",
                "COMPONENT_AT_MUZZLE_04",
                "COMPONENT_AT_MUZZLE_05",
                "COMPONENT_AT_MUZZLE_06",
                "COMPONENT_AT_MUZZLE_07",
                "COMPONENT_AT_AR_AFGRIP_02",
                "COMPONENT_BULLPUPRIFLE_MK2_CAMO",
                "COMPONENT_BULLPUPRIFLE_MK2_CAMO_02",
                "COMPONENT_BULLPUPRIFLE_MK2_CAMO_03",
                "COMPONENT_BULLPUPRIFLE_MK2_CAMO_04",
                "COMPONENT_BULLPUPRIFLE_MK2_CAMO_05",
                "COMPONENT_BULLPUPRIFLE_MK2_CAMO_06",
                "COMPONENT_BULLPUPRIFLE_MK2_CAMO_07",
                "COMPONENT_BULLPUPRIFLE_MK2_CAMO_08",
                "COMPONENT_BULLPUPRIFLE_MK2_CAMO_09",
                "COMPONENT_BULLPUPRIFLE_MK2_CAMO_10",
                "COMPONENT_BULLPUPRIFLE_MK2_CAMO_IND_01"
            }, Tuple.Create(new Vector3(0f, 0f, 0.05f), Vector3.Zero)) },

            { WeaponHash.CompactRifle, new AllowedWeapon("Compact Rifle", WeaponSlotType.Small, new List<string> {
                "COMPONENT_COMPACTRIFLE_CLIP_01",
                "COMPONENT_COMPACTRIFLE_CLIP_02",
                "COMPONENT_COMPACTRIFLE_CLIP_03"
            }) },

            // Snipers
            { WeaponHash.MarksmanRifle, new AllowedWeapon("Marksman Rifle", WeaponSlotType.Big, new List<string> {
                "COMPONENT_MARKSMANRIFLE_CLIP_01",
                "COMPONENT_MARKSMANRIFLE_CLIP_02",
                "COMPONENT_AT_SCOPE_LARGE_FIXED_ZOOM",
                "COMPONENT_AT_AR_FLSH",
                "COMPONENT_AT_AR_SUPP",
                "COMPONENT_AT_AR_AFGRIP",
                "COMPONENT_MARKSMANRIFLE_VARMOD_LUXE"
            }) },

            { WeaponHash.MarksmanRifleMk2, new AllowedWeapon("Marksman Rifle Mk II", WeaponSlotType.Big, new List<string> {
                "COMPONENT_MARKSMANRIFLE_MK2_CLIP_01",
                "COMPONENT_MARKSMANRIFLE_MK2_CLIP_02",
                "COMPONENT_MARKSMANRIFLE_MK2_CLIP_TRACER",
                "COMPONENT_MARKSMANRIFLE_MK2_CLIP_INCENDIARY",
                "COMPONENT_MARKSMANRIFLE_MK2_CLIP_ARMORPIERCING",
                "COMPONENT_MARKSMANRIFLE_MK2_CLIP_FMJ",
                "COMPONENT_AT_SIGHTS",
                "COMPONENT_AT_SCOPE_MEDIUM_MK2",
                "COMPONENT_AT_SCOPE_LARGE_FIXED_ZOOM_MK2",
                "COMPONENT_AT_AR_FLSH",
                "COMPONENT_AT_AR_SUPP",
                "COMPONENT_AT_MUZZLE_01",
                "COMPONENT_AT_MUZZLE_02",
                "COMPONENT_AT_MUZZLE_03",
                "COMPONENT_AT_MUZZLE_04",
                "COMPONENT_AT_MUZZLE_05",
                "COMPONENT_AT_MUZZLE_06",
                "COMPONENT_AT_MUZZLE_07",
                "COMPONENT_AT_MRFL_BARREL_01",
                "COMPONENT_AT_MRFL_BARREL_02",
                "COMPONENT_AT_AR_AFGRIP_02",
                "COMPONENT_MARKSMANRIFLE_MK2_CAMO",
                "COMPONENT_MARKSMANRIFLE_MK2_CAMO_02",
                "COMPONENT_MARKSMANRIFLE_MK2_CAMO_03",
                "COMPONENT_MARKSMANRIFLE_MK2_CAMO_04",
                "COMPONENT_MARKSMANRIFLE_MK2_CAMO_05",
                "COMPONENT_MARKSMANRIFLE_MK2_CAMO_06",
                "COMPONENT_MARKSMANRIFLE_MK2_CAMO_07",
                "COMPONENT_MARKSMANRIFLE_MK2_CAMO_08",
                "COMPONENT_MARKSMANRIFLE_MK2_CAMO_09",
                "COMPONENT_MARKSMANRIFLE_MK2_CAMO_10",
                "COMPONENT_MARKSMANRIFLE_MK2_CAMO_IND_01"
            }, Tuple.Create(new Vector3(0f, 0f, -0.05f), Vector3.Zero)) },

            // Machine Guns
            { WeaponHash.Gusenberg, new AllowedWeapon("Gusenberg Sweeper", WeaponSlotType.Big, new List<string> {
                "COMPONENT_GUSENBERG_CLIP_01",
                "COMPONENT_GUSENBERG_CLIP_02"
            }) },

            // Heavy Weapons
            { WeaponHash.GrenadeLauncher, new AllowedWeapon("Grenade Launcher", WeaponSlotType.Big, new List<string> {
                "COMPONENT_GRENADELAUNCHER_CLIP_01",
                "COMPONENT_AT_AR_FLSH",
                "COMPONENT_AT_AR_AFGRIP",
                "COMPONENT_AT_SCOPE_SMALL"
            }) },

            { WeaponHash.Railgun, new AllowedWeapon("Railgun", WeaponSlotType.Big, Tuple.Create(new Vector3(0f, 0f, -0.12f), Vector3.Zero)) },
            { WeaponHash.CompactGrenadeLauncher, new AllowedWeapon("Compact Grenade Launcher", WeaponSlotType.Small) },

            // Throwables
            { WeaponHash.Grenade, new AllowedWeapon("Grenade", WeaponSlotType.Throwable) },
            { WeaponHash.SmokeGrenade, new AllowedWeapon("Tear Gas", WeaponSlotType.Throwable, Tuple.Create(new Vector3(0f, 0f, 0.06f), Vector3.Zero)) },
            { WeaponHash.BZGas, new AllowedWeapon("BZ Gas", WeaponSlotType.Throwable, Tuple.Create(new Vector3(0f, 0f, 0.06f), Vector3.Zero)) },
            { WeaponHash.StickyBomb, new AllowedWeapon("Sticky Bomb", WeaponSlotType.Throwable, Tuple.Create(new Vector3(0f, 0f, -0.03f), Vector3.Zero)) },
            { WeaponHash.ProximityMine, new AllowedWeapon("Proximity Mine", WeaponSlotType.Throwable, Tuple.Create(new Vector3(0f, 0f, -0.03f), Vector3.Zero)) },
            { WeaponHash.PipeBomb, new AllowedWeapon("Pipe Bomb", WeaponSlotType.Throwable) }
        };
        #endregion
    }
}
