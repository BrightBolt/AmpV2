﻿using System.Reflection;
using R2API;
using UnityEngine;
using UnityEngine.Networking;
using RoR2;
using EntityStates;
using System.IO;
using RoR2.Projectile;
using UnityEngine.AddressableAssets;
using System.Collections.Generic;
using RoR2.UI;
using UnityEngine.Rendering.PostProcessing;
using TMPro;
using AmpMod.SkillStates.Nemesis_Amp.Components;
using EntityStates.ClaymanMonster;
using EntityStates.LemurianMonster;
using AmpMod.SkillStates.SkillComponents;

namespace AmpMod.Modules
{
    internal static class Assets
    {
        // the assetbundle to load assets from
        internal static AssetBundle mainAssetBundle;
        internal static string prefix = AmpPlugin.developerPrefix;


        [Header("Materials")]
        internal static Material matRedLightning;
        internal static Material matBlueLightning;
        internal static Material matLightningLongPurple;
        internal static Material matFieldIndicator;
        internal static Material matRedTrail;
        internal static Material matBlueTrail;
        internal static Material matPurpleTrail;
        internal static Material matLightningLongRed;
        internal static Material matLightningLongBlue;
        internal static Material matLightningMatrixRed;
        internal static Material matLightningSphereRed;
        internal static Material matDirectionalMatrixRed;
        internal static Material matHitSpark;
        internal static Material matRing;
        internal static Material matTracerBright;
        internal static Texture texRampRedLightning;
        internal static Material matPulseTriRed;
        internal static Material matLightningStrikeRed;
        internal static Color redLightningColor = new Color32(191, 2, 0, 255);
        internal static Color lightRedLightningColor = new Color32(255, 100, 100, 255);
        internal static Color darkRedLightningColor = new Color32(103, 0, 0, 255);


        #region Amp Assets
        [Header("Shockblade Effects")]
        internal static GameObject swordSwingEffect;
        internal static GameObject swordHitImpactEffect;
        internal static GameObject swordSwingEffectRed;
        internal static GameObject swordHitImpactEffectRed;

        [Header("Charge/Passive Effects")]
        internal static GameObject chargeExplosionEffect;
        internal static GameObject chargeExplosionEffectRed;
        internal static GameObject chargeOrbObject;
        internal static GameObject chargeOrbFullObject;
        internal static GameObject chargeOrbRedObject;
        internal static GameObject chargeOrbFullRedObject;
        internal static GameObject orbStrikeEffect;

        [Header("Ferroshot/Lorentz Cannon Effects")]
        internal static GameObject bulletSpawnEffect;
        internal static GameObject bulletPrepItem;
        internal static GameObject bulletImpactEffect;
        internal static GameObject ampBulletMuzzleEffect;
        internal static GameObject sandedOverlay;
        internal static Material sandedMaterial;

        [Header("Magnetic Vortex Effects")]
        internal static GameObject vortexBlackholePrefab;
        internal static GameObject vortexExplosionEffect;
        internal static GameObject vortexMuzzleEffect;
        internal static GameObject vortexMuzzleEffectRed;

        [Header("Bolt Effects")]
        internal static GameObject boltExitEffect;
        internal static GameObject boltEnterEffect;
        internal static GameObject boltExitEffectRed;
        internal static GameObject boltEnterEffectRed;
        internal static GameObject boltVehicle;

        [Header("Pulse Leap Effects")]
        internal static GameObject pulseBlastEffect;
        internal static GameObject pulseMuzzleEffect;
        internal static GameObject pulseBlastEffectRed;
        internal static GameObject pulseMuzzleEffectRed;
        internal static GameObject pulseLightningCover;
        internal static GameObject pulseLightningCoverRed;

        [Header("Plasma Slash Effects")]
        internal static GameObject heatSwing;
        internal static GameObject heatHit;
        internal static GameObject heatExplosion;
        internal static NetworkSoundEventDef plasmaExplosionSoundEvent;
        internal static GameObject plasmaMuzzle;
        internal static GameObject fireTrail;

        [Header("Fulmination Effects")]
        internal static GameObject electricStreamEffect;
        internal static GameObject electricImpactEffect;
        internal static GameObject electricChainEffect;
        internal static GameObject electricMuzzleEffect;
        internal static GameObject electricStreamEffectRed;
        internal static GameObject electricImpactEffectRed;
        internal static GameObject electricChainEffectRed;

        [Header("VoltaicBombardment Effects")]
        internal static GameObject lightningStrikePrefab;
        internal static GameObject lightningMuzzleChargePrefab;
        internal static GameObject lightningStrikePrefabRed;
        internal static GameObject lightningMuzzleChargePrefabRed;
        internal static GameObject strikeBlinkPrefab;
        internal static GameObject strikeBlinkPrefabRed;
        internal static GameObject strikeBlastPrefab;
        internal static GameObject strikeBlastPrefabRed;
        internal static GameObject strikeHover;
        internal static GameObject strikeHoverRed;
        internal static GameObject strikeBoltPrefab;
        internal static GameObject strikeBoltPrefabRed;

        [Header("Bulwark of Storms Effects")]
        internal static GameObject wormExplosionEffect;
        internal static GameObject melvinPrefab;
        internal static GameObject melvinBody;

        [Header("Lobby Effects")]
        internal static GameObject lobbyEntranceEffect;

        #endregion

        #region Nemesis Amp Assets
        [Header("Death/Spawn Effects")]
        internal static GameObject deathExplosionEffect;
        internal static Material matDeathOverlay;
        internal static GameObject spawnSecondaryExplosionEffect;
        internal static GameObject deathExplosionEffectBlue;
        internal static Material matDeathOverlayBlue;
        internal static GameObject spawnSecondaryExplosionEffectBlue;
        internal static GameObject spawnDustEffect;

        [Header("Passive Effects")]
        internal static GameObject passiveMeter;
        internal static GameObject maxBuffFlashEffect;
        internal static Material buffOverlayMat;
        internal static GameObject maxBuffOffEffect;
        internal static GameObject maxBuffFlashEffectBlue;
        internal static Material buffOverlayMatBlue;
        internal static GameObject maxBuffOffEffectBlue;

        [Header("Fulmination Effects")]
        internal static GameObject lightningStreamEffect;
        internal static GameObject lightningStreamImpactEffect;
        internal static GameObject lightningStreamMuzzleEffect;
        internal static GameObject lightningStreamChainEffectPrefab;
        internal static GameObject lightningCrosshair;
        internal static GameObject lightningStreamMuzzleFlash;
        internal static GameObject lightningStreamEffectBlue;
        internal static GameObject lightningStreamImpactEffectBlue;
        internal static GameObject lightningStreamMuzzleEffectBlue;
        internal static GameObject lightningStreamChainEffectPrefabBlue;
        internal static GameObject lightningCrosshairBlue;
        internal static GameObject lightningStreamMuzzleFlashBlue;

        [Header("Lorentz Blades Effects")]
        internal static GameObject bladePrepObject;
        internal static GameObject bladeFireEffect;
        internal static GameObject bladeExpireEffect;
        internal static GameObject bladePrepObjectBlue;
        internal static GameObject bladeFireEffectBlue;
        internal static GameObject bladeExpireEffectBlue;
        internal static GameObject bladeMuzzleEffect;

        [Header("Howitzer Spark Effects")]
        internal static GameObject chargeBeamMuzzleEffect;
        internal static GameObject chargeBeamTracerPrefab;
        //internal static GameObject chargeBeamHitEffect;
        internal static GameObject beamMuzzleFlashEffect;
        internal static GameObject chargeBeamMuzzleEffectBlue;
        internal static GameObject chargeBeamTracerPrefabBlue;
        internal static GameObject beamMuzzleFlashEffectBlue;
        // internal static GameObject fireBeamEffect;

        [Header("Galvanic Cleave Effects")]
        internal static GameObject lightningBladePrefab;
        internal static GameObject spawnLightningBladeVFX;
        internal static GameObject lightningBladeSlashVFX;
        internal static GameObject lightningBladeHitVFX;
        internal static GameObject lightningBladePrefabBlue;
        internal static GameObject spawnLightningBladeVFXBlue;
        internal static GameObject lightningBladeSlashVFXBlue;
        internal static GameObject lightningBladeHitVFXBlue;

