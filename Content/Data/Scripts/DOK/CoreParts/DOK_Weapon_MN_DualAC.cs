using static Scripts.Structure;
using static Scripts.Structure.WeaponDefinition;
using static Scripts.Structure.WeaponDefinition.ModelAssignmentsDef;
using static Scripts.Structure.WeaponDefinition.HardPointDef;
using static Scripts.Structure.WeaponDefinition.HardPointDef.Prediction;
using static Scripts.Structure.WeaponDefinition.TargetingDef.BlockTypes;
using static Scripts.Structure.WeaponDefinition.TargetingDef.Threat;
using static Scripts.Structure.WeaponDefinition.TargetingDef;
using static Scripts.Structure.WeaponDefinition.TargetingDef.CommunicationDef.Comms;
using static Scripts.Structure.WeaponDefinition.TargetingDef.CommunicationDef.SecurityMode;
using static Scripts.Structure.WeaponDefinition.HardPointDef.HardwareDef;
using static Scripts.Structure.WeaponDefinition.HardPointDef.HardwareDef.HardwareType;
using System.Collections.Generic;

namespace Scripts {
    partial class Parts {
        WeaponDefinition DOK_Weapon_MN_DualAC => new WeaponDefinition
        {
            Assignments = new ModelAssignmentsDef
            {
                MountPoints = new[] {
                    new MountPointDef {
                        SubtypeId = "DOK_LG_MN_DualAC",
                        MuzzlePartId = "elevation",
                        AzimuthPartId = "azimuth",
                        ElevationPartId = "elevation",
                        DurabilityMod = 0.25f,
                    },
                    new MountPointDef {
                        SubtypeId = "DOK_SG_MN_DualAC",
                        MuzzlePartId = "elevation",
                        AzimuthPartId = "azimuth",
                        ElevationPartId = "elevation",
                        DurabilityMod = 0.25f,
                    },
                 },
                Muzzles = new[] {
                    "muzzle_barrel_1",
                    "muzzle_barrel_2",
                },
                Scope = "muzzle_barrel_1",
            },
            Targeting = new TargetingDef
            {
                Threats = new[] {
                    Grids, Projectiles, Characters, Meteors, // Types of threat to engage: Grids, Projectiles, Characters, Meteors, Neutrals, ScanRoid, ScanPlanet, ScanFriendlyCharacter, ScanFriendlyGrid, ScanEnemyCharacter, ScanEnemyGrid, ScanNeutralCharacter, ScanNeutralGrid, ScanUnOwnedGrid, ScanOwnersGrid
                },
                SubSystems = new[] {
                    Thrust, Utility, Offense, Power, Production, Any, // Subsystem targeting priority: Offense, Utility, Power, Production, Thrust, Jumping, Steering, Any
                },
                MaxTargetDistance = 1000,
            },
            HardPoint = new HardPointDef
            {
                PartName = "MNDAC-05",
                DeviateShotAngle = 0.4f, // Projectile inaccuracy in degrees.
                AimingTolerance = 1f, // How many degrees off target a turret can fire at. 0 - 180 firing angle.
                AimLeadingPrediction = Accurate, // Level of turret aim prediction; Off, Basic, Accurate, Advanced
                AddToleranceToTracking = true, // Allows turret to track to the edge of the AimingTolerance cone instead of dead centre.
                DelayCeaseFire = 10, // Measured in game ticks (6 = 100ms, 60 = 1 second, etc..). Length of time the weapon continues firing after trigger is released.
                CanShootSubmerged = false, // Whether the weapon can be fired underwater when using WaterMod.
                Ai = new AiDef
                {
                    DefaultLeadGroup = 1, // Default LeadGroup setting, range 0-5, 0 is disables lead group.  Only useful for fixed weapons or weapons set to OverrideLeads.
                    TrackTargets = true,
                    TurretAttached = true,
                    TurretController = true,
                },
                HardWare = new HardwareDef
                {
                    RotateRate = 0.01f,
                    ElevateRate = 0.01f,
                    MinAzimuth = -180,
                    MaxAzimuth = 180,
                    MinElevation = -10,
                    MaxElevation = 80,
                    InventorySize = 0.6f,
                    Type = BlockWeapon,
                },
                Other = new OtherDef
                {
                    Debug = false, // Force enables debug mode.
                },
                Loading = new LoadingDef
                {
                    RateOfFire = 800, // Set this to 3600 for beam weapons. This is how fast your Gun fires.
                    BarrelsPerShot = 2, // How many muzzles will fire a projectile per fire event.
                    TrajectilesPerBarrel = 1, // Number of projectiles per muzzle per fire event.
                    SkipBarrels = 0, // Number of muzzles to skip after each fire event.
                    ReloadTime = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    MagsToLoad = 4, // Number of physical magazines to consume on reload.
                    DelayUntilFire = 0, // How long the weapon waits before shooting after being told to fire. Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    HeatPerShot = 1, // Heat generated per shot.
                    MaxHeat = 800, // Max heat before weapon enters cooldown (70% of max heat).
                    Cooldown = 0.7f, // Percentage of max heat to be under to start firing again after overheat; accepts 0 - 0.95
                    HeatSinkRate= 40, // Amount of heat lost per second.
                    DegradeRof = false, // Progressively lower rate of fire when over 80% heat threshold (80% of max heat).
                    ShotsInBurst = 0, // Use this if you don't want the weapon to fire an entire physical magazine in one go. Should not be more than your magazine capacity.
                    StayCharged = true, // Will start recharging whenever power cap is not full.
                },
                Audio = new HardPointAudioDef
                {
                    FiringSound = "_DOK_MN_DualAC_Shot", // Audio for firing.
                    FiringSoundPerShot = false, // Whether to replay the sound for each shot, or just loop over the entire track while firing.
                    NoAmmoSound = "WepShipGatlingNoAmmo",
                    HardPointRotationSound = "_DOK_TurretTurn", // Audio played when turret is moving.
                    BarrelRotationSound = "WepShipGatlingRotation",
                    FireSoundEndDelay = 0, // How long the firing audio should keep playing after firing stops. Measured in game ticks(6 = 100ms, 60 = 1 seconds, etc..).
                    FireSoundNoBurst = true, // Don't stop firing sound from looping when delaying after burst.
                },
                Graphics = new HardPointParticleDef
                {
                    Effect1 = new ParticleDef
                    {
                        Name = "Muzzle_Flash_Autocannon", // SubtypeId of muzzle particle effect.
                        Extras = new ParticleOptionDef
                        {
                            Loop = true, // Set this to the same as in the particle sbc!
                            Scale = 1f, // Scale of effect.
                        },
                    },
                    Effect2 = new ParticleDef
                    {
                        Name = "Smoke_LargeGunShot_WC",
                        Extras = new ParticleOptionDef
                        {
                            Loop = true, // Set this to the same as in the particle sbc!
                            Scale = 1f,
                        },
                    },
                },
            },
            Ammos = new[] {
                DOK_Ammo_MN_DualAC
            },
            Animations = DOK_Animation_MN_DualAC,
        };
    }
}