        [Header("Static Field Effects")]
        internal static GameObject aimFieldMuzzleEffect;
        internal static GameObject releaseFieldMuzzleEffect;
        internal static GameObject aimFieldMuzzleEffectBlue;
        internal static GameObject releaseFieldMuzzleEffectBlue;
        internal static GameObject staticFieldPrefab;
        internal static GameObject staticFieldIndicatorPrefab;

        [Header("Quicksurge Effects")]
        internal static GameObject dashVFXPrefab;
        internal static GameObject dashEnterEffect;
        internal static GameObject lightningBallExplosionEffect;
        internal static GameObject lightningBallMuzzleFlashEffect;
        internal static GameObject dashVFXPrefabBlue;
        internal static GameObject dashEnterEffectBlue;
        internal static GameObject lightningBallExplosionEffectBlue;
        internal static GameObject lightningBallMuzzleFlashEffectBlue;
        internal static GameObject lightningStakeMuzzleObject;
        internal static GameObject lightningStakeFlashEffect;
        internal static GameObject lightningStakeFlashEffectBlue;
        internal static GameObject lightningStakeMuzzleObjectBlue;
        internal static GameObject plasmaCrosshair;
        internal static GameObject plasmaActiveVFX;
        internal static GameObject plasmaActiveVFXBlue;

        [Header("Voltaic Onslaught Effects")]
        internal static GameObject purpleStormBoltEffect;
        internal static GameObject stormMuzzleFlashEffect;
        internal static GameObject stormMuzzleFlashEffectBlue;
        internal static GameObject stormRangeIndicator;
        internal static GameObject stormRangeIndicatorBlue;

        [Header("Photon Shot Effects")]
        internal static GameObject photonChargeEffect;
        internal static GameObject photonMuzzleFlash;
        internal static GameObject photonTracer;
        internal static GameObject photonImpact;
        internal static GameObject photonDetonateExplosion;
        internal static GameObject photonMuzzleFlashBlue;
        internal static GameObject photonTracerBlue;
        internal static GameObject photonImpactBlue;
        internal static GameObject photonImpactDetonateBlue;

        #endregion

        // networked hit sounds
        internal static NetworkSoundEventDef swordHitSoundEvent;
        internal static NetworkSoundEventDef vortexLoopSoundEvent;
        internal static NetworkSoundEventDef vortexFlightLoopSoundEvent;
        internal static NetworkSoundEventDef stormbladeHitSoundEvent;
        internal static NetworkSoundEventDef vortexSpawnSoundEvent;
        internal static NetworkSoundEventDef heatShockSwingSoundEvent;
        internal static NetworkSoundEventDef heatShockHitSoundEvent;

        // lists of assets to add to contentpack
        internal static List<NetworkSoundEventDef> networkSoundEventDefs = new List<NetworkSoundEventDef>();
        internal static List<EffectDef> effectDefs = new List<EffectDef>();

        // cache these and use to create our own materials
        internal static Shader hotpoo = RoR2.LegacyResourcesAPI.Load<Shader>("Shaders/Deferred/HGStandard");
        internal static Material commandoMat;
        private static string[] assetNames = new string[0];
        internal static ItemDef wormHealth;


        private const string assetbundleName = "ampbundle";

        internal static void Initialize()
        {
            if (assetbundleName == "myassetbundle")
            {
                Debug.LogError("AssetBundle name hasn't been changed- not loading any assets to avoid conflicts");
                return;
            }

            LoadAssetBundle();
            AdjustMats();
            LoadSoundbank();
            PopulateAssets();
            
        }

        internal static void AdjustMats()
        {
            var materialAssets = mainAssetBundle.LoadAllAssets<Material>();
            foreach (Material material in materialAssets)
            {
                if (material.shader.name == "Hopoo Games/FX/Cloud Remap")
                {

                    material.shader = LegacyResourcesAPI.Load<Shader>("shaders/fx/hgcloudremap");
                }

                if (material.shader.name == "Stubbed Hopoo Games/FX/Cloud Remap")
                {
                    material.shader = LegacyResourcesAPI.Load<Shader>("shaders/fx/hgcloudremap");
                } 

                else if (material.shader.name == "Stubbed Hopoo Games/FX/Cloud Intersection Remap")
                {
                    material.shader = LegacyResourcesAPI.Load<Shader>("shaders/fx/hgintersectioncloudremap");
                }

                else if (material.shader.name == "Stubbed Hopoo Games/UI/Default Overbrighten")
                {
                    material.shader = LegacyResourcesAPI.Load<Shader>("Shaders/UI/HGUIOverbrighten");
                }

                else if (material.shader.name == "Stubbed Hopoo Games/FX/Distortion")
                {
                    material.shader = LegacyResourcesAPI.Load<Shader>("Shaders/FX/HGDistortion");
                }

                else if (material.shader.name == "StubbedShader/deferred/standard")
                {
                    material.shader = LegacyResourcesAPI.Load<Shader>("Shaders/Deferred/HGStandard");
                }

            }

        }
        internal static void LoadAssetBundle()
        {
            if (mainAssetBundle == null)
            {
                using (var assetStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("AmpMod." + assetbundleName))
                {
                    mainAssetBundle = AssetBundle.LoadFromStream(assetStream);
                }
            }

            assetNames = mainAssetBundle.GetAllAssetNames();
        }

        internal static void LoadSoundbank()
        {
 

            using (Stream manifestResourceStream2 = Assembly.GetExecutingAssembly().GetManifestResourceStream("AmpMod.AmpSoundbank.bnk"))
            {
                byte[] array = new byte[manifestResourceStream2.Length];
                manifestResourceStream2.Read(array, 0, array.Length);
                SoundAPI.SoundBanks.Add(array);
            }
        }

        

        internal static void PopulateAssets()
        {
            if (!mainAssetBundle)
            {
                Debug.LogError("There is no AssetBundle to load assets from.");
                return;
            }


            ItemDisplayRule[] nullDisplay = new ItemDisplayRule[] { };
            wormHealth = ScriptableObject.CreateInstance<ItemDef>();
            wormHealth.name = "wormHealth";

            //wormHealth.tier = ItemTier.NoTier;
            wormHealth.descriptionToken = "bruh";
            wormHealth.loreToken = "bruh";
            wormHealth.AutoPopulateTokens();

            wormHealth.deprecatedTier = ItemTier.NoTier;

                 
            
            // wormHealth.pickupToken = "bruh";

            ItemAPI.Add(new CustomItem(wormHealth, new ItemDisplayRule[0]));

            #region Amp
            //shockblade hit
            stormbladeHitSoundEvent = CreateNetworkSoundEventDef(StaticValues.stormbladeHit4String);

            //create magnetic vortex projectile flight loop event
            vortexFlightLoopSoundEvent = CreateNetworkSoundEventDef(StaticValues.vortexFlightLoopString);

            //magnetic vortex loop sound effect
            vortexLoopSoundEvent = CreateNetworkSoundEventDef(StaticValues.vortexLoopString);

            //magnetic vortex spawn sound effect
            vortexSpawnSoundEvent = CreateNetworkSoundEventDef(StaticValues.vortexSpawnString);

            //heatshock hit & swing sound events
            heatShockHitSoundEvent = CreateNetworkSoundEventDef(StaticValues.heatHitString);
            heatShockSwingSoundEvent = CreateNetworkSoundEventDef(StaticValues.heatSwingString);

            //plasma slash explosion sound events
            plasmaExplosionSoundEvent = CreateNetworkSoundEventDef(StaticValues.plasmaExplosionString);

            //materials
            CreateMaterials();

            //on voltaic bombardment aim
            CreateLightningCharge();

            //on charge proc
            CreateChargeOrb();

                                

            //on charge explosion when 3 procs are reached
            CreateChargePrefab();
            CreateSanded();

            //on fulmination skill chain
            //electricChainEffect = mainAssetBundle.LoadAsset<GameObject>("ElectricityChain");

            //on fulmination skill use
            CreateStreamPrefab();
            CreateChainPrefab();

            //on heatshock use
            heatHit = Assets.LoadEffect("heatHit");
            heatSwing = Assets.LoadEffect("heatSwing 1", true);
            CreateHeatExplosion();

            //on boltvehicle exit/state/enter
            CreateBoltExitPrefab();
            CreateBoltVehicle();
            CreateBoltEnterPrefab();

            //on ferroshot/Lorentz Cannon skill prep
            CreateBulletPrep();
            bulletSpawnEffect = LoadEffect("Spike Spawn");
            //CreateBulletMuzzle();

            //on ferroshot/Lorentz Cannon spike collision
            bulletImpactEffect = mainAssetBundle.LoadAsset<GameObject>("SpikeExplosionEffect");
            AddNewEffectDef(bulletImpactEffect);

            //on pulse leap use
            CreatePulseBlastPrefab();  

            //on magnetic vortex blackhole spawn
            CreateVortexBlackhole();

            //magnetic vortex muzzle
            CreateVortexMuzzle();

            //on bulwark of storms use
            CreateWormEffects();
            CreateMelvin();

            //functions for prefabs that require adjustments made at runtime
            CreateLightningPrefab();

            CreateShockbladeEffects();
            #endregion

            #region Nemesis Amp
            CreateSpawn();
            CreateDeath();
            CreateChargeBeam();
            CreateLightningStream();
            CreateStaticField();
            CreateAOELightning();
            CreatePassiveMeter();
            CreateLightningDash();
            CreateLightningSlash();
            CreateFluxBlades();
            CreatePhotonShot();
            #endregion

        }


        private static void CreateShockbladeEffects()
        {
            swordSwingEffect = Assets.LoadEffect("StormbladeSwing", true);
            swordHitImpactEffect = Assets.LoadEffect("StormbladeHit");
            swordSwingEffectRed = Assets.LoadEffect("StormbladeSwingRed", true);
            swordHitImpactEffectRed = Assets.LoadEffect("StormbladeHitRed");

            orbStrikeEffect = mainAssetBundle.LoadAsset<GameObject>("ElectricOrbImpact");
            AddNewEffectDef(orbStrikeEffect);
        }

        private static void CreateMaterials()
        {

            matRedLightning = mainAssetBundle.LoadAsset<Material>("LightningEffectRed");
            matBlueLightning = mainAssetBundle.LoadAsset<Material>("LightningEffect");

            CreateBrightenMaterial("matUIOverbrighten2x");

            #region NemAmp Mats


            #region Passive
            buffOverlayMat = mainAssetBundle.LoadAsset<Material>("matLightningOverlay");
            buffOverlayMatBlue = mainAssetBundle.LoadAsset<Material>("matLightningOverlayBlue");
            #endregion


            #region Howitzer Spark
            matPurpleTrail = mainAssetBundle.LoadAsset<Material>("matChargeBeamTrail");
            #endregion


            #region Static Field
            matFieldIndicator = CreateIntersectMaterial("matAimAreaIndicator");
            CreateDecalMaterial("matDOTDecal");
            #endregion

            #endregion

            matBlueTrail = mainAssetBundle.LoadAsset<Material>("matLorentzTrail");
            matRedTrail = mainAssetBundle.LoadAsset<Material>("matLorentzTrailRed");
            matLightningMatrixRed = mainAssetBundle.LoadAsset<Material>("matLightningMatrixRed");
            matLightningLongRed = mainAssetBundle.LoadAsset<Material>("matLightningLongRed");
            matLightningLongPurple = mainAssetBundle.LoadAsset<Material>("matLightningLongPurple");
            matPulseTriRed = mainAssetBundle.LoadAsset<Material>("matPulseMuzzleTriRed");
            matDirectionalMatrixRed = mainAssetBundle.LoadAsset<Material>("matDirectionalMatrixRed");
            matTracerBright = mainAssetBundle.LoadAsset<Material>("matTracerBright");
            matRing = mainAssetBundle.LoadAsset<Material>("matOmniRing2");
            matHitSpark = mainAssetBundle.LoadAsset<Material>("matOmniHitspark3");
            matLightningStrikeRed = mainAssetBundle.LoadAsset<Material>("matLightningStrikeRed");
            matLightningLongBlue = mainAssetBundle.LoadAsset<Material>("matLightningLongBlue");

            matLightningSphereRed = CreateIntersectMaterial("matLightningSphereRed");
            
            
            texRampRedLightning = mainAssetBundle.LoadAsset<Texture>("texRampLightningRed");


    
            //matRedTrail.SetTexture("_RemapTex", mainAssetBundle.LoadAsset<Texture>("texRampGolem"));


             
        }

        #region Nemesis Amp Assets

        private static void CreateSpawn()
        {
            spawnSecondaryExplosionEffect = mainAssetBundle.LoadAsset<GameObject>("SpawnRingEffect");
            AddNewEffectDef(spawnSecondaryExplosionEffect);

            spawnSecondaryExplosionEffectBlue = mainAssetBundle.LoadAsset<GameObject>("SpawnRingEffectBlue");
            AddNewEffectDef(spawnSecondaryExplosionEffectBlue);

            spawnDustEffect = mainAssetBundle.LoadAsset<GameObject>("DigEffect");
            AddNewEffectDef(spawnDustEffect);


        }
        private static void CreateDeath()
        {
            deathExplosionEffect = mainAssetBundle.LoadAsset<GameObject>("DeathExplosion");
            matDeathOverlay = mainAssetBundle.LoadAsset<Material>("matDeathOverlay");

            AddNewEffectDef(deathExplosionEffect);

            deathExplosionEffectBlue = mainAssetBundle.LoadAsset<GameObject>("DeathExplosionBlue");
            matDeathOverlayBlue = mainAssetBundle.LoadAsset<Material>("matDeathOverlayBlue");

            AddNewEffectDef(deathExplosionEffectBlue);

            CreateIntersectMaterial("matLightningSpherePurpleReal");  
        }
        private static void CreateLightningStream()
        {
            lightningStreamEffect = mainAssetBundle.LoadAsset<GameObject>("LightningOrbEffect");
            PrefabAPI.RegisterNetworkPrefab(lightningStreamEffect);

            //lightningStreamEffect.AddComponent<SkillStates.Nemesis_Amp.NemAmpLightningRendererNoise>();
            //AddNewEffectDef(lightningStreamEffect);
            var lightningStreamOmniImpact = mainAssetBundle.LoadAsset<GameObject>("OmniImpactVFXLightning");
            AddNewEffectDef(lightningStreamOmniImpact);

            lightningStreamImpactEffect = mainAssetBundle.LoadAsset<GameObject>("LightningOrbImpact");
            AddNewEffectDef(lightningStreamImpactEffect);

            lightningCrosshair = mainAssetBundle.LoadAsset<GameObject>("LightningIndicator");
            lightningCrosshair.AddComponent<NetworkIdentity>().localPlayerAuthority = true;
            PrefabAPI.RegisterNetworkPrefab(lightningCrosshair);

            lightningStreamChainEffectPrefab = mainAssetBundle.LoadAsset<GameObject>("LightningOrbChainEffect");
            lightningStreamChainEffectPrefab.AddComponent<SkillStates.Nemesis_Amp.Components.NemAmpChainLightningNoise>();
            PrefabAPI.RegisterNetworkPrefab(lightningStreamChainEffectPrefab);

            lightningStreamMuzzleEffect = mainAssetBundle.LoadAsset<GameObject>("LockOnMuzzle");
            PrefabAPI.RegisterNetworkPrefab(lightningStreamMuzzleEffect);

            lightningStreamMuzzleFlash = mainAssetBundle.LoadAsset<GameObject>("LockOnMuzzleFlash");
            PrefabAPI.RegisterNetworkPrefab(lightningStreamMuzzleFlash);

            #region Blue
            var lightningStreamOmniImpactBlue = mainAssetBundle.LoadAsset<GameObject>("OmniImpactVFXLightningBlue");
            AddNewEffectDef(lightningStreamOmniImpactBlue);

            lightningStreamEffectBlue = mainAssetBundle.LoadAsset<GameObject>("LightningOrbEffectBlue");
            PrefabAPI.RegisterNetworkPrefab(lightningStreamEffectBlue);

            lightningStreamImpactEffectBlue = mainAssetBundle.LoadAsset<GameObject>("LightningOrbImpactBlue");
            AddNewEffectDef(lightningStreamImpactEffectBlue);

            lightningCrosshairBlue = mainAssetBundle.LoadAsset<GameObject>("LightningIndicatorBlue");
            lightningCrosshairBlue.AddComponent<NetworkIdentity>().localPlayerAuthority = true;
            PrefabAPI.RegisterNetworkPrefab(lightningCrosshairBlue);

            lightningStreamChainEffectPrefabBlue = mainAssetBundle.LoadAsset<GameObject>("LightningOrbChainEffectBlue");
            lightningStreamChainEffectPrefabBlue.AddComponent<SkillStates.Nemesis_Amp.Components.NemAmpChainLightningNoise>();
            PrefabAPI.RegisterNetworkPrefab(lightningStreamChainEffectPrefabBlue);

            lightningStreamMuzzleEffectBlue = mainAssetBundle.LoadAsset<GameObject>("LockOnMuzzleBlue");
            PrefabAPI.RegisterNetworkPrefab(lightningStreamMuzzleEffectBlue);

            lightningStreamMuzzleFlashBlue = mainAssetBundle.LoadAsset<GameObject>("LockOnMuzzleFlashBlue");
            PrefabAPI.RegisterNetworkPrefab(lightningStreamMuzzleFlashBlue);

            #endregion

            //AddNewEffectDef(lightningStreamMuzzleFlash);

        }

        private static void CreateFluxBlades()
        {
            bladePrepObject = mainAssetBundle.LoadAsset<GameObject>("BladeSpawn");
            PrefabAPI.RegisterNetworkPrefab(bladePrepObject);

            bladeFireEffect = mainAssetBundle.LoadAsset<GameObject>("BladeFireEffect");
            AddNewEffectDef(bladeFireEffect);

            bladeExpireEffect = mainAssetBundle.LoadAsset<GameObject>("BladeExpire");
            AddNewEffectDef(bladeExpireEffect);

            #region Blue
            bladePrepObjectBlue = mainAssetBundle.LoadAsset<GameObject>("BladeSpawnBlue");
            PrefabAPI.RegisterNetworkPrefab(bladePrepObjectBlue);

            bladeFireEffectBlue = mainAssetBundle.LoadAsset<GameObject>("BladeFireEffectBlue");
            AddNewEffectDef(bladeFireEffectBlue);

            bladeExpireEffectBlue = mainAssetBundle.LoadAsset<GameObject>("BladeExpireBlue");
            AddNewEffectDef(bladeExpireEffectBlue);
            #endregion
        }
        private static void CreateChargeBeam()
        {
            
            chargeBeamTracerPrefab = mainAssetBundle.LoadAsset<GameObject>("TracerChargeBeam");
            //Debug.Log(chargeBeamTracerPrefab);
            //chargeBeamTracerPrefab.AddComponent<NetworkIdentity>();
            //chargeBeamTracerPrefab.AddComponent<EffectComponent>();
            AddNewEffectDef(chargeBeamTracerPrefab);

            chargeBeamMuzzleEffect = mainAssetBundle.LoadAsset<GameObject>("ChargeLightningBeam");
            PrefabAPI.RegisterNetworkPrefab(chargeBeamMuzzleEffect);

            beamMuzzleFlashEffect = mainAssetBundle.LoadAsset<GameObject>("MuzzleflashBeam");
            //PrefabAPI.RegisterNetworkPrefab(beamMuzzleFlashEffect);

            AddNewEffectDef(beamMuzzleFlashEffect);

            #region Blue
            chargeBeamTracerPrefabBlue = mainAssetBundle.LoadAsset<GameObject>("TracerChargeBeamBlue");
            //Debug.Log(chargeBeamTracerPrefab);
            //chargeBeamTracerPrefab.AddComponent<NetworkIdentity>();
            //chargeBeamTracerPrefab.AddComponent<EffectComponent>();
            AddNewEffectDef(chargeBeamTracerPrefabBlue);

            chargeBeamMuzzleEffectBlue = mainAssetBundle.LoadAsset<GameObject>("ChargeLightningBeamBlue");
            PrefabAPI.RegisterNetworkPrefab(chargeBeamMuzzleEffectBlue);

            beamMuzzleFlashEffectBlue = mainAssetBundle.LoadAsset<GameObject>("MuzzleflashBeamBlue");
            AddNewEffectDef(beamMuzzleFlashEffectBlue);
            #endregion

        }

        private static void CreateLightningSlash()
        {
            //lightningSwordChargePrefab = mainAssetBundle.LoadAsset<GameObject>("ChargeLightningSlash");
            //PrefabAPI.RegisterNetworkPrefab(lightningSwordChargePrefab);

            lightningBladePrefab = mainAssetBundle.LoadAsset<GameObject>("SlashBladeVFX");
            PrefabAPI.RegisterNetworkPrefab(lightningBladePrefab);
            spawnLightningBladeVFX = mainAssetBundle.LoadAsset<GameObject>("SpawnBlade");
            AddNewEffectDef(spawnLightningBladeVFX);
            lightningBladeSlashVFX = mainAssetBundle.LoadAsset<GameObject>("NemSlashSwing");
            AddNewEffectDef(lightningBladeSlashVFX);
            lightningBladeHitVFX = mainAssetBundle.LoadAsset<GameObject>("NemSlashImpact");
            AddNewEffectDef(lightningBladeHitVFX);
            //lightningBladeHitVFX = mainAssetBundle.LoadAsset<GameObject>("ChargeLightningSlash");
        }

        private static void CreateStaticField()
        {
           
            //Debug.Log("fieldindicator shader is " + matFieldIndicator.shader);

            staticFieldIndicatorPrefab = mainAssetBundle.LoadAsset<GameObject>("FieldAreaIndicator");
            PrefabAPI.RegisterNetworkPrefab(staticFieldIndicatorPrefab);

            aimFieldMuzzleEffect = mainAssetBundle.LoadAsset<GameObject>("AimFieldMuzzleEffect");
            PrefabAPI.RegisterNetworkPrefab(aimFieldMuzzleEffect);
            //staticFieldPrefab = mainAssetBundle.LoadAsset<GameObject>("StaticFieldPrefab");

            releaseFieldMuzzleEffect = mainAssetBundle.LoadAsset<GameObject>("StaticMuzzleFlash");
            PrefabAPI.RegisterNetworkPrefab(releaseFieldMuzzleEffect);
            //AddNewEffectDef(releaseFieldMuzzleEffect);

            #region Blue
            aimFieldMuzzleEffectBlue = mainAssetBundle.LoadAsset<GameObject>("AimFieldMuzzleEffectBlue");
            PrefabAPI.RegisterNetworkPrefab(aimFieldMuzzleEffectBlue);
            

           releaseFieldMuzzleEffectBlue = mainAssetBundle.LoadAsset<GameObject>("StaticMuzzleFlashBlue");
            PrefabAPI.RegisterNetworkPrefab(releaseFieldMuzzleEffectBlue);
            AddNewEffectDef(releaseFieldMuzzleEffectBlue);
            #endregion


        }

        private static void CreatePassiveMeter()
        {
            passiveMeter = mainAssetBundle.LoadAsset<GameObject>("DamageGrowthMeter");
            TextMeshProUGUI text = passiveMeter.GetComponentInChildren<TextMeshProUGUI>();
            text.font = Addressables.LoadAssetAsync<TMP_FontAsset>("RoR2/Base/Common/Fonts/Bombardier/tmpBombDropshadow.asset").WaitForCompletion();

            maxBuffFlashEffect = mainAssetBundle.LoadAsset<GameObject>("MaxBuffFlashEffect");
            AddNewEffectDef(maxBuffFlashEffect);

            maxBuffOffEffect = mainAssetBundle.LoadAsset<GameObject>("MaxBuffOffEffect");
            AddNewEffectDef(maxBuffOffEffect);

            #region Blue
            maxBuffFlashEffectBlue = mainAssetBundle.LoadAsset<GameObject>("MaxBuffFlashEffectBlue");
            AddNewEffectDef(maxBuffFlashEffectBlue);

            maxBuffOffEffectBlue = mainAssetBundle.LoadAsset<GameObject>("MaxBuffOffEffectBlue");
            AddNewEffectDef(maxBuffOffEffectBlue);
            #endregion
        }

        private static void CreateAOELightning()
        {

            purpleStormBoltEffect = mainAssetBundle.LoadAsset<GameObject>("LightningStrikeOrbPurple");
            AddNewEffectDef(purpleStormBoltEffect);

            stormMuzzleFlashEffect = mainAssetBundle.LoadAsset<GameObject>("StormMuzzleFlash");
            AddNewEffectDef(stormMuzzleFlashEffect);

            stormMuzzleFlashEffectBlue = mainAssetBundle.LoadAsset<GameObject>("StormMuzzleFlashBlue");
            AddNewEffectDef(stormMuzzleFlashEffectBlue);

            stormRangeIndicator = mainAssetBundle.LoadAsset<GameObject>("StormRangeIndicator");
            //PrefabAPI.RegisterNetworkPrefab(stormRangeIndicator);
            stormRangeIndicatorBlue = mainAssetBundle.LoadAsset<GameObject>("StormRangeIndicatorBlue");

            stormRangeIndicator.AddComponent<StormRangeIndicator>();
            stormRangeIndicatorBlue.AddComponent<StormRangeIndicator>();
        }
        private static void CreatePhotonShot()
        {
            photonImpact = mainAssetBundle.LoadAsset<GameObject>("PhotonImpact");
            photonDetonateExplosion = mainAssetBundle.LoadAsset<GameObject>("PhotonDetonateExplosion");
            photonTracer = mainAssetBundle.LoadAsset<GameObject>("PhotonTracer");
            photonMuzzleFlash = mainAssetBundle.LoadAsset<GameObject>("PhotonMuzzleFlash");
            photonChargeEffect = mainAssetBundle.LoadAsset<GameObject>("LaserCharge");
            PrefabAPI.RegisterNetworkPrefab(photonChargeEffect);

            AddNewEffectDef(photonImpact);
            AddNewEffectDef(photonDetonateExplosion);
            AddNewEffectDef(photonTracer);
            AddNewEffectDef(photonMuzzleFlash);

            /*photonImpactBlue = mainAssetBundle.LoadAsset<GameObject>("PhotonImpactBlue");
            photonImpactDetonateBlue = mainAssetBundle.LoadAsset<GameObject>("PhotonImpactDetonateBlue");
            photonTracerBlue = mainAssetBundle.LoadAsset<GameObject>("PhotonTracerBlue");
            photonMuzzleFlashBlue = mainAssetBundle.LoadAsset<GameObject>("PhotonMuzzleFlashBlue");

            AddNewEffectDef(photonImpactBlue);
            AddNewEffectDef(photonImpactDetonateBlue);
            AddNewEffectDef(photonTracerBlue);
            AddNewEffectDef(photonMuzzleFlashBlue); */

        }
        private static void CreateLightningDash()
        {
            dashVFXPrefab = mainAssetBundle.LoadAsset<GameObject>("QuickDashPrefab");
            PrefabAPI.RegisterNetworkPrefab(dashVFXPrefab);

            lightningStakeMuzzleObject = mainAssetBundle.LoadAsset<GameObject>("ChargeStake");
            PrefabAPI.RegisterNetworkPrefab(lightningStakeMuzzleObject);

            lightningStakeFlashEffect = mainAssetBundle.LoadAsset<GameObject>("StakeFlash");
            AddNewEffectDef(lightningStakeFlashEffect);

            lightningBallExplosionEffect = mainAssetBundle.LoadAsset<GameObject>("LightningBallExplosion");
            AddNewEffectDef(lightningBallExplosionEffect);

            dashEnterEffect = mainAssetBundle.LoadAsset<GameObject>("SurgeMuzzleFlash");
            AddNewEffectDef(dashEnterEffect);

            lightningBallMuzzleFlashEffect = mainAssetBundle.LoadAsset<GameObject>("BallMuzzleFlash");
            AddNewEffectDef(lightningBallMuzzleFlashEffect);

            plasmaActiveVFX = mainAssetBundle.LoadAsset<GameObject>("PlasmaActive");
            plasmaActiveVFXBlue = mainAssetBundle.LoadAsset<GameObject>("PlasmaActiveBlue");


            #region Blue
            dashVFXPrefabBlue = mainAssetBundle.LoadAsset<GameObject>("QuickDashPrefabBlue");
            PrefabAPI.RegisterNetworkPrefab(dashVFXPrefabBlue);

            lightningStakeMuzzleObjectBlue = mainAssetBundle.LoadAsset<GameObject>("ChargeStakeBlue");
            PrefabAPI.RegisterNetworkPrefab(lightningStakeMuzzleObjectBlue);

            lightningStakeFlashEffectBlue = mainAssetBundle.LoadAsset<GameObject>("StakeFlashBlue");
            AddNewEffectDef(lightningStakeFlashEffectBlue);

            lightningBallExplosionEffectBlue = mainAssetBundle.LoadAsset<GameObject>("LightningBallExplosionBlue");
            AddNewEffectDef(lightningBallExplosionEffectBlue);

            dashEnterEffectBlue = mainAssetBundle.LoadAsset<GameObject>("SurgeMuzzleFlashBlue");
            AddNewEffectDef(dashEnterEffectBlue);

            lightningBallMuzzleFlashEffectBlue = mainAssetBundle.LoadAsset<GameObject>("BallMuzzleFlashBlue");
            AddNewEffectDef(lightningBallMuzzleFlashEffectBlue);
            #endregion

            plasmaCrosshair = mainAssetBundle.LoadAsset<GameObject>("NemPlasmaUI");

        }

        #endregion


        #region Amp Assets

        private static void CreateChargeOrb()
        {
            chargeOrbObject = mainAssetBundle.LoadAsset<GameObject>("ChargeBall");
            chargeOrbFullObject = mainAssetBundle.LoadAsset<GameObject>("ChargeBallFull");
            chargeOrbRedObject = mainAssetBundle.LoadAsset<GameObject>("ChargeBallRed");
            chargeOrbFullRedObject = mainAssetBundle.LoadAsset<GameObject>("ChargeBallFullRed");

            PrefabAPI.RegisterNetworkPrefab(chargeOrbObject);
            PrefabAPI.RegisterNetworkPrefab(chargeOrbFullObject);
            PrefabAPI.RegisterNetworkPrefab(chargeOrbRedObject);
            PrefabAPI.RegisterNetworkPrefab(chargeOrbFullRedObject);
        }

        private static void CreateBoltVehicle()
        {
            boltVehicle = mainAssetBundle.LoadAsset<GameObject>("BoltVehicle");
            //boltVehicle = RoR2.LegacyResourcesAPI.Load<GameObject>("Prefabs/NetworkedObjects/FireballVehicle");

            boltVehicle.layer = LayerIndex.fakeActor.intVal;

            //adds boltvehicle to the bolt prefab finalizing the gameobject that will act as the primary enactor of the surge skill
            boltVehicle.AddComponent<SkillStates.BoltVehicle>();
            
            
            PrefabAPI.RegisterNetworkPrefab(boltVehicle);
        }


        private static void CreateSanded()
        {
            sandedMaterial = mainAssetBundle.LoadAsset<Material>("matIsSanded");

        }
        private static void CreateMelvin()
        {
            melvinPrefab = PrefabAPI.InstantiateClone(Addressables.LoadAssetAsync<GameObject>("RoR2/Base/ElectricWorm/ElectricWormMaster.prefab").WaitForCompletion(), "MelvinPrefab", true);
            
            CharacterMaster melvinMaster = melvinPrefab.GetComponent<CharacterMaster>();
        
            melvinBody = PrefabAPI.InstantiateClone(Addressables.LoadAssetAsync<GameObject>("RoR2/Base/ElectricWorm/ElectricWormBody.prefab").WaitForCompletion(), "MelvinBody", true);
            //var healthTracker = melvinBody.AddComponent<SkillStates.SkillComponents.WormHealthTracker>();

            var melvinCharBody = melvinBody.GetComponent<CharacterBody>();

            melvinBody.AddComponent<WormHealthTracker>();

            melvinCharBody.baseNameToken = prefix + "_AMP_BODY_SPECIAL_WORM_DISPLAY_NAME";
            //melvinCharBody.baseMaxHealth = healthTracker.summonerHealth * 3f; //melvinCharBody.baseMaxHealth;//melvinMinionOwner.ownerMaster.GetBody().baseMaxHealth * 3f;
            //melvinCharBody.statsDirty = true;

            melvinMaster.bodyPrefab = melvinBody;
            EntityStateMachine machine = EntityStateMachine.FindByCustomName(melvinBody, "Body");
            EntityStateMachine machine2 = EntityStateMachine.FindByCustomName(melvinBody, "Weapon");
            EntityStateMachine machine3 = EntityStateMachine.FindByCustomName(melvinBody, "Stance");

            //AmpPlugin.Destroy(machine2);
            //AmpPlugin.Destroy(machine3);
            //EntityStateMachine[] machines = melvinBody.GetComponents<EntityStateMachine>();

            //machine2.initialStateType = new SerializableEntityStateType(typeof(SkillStates.BaseStates.MelvinLeap));
            //machine.mainStateType = new SerializableEntityStateType(typeof(SkillStates.BaseStates.MelvinDeathState));
            melvinBody.GetComponent<CharacterDeathBehavior>().deathState = new SerializableEntityStateType(typeof(SkillStates.BaseStates.MelvinSpawn));

            melvinBody.GetComponent<TeamComponent>().hideAllyCardDisplay = true;
            WormBodyPositions2 bodyController = melvinBody.GetComponent<WormBodyPositions2>();
            bodyController.shouldFireBlastAttackOnImpact = false;
            bodyController.shouldFireMeatballsOnImpact = false;

            melvinBody.GetComponent<HealthComponent>().dontShowHealthbar = true;
           // bodyController.followDelay = 0f;

            melvinCharBody.baseDamage = 0f;

            AmpPlugin.Destroy(melvinBody.GetComponent<ContactDamage>());

 
            PrefabAPI.RegisterNetworkPrefab(melvinPrefab);

        }


        private static void CreateVortexBlackhole()
        {
           vortexBlackholePrefab = mainAssetBundle.LoadAsset<GameObject>("VortexSphere");
           vortexBlackholePrefab.AddComponent<SkillStates.RadialDamage>();
            //vortexBlackholePrefab.GetComponent<ProjectileDamage>().damage = 2f;

            vortexExplosionEffect = mainAssetBundle.LoadAsset<GameObject>("VortexExplosion");
            
            AddNewEffectDef(vortexExplosionEffect, Modules.StaticValues.vortexExplosionString);
            AddNewEffectDef(mainAssetBundle.LoadAsset<GameObject>("VortexSpawnExplosion"));

            ChildLocator childLocator = vortexBlackholePrefab.GetComponent<ChildLocator>();
            Transform vortexTransform = childLocator.FindChild("VortexHitbox");
            Modules.Prefabs.SetupHitbox(vortexBlackholePrefab, vortexTransform, "VortexHitbox"); 
            //mainAssetBundle.LoadAsset<GameObject>("VortexHitbox").gameObject.layer = LayerIndex.projectile.intVal;

            PrefabAPI.RegisterNetworkPrefab(vortexBlackholePrefab);
             
        }

        private static void CreateVortexMuzzle()
        {
            vortexMuzzleEffect = mainAssetBundle.LoadAsset<GameObject>("VortexMuzzleObject");
            vortexMuzzleEffectRed = mainAssetBundle.LoadAsset<GameObject>("VortexMuzzleObjectRed");
        }

        private static void CreateBulletPrep()
        {
            bulletPrepItem = mainAssetBundle.LoadAsset<GameObject>("Spike");
            //bulletPrepItem.AddComponent<NetworkIdentity>();
            

            PrefabAPI.RegisterNetworkPrefab(bulletPrepItem);
        }
     
        private static void CreateHeatExplosion()
        {
            AddNewEffectDef(mainAssetBundle.LoadAsset<GameObject>("HeatExplosionEffect"), Modules.StaticValues.plasmaExplosionString);
            plasmaMuzzle = mainAssetBundle.LoadAsset<GameObject>("PlasmaMuzzleEffect");
            
        }
        private static void CreateBulletMuzzle()
        {
            ampBulletMuzzleEffect = mainAssetBundle.LoadAsset<GameObject>("FerroshotMuzzleObject");

            PrefabAPI.RegisterNetworkPrefab(ampBulletMuzzleEffect);
        }

        private static void CreateChargePrefab()
        {
            chargeExplosionEffect = LoadEffect("ChargeExplosion", StaticValues.chargeExplosionString);
            chargeExplosionEffectRed = LoadEffect("ChargeExplosionRed", StaticValues.chargeExplosionString);


        }

        private static void CreateLightningCharge()
        {
           
            lightningMuzzleChargePrefab = mainAssetBundle.LoadAsset<GameObject>("HandSpark");
            lightningMuzzleChargePrefabRed = mainAssetBundle.LoadAsset<GameObject>("HandSparkRed");
            //AddNewEffectDef(lightningMuzzleChargePrefab);
        }

        private static void CreateWormEffects()
        {
            wormExplosionEffect = mainAssetBundle.LoadAsset<GameObject>("WormExplosionEffect");
            AddNewEffectDef(wormExplosionEffect);
        }
        
        private static void CreateStreamPrefab()
        {

            electricStreamEffect = mainAssetBundle.LoadAsset<GameObject>("ElectricityStream");
            electricStreamEffectRed = mainAssetBundle.LoadAsset<GameObject>("ElectricityStreamRed");

            PrefabAPI.RegisterNetworkPrefab(electricStreamEffect);
            PrefabAPI.RegisterNetworkPrefab(electricStreamEffectRed);
            electricMuzzleEffect = mainAssetBundle.LoadAsset<GameObject>("FulminationMuzzleObject");

            //mainAssetBundle.LoadAsset<Material>("lightningEffect");

            //on fulmination skill contact
            electricImpactEffect = LoadEffect("ElectricitySphere", null);
            electricImpactEffectRed = LoadEffect("ElectricitySphereRed", null);

            AddNewEffectDef(electricImpactEffect);
            AddNewEffectDef(electricImpactEffectRed);
            electricStreamEffectRed.AddComponent<NetworkIdentity>();
            electricStreamEffect.AddComponent<NetworkIdentity>();

        }

        private static void CreateBoltExitPrefab()
        {
            //electricExplosionEffect = LoadEffect("ElectricExplosion", "HenryBombExplosion");
            boltExitEffect = PrefabAPI.InstantiateClone(LegacyResourcesAPI.Load<GameObject>("Prefabs/Effects/MageLightningBombExplosion"), "boltExitEffect", true);
            boltExitEffect.AddComponent<NetworkIdentity>();

            boltExitEffectRed = PrefabAPI.InstantiateClone(LegacyResourcesAPI.Load<GameObject>("Prefabs/Effects/MageLightningBombExplosion"), "boltExitEffectRed", true);
            boltExitEffectRed.AddComponent<NetworkIdentity>();

            AddNewEffectDef(boltExitEffect);
            AddNewEffectDef(boltExitEffectRed);

            Transform boltExitTransform = boltExitEffectRed.transform;
            foreach(Transform child in boltExitTransform)
            {
                switch (child.name)
                {
                    case "Matrix, Dynamic":
                        var main = child.GetComponent<ParticleSystem>().main;
                        main.startColor = redLightningColor;
                        child.GetComponent<ParticleSystemRenderer>().trailMaterial = matLightningLongRed;
                        break;
                    case "Matrix, Billboard":
                        child.GetComponent<ParticleSystemRenderer>().SetMaterial(matLightningMatrixRed);
                        break;
                    case "Point light":
                        child.GetComponent<Light>().color = redLightningColor;
                        break;
                    case "Flash, Directional":
                        var main2 = child.GetComponent<ParticleSystem>().main;
                        main2.startColor = redLightningColor;
                        break;
                    case "Matrix, Directional":
                        child.GetComponent<ParticleSystemRenderer>().SetMaterial(matDirectionalMatrixRed);
                        break;
                    case "Flash, Blue":
                        var main3 = child.GetComponent<ParticleSystem>().main;
                        main3.startColor = darkRedLightningColor;
                        break;
                }
            }
        }
        
        private static void CreatePulseBlastPrefab()
        {
            pulseBlastEffect = mainAssetBundle.LoadAsset<GameObject>("PulseBlast");
            pulseBlastEffect.AddComponent<NetworkIdentity>();

            pulseBlastEffectRed = mainAssetBundle.LoadAsset<GameObject>("PulseBlastRed");
            pulseBlastEffectRed.AddComponent<NetworkIdentity>();
           
            pulseLightningCover = mainAssetBundle.LoadAsset<GameObject>("PulseCover"); 


            pulseMuzzleEffect = mainAssetBundle.LoadAsset<GameObject>("PulseMuzzleFlash");
            pulseMuzzleEffectRed = mainAssetBundle.LoadAsset<GameObject>("PulseMuzzleFlashRed");

            AddNewEffectDef(pulseBlastEffect, null, true);

            AddNewEffectDef(pulseBlastEffectRed, null, true);

            PrefabAPI.RegisterNetworkPrefab(pulseMuzzleEffect);
            PrefabAPI.RegisterNetworkPrefab(pulseMuzzleEffectRed);

            PrefabAPI.RegisterNetworkPrefab(pulseLightningCover);

        }

        private static void CreateBoltEnterPrefab()
        {
            boltEnterEffect = mainAssetBundle.LoadAsset<GameObject>("BoltEnter");
            boltEnterEffect.AddComponent<NetworkIdentity>();
            boltEnterEffect.AddComponent<VFXAttributes>();
            boltEnterEffect.AddComponent<EffectComponent>();

            boltEnterEffectRed = mainAssetBundle.LoadAsset<GameObject>("BoltEnterRed");
            boltEnterEffectRed.AddComponent<NetworkIdentity>();
            boltEnterEffectRed.AddComponent<VFXAttributes>();
            boltEnterEffectRed.AddComponent<EffectComponent>();


            AddNewEffectDef(boltEnterEffect);
            AddNewEffectDef(boltEnterEffectRed);

        }
         


        //instantiate voltaic bombardment main effect as copy of royal capacitor's effect
        private static void CreateLightningPrefab()
        {
            lightningStrikePrefab = PrefabAPI.InstantiateClone(LegacyResourcesAPI.Load<GameObject>("Prefabs/Effects/ImpactEffects/LightningStrikeImpact"), "lightningStrike", true);
            lightningStrikePrefab.AddComponent<NetworkIdentity>();
            //lightningStrikePrefab.GetComponent<EffectComponent>().soundName = "Play_item_use_lighningArm";

            lightningStrikePrefabRed = PrefabAPI.InstantiateClone(LegacyResourcesAPI.Load<GameObject>("Prefabs/Effects/ImpactEffects/LightningStrikeImpact"), "lightningStrikeRed", true);
            lightningStrikePrefabRed.AddComponent<NetworkIdentity>();
            //lightningStrikePrefabRed.GetComponent<EffectComponent>().soundName = "Play_item_use_lighningArm";

            Transform redLightningTransform = lightningStrikePrefabRed.transform;
            foreach (Transform child in redLightningTransform)
            {
                switch (child.name)
                {
                    case "PostProcess":
                        child.GetComponent<PostProcessVolume>().sharedProfile = mainAssetBundle.LoadAsset<PostProcessProfile>("ppLocalLightningRed");//Addressables.LoadAssetAsync<PostProcessProfile>("RoR2/Base/title/ppLocalTPActivation.asset").WaitForCompletion();
                        break;
                    case "Ring":
                        child.GetComponent<ParticleSystemRenderer>().SetMaterial(matLightningLongRed);
                        break;
                    case "Sphere":
                        child.GetComponent<ParticleSystemRenderer>().SetMaterial(matLightningSphereRed);
                        break;
                    case "Point light":
                        child.GetComponent<Light>().color = redLightningColor;
                        break;
                    case "LightningRibbon":
                        child.GetComponent<ParticleSystemRenderer>().trailMaterial = matLightningStrikeRed;
                        break;
                    case "Flash Lines":
                        var main = child.GetComponent<ParticleSystem>().main;
                        main.startColor = redLightningColor;
                        break;
                    case "Flash":
                        var main2 = child.GetComponent<ParticleSystem>().main;
                        main2.startColor = darkRedLightningColor;
                        break;

                }
            }
            // lightningStrikePrefab.GetComponent<ParticleSystem>().scalingMode = ParticleSystemScalingMode.Hierarchy;

            strikeBlinkPrefab = mainAssetBundle.LoadAsset<GameObject>("StrikeBlinkEffect");
            strikeBlastPrefab = mainAssetBundle.LoadAsset<GameObject>("StrikeLandEffect");
            strikeHover = mainAssetBundle.LoadAsset<GameObject>("StrikeHover");
            strikeBoltPrefab = mainAssetBundle.LoadAsset<GameObject>("StrikeBoltPrefab");


            PrefabAPI.RegisterNetworkPrefab(strikeBoltPrefab);

            AddNewEffectDef(strikeBlastPrefab);
            AddNewEffectDef(strikeBlinkPrefab);
            AddNewEffectDef(lightningStrikePrefab);
            AddNewEffectDef(lightningStrikePrefabRed);

        }

        //instantiates chain lightning effect 
        private static void CreateChainPrefab()
        {

            electricChainEffect = mainAssetBundle.LoadAsset<GameObject>("ChainLightningEffect");
            electricChainEffect.AddComponent<NetworkIdentity>();

            electricChainEffectRed = mainAssetBundle.LoadAsset<GameObject>("ChainLightningEffectRed");
            electricChainEffectRed.AddComponent<NetworkIdentity>();

            AddNewEffectDef(electricChainEffect);
            AddNewEffectDef(electricChainEffectRed);




        }

        #endregion

        private static GameObject CreateTracer(string originalTracerName, string newTracerName)
        {
            if (RoR2.LegacyResourcesAPI.Load<GameObject>("Prefabs/Effects/Tracers/" + originalTracerName) == null) return null;

            GameObject newTracer = PrefabAPI.InstantiateClone(LegacyResourcesAPI.Load<GameObject>("Prefabs/Effects/Tracers/" + originalTracerName), newTracerName, true);

            if (!newTracer.GetComponent<EffectComponent>()) newTracer.AddComponent<EffectComponent>();
            if (!newTracer.GetComponent<VFXAttributes>()) newTracer.AddComponent<VFXAttributes>();
            if (!newTracer.GetComponent<NetworkIdentity>()) newTracer.AddComponent<NetworkIdentity>();

            newTracer.GetComponent<Tracer>().speed = 250f;
            newTracer.GetComponent<Tracer>().length = 50f;

            AddNewEffectDef(newTracer);

            return newTracer;
        }

        internal static NetworkSoundEventDef CreateNetworkSoundEventDef(string eventName)
        {
            NetworkSoundEventDef networkSoundEventDef = ScriptableObject.CreateInstance<NetworkSoundEventDef>();
            networkSoundEventDef.akId = AkSoundEngine.GetIDFromString(eventName);
            networkSoundEventDef.eventName = eventName;

            networkSoundEventDefs.Add(networkSoundEventDef);

            return networkSoundEventDef;
        }

        internal static void ConvertAllRenderersToHopooShader(GameObject objectToConvert)
        {
            if (!objectToConvert) return;

            foreach (MeshRenderer i in objectToConvert.GetComponentsInChildren<MeshRenderer>())
            {
                if (i)
                {
                    if (i.material)
                    {
                        i.material.shader = hotpoo;
                    }
                }
            }

            foreach (SkinnedMeshRenderer i in objectToConvert.GetComponentsInChildren<SkinnedMeshRenderer>())
            {
                if (i)
                {
                    if (i.material)
                    {
                        i.material.shader = hotpoo;
                    }
                }
            }
        }

        internal static CharacterModel.RendererInfo[] SetupRendererInfos(GameObject obj)
        {
            MeshRenderer[] meshes = obj.GetComponentsInChildren<MeshRenderer>();
            CharacterModel.RendererInfo[] rendererInfos = new CharacterModel.RendererInfo[meshes.Length];

            for (int i = 0; i < meshes.Length; i++)
            {
                rendererInfos[i] = new CharacterModel.RendererInfo
                {
                    defaultMaterial = meshes[i].material,
                    renderer = meshes[i],
                    defaultShadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On,
                    ignoreOverlays = false
                };
            }

            return rendererInfos;
        }

        internal static Texture LoadCharacterIcon(string characterName)
        {
            return mainAssetBundle.LoadAsset<Texture>("tex" + characterName + "Icon");
        }

        internal static GameObject LoadCrosshair(string crosshairName)
        {
            if (RoR2.LegacyResourcesAPI.Load<GameObject>("Prefabs/Crosshair/" + crosshairName + "Crosshair") == null) return RoR2.LegacyResourcesAPI.Load<GameObject>("Prefabs/Crosshair/StandardCrosshair");
            return RoR2.LegacyResourcesAPI.Load<GameObject>("Prefabs/Crosshair/" + crosshairName + "Crosshair");
        }

        private static GameObject LoadEffect(string resourceName)
        {
            return LoadEffect(resourceName, "", false);
        }

        private static GameObject LoadEffect(string resourceName, string soundName)
        {
            return LoadEffect(resourceName, soundName, false);
        }

        private static GameObject LoadEffect(string resourceName, bool parentToTransform)
        {
            return LoadEffect(resourceName, "", parentToTransform);
        }

        private static GameObject LoadEffect(string resourceName, string soundName, bool parentToTransform)
        {
            bool assetExists = false;
            for (int i = 0; i < assetNames.Length; i++)
            {
                if (assetNames[i].Contains(resourceName.ToLower()))
                {
                    assetExists = true;
                    i = assetNames.Length;
                }
            }

            if (!assetExists)
            {
                Debug.LogError("Failed to load effect: " + resourceName + " because it does not exist in the AssetBundle");
                return null;
            }

            GameObject newEffect = mainAssetBundle.LoadAsset<GameObject>(resourceName);

            newEffect.AddComponent<DestroyOnTimer>().duration = 12;
            newEffect.AddComponent<NetworkIdentity>();
            newEffect.AddComponent<VFXAttributes>().vfxPriority = VFXAttributes.VFXPriority.Always;
            var effect = newEffect.AddComponent<EffectComponent>();
            effect.applyScale = false;
            effect.effectIndex = EffectIndex.Invalid;
            effect.parentToReferencedTransform = parentToTransform;
            effect.positionAtReferencedTransform = true;
            effect.soundName = soundName;

            AddNewEffectDef(newEffect, soundName);

            return newEffect;
        }

        private static void AddNewEffectDef(GameObject effectPrefab)
        {
            EffectDef newEffectDef = new EffectDef();
            newEffectDef.prefab = effectPrefab;
            newEffectDef.prefabEffectComponent = effectPrefab.GetComponent<EffectComponent>();
            newEffectDef.prefabName = effectPrefab.name;
            newEffectDef.prefabVfxAttributes = effectPrefab.GetComponent<VFXAttributes>();
            //newEffectDef.spawnSoundEventName = soundName;

            effectDefs.Add(newEffectDef);
        }

        private static void AddNewEffectDef(GameObject effectPrefab, string soundName)
        {
            EffectDef newEffectDef = new EffectDef();
            newEffectDef.prefab = effectPrefab;
            newEffectDef.prefabEffectComponent = effectPrefab.GetComponent<EffectComponent>();
            newEffectDef.prefabName = effectPrefab.name;
            newEffectDef.prefabVfxAttributes = effectPrefab.GetComponent<VFXAttributes>();
            newEffectDef.spawnSoundEventName = soundName;

            effectDefs.Add(newEffectDef);
        }

        private static void AddNewEffectDef(GameObject effectPrefab, string soundName, bool removeSound)
        {
            EffectDef newEffectDef = new EffectDef();
            newEffectDef.prefab = effectPrefab;
            newEffectDef.prefabEffectComponent = effectPrefab.GetComponent<EffectComponent>();
            newEffectDef.prefabName = effectPrefab.name;
            newEffectDef.prefabVfxAttributes = effectPrefab.GetComponent<VFXAttributes>();
            if (removeSound)
            {
                newEffectDef.spawnSoundEventName = soundName;
            }


            effectDefs.Add(newEffectDef);
        }

        public static Material CreateMaterial(string materialName, float emission, Color emissionColor, float normalStrength)
        {
         /*   if (!commandoMat) commandoMat = RoR2.LegacyResourcesAPI.Load<GameObject>("Prefabs/CharacterBodies/CommandoBody").GetComponentInChildren<CharacterModel>().baseRendererInfos[0].defaultMaterial;

            Material mat = UnityEngine.Object.Instantiate<Material>(commandoMat);
            Material tempMat = Assets.mainAssetBundle.LoadAsset<Material>(materialName);


            if (!tempMat)
            {
                Debug.LogError("Failed to load material: " + materialName + " - Check to see that the name in your Unity project matches the one in this code");
                return commandoMat;
            }

            mat.name = materialName;
            mat.SetColor("_Color", tempMat.GetColor("_Color"));
            mat.SetTexture("_MainTex", tempMat.GetTexture("_MainTex"));
            mat.SetColor("_EmColor", emissionColor);
            mat.SetFloat("_EmPower", emission);
            //mat.SetTexture("_EmTex", tempMat.GetTexture("_EmissionMap"));
            mat.SetTexture("_EmTex", mainAssetBundle.LoadAsset<Texture>("texEmission"));
            
            if (!mainAssetBundle.LoadAsset<Texture>("texEmission"))
            {
                Debug.Log("No Emission Map");
            }
            mat.SetFloat("_NormalStrength", normalStrength);
            //mat.shader = LegacyResourcesAPI.Load<Shader>("shaders/deferred/hgstandard"); */
            Material mat = Assets.mainAssetBundle.LoadAsset<Material>(materialName);

            mat.shader = LegacyResourcesAPI.Load<Shader>("shaders/deferred/hgstandard");
            return mat;
        }

        public static Material CreateVFXMaterial(string materialName)
        {
            Material mat = Assets.mainAssetBundle.LoadAsset<Material>(materialName);
            //Debug.Log(mat.shader.name);
            mat.shader = LegacyResourcesAPI.Load<Shader>("shaders/fx/hgcloudremap");
            return mat;
        }

        public static Material CreateStandardMaterial(string materialName)
        {
            Material mat = Assets.mainAssetBundle.LoadAsset<Material>(materialName);

            mat.shader = LegacyResourcesAPI.Load<Shader>("shaders/deferred/HGstandard");
            return mat;
        }
        public static Material CreateIntersectMaterial(string materialName)
        {
            Material mat = Assets.mainAssetBundle.LoadAsset<Material>(materialName);

            mat.shader = LegacyResourcesAPI.Load<Shader>("shaders/fx/hgintersectioncloudremap");
            return mat;
        }

        public static Material CreateDecalMaterial(string materialName)
        {
            Material mat = Assets.mainAssetBundle.LoadAsset<Material>(materialName);

            mat.shader = Addressables.LoadAssetAsync<Shader>("Decalicious/DecaliciousDeferredDecal.shader").WaitForCompletion();
            return mat;
        }

        public static Material CreateBrightenMaterial(string materialName)
        {
            Material mat = Assets.mainAssetBundle.LoadAsset<Material>(materialName);

            mat.shader = LegacyResourcesAPI.Load<Shader>("Shaders/UI/HGUIOverbrighten");
            return mat;
        }

        public static Material CreateDistortionMaterial(string materialName)
        {
            Material mat = Assets.mainAssetBundle.LoadAsset<Material>(materialName);

            mat.shader = LegacyResourcesAPI.Load<Shader>("Shaders/FX/HGDistortion");
            return mat;
        }


        public static Material CreateVFXMaterial(Material mat)
        {
            mat.shader = LegacyResourcesAPI.Load<Shader>("shaders/fx/hgcloudremap");
            return mat;
        }

        public static Material CreateMaterial(string materialName)
        {
            return Assets.CreateMaterial(materialName, 0f);
        }

        public static Material CreateMaterial(string materialName, float emission)
        {
            return Assets.CreateMaterial(materialName, emission, Color.white);
        }

        public static Material CreateMaterial(string materialName, float emission, Color emissionColor)
        {
            return Assets.CreateMaterial(materialName, emission, emissionColor, 0f);
        }
    }
}