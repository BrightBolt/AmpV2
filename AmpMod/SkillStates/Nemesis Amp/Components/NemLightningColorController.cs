using UnityEngine;
using RoR2.Projectile;
using RoR2;
using AmpMod;
using AmpMod.Modules;

namespace AmpMod.SkillStates.Nemesis_Amp.Components
{
    public class NemLightningColorController : MonoBehaviour
    {
        public bool isBlue;
        private CharacterBody body;
        private CharacterModel model;

        [Header("Death/Spawn Effects")]
        public GameObject deathExplosionVFX;
        public Material deathOverlay;
        public GameObject intialSpawnVFX;
        public GameObject spawnRingVFX;

        [Header("Passive Effects")]
        public GameObject buffOnVFX;
        public GameObject buffOffVFX;
        public Material buffOverlayMat;

        [Header("Fulmination Effects")]
        public GameObject streamVFX;
        public GameObject streamMuzzleFlashVFX;
        public GameObject streamMuzzleVFX;
        public GameObject streamChainVFX;
        public GameObject streamImpactVFX;
        public GameObject streamReticlePrefab;

        [Header("Lorentz Blades Effects")]
        public GameObject bladePrepVFX;
        public GameObject bladePrefab;
        public GameObject bladeFireVFX;

        [Header("Furious Spark Effects")]
        public GameObject beamMuzzleVFX;
        public GameObject beamChargeVFX;
        public GameObject beamObject;

        [Header("Static Field Effects")]
        public GameObject fieldPrefab;
        public GameObject fieldMuzzleVFX;
        public GameObject fieldAimVFX;

        [Header("Quicksurge Effects")]
        public GameObject dashEnterExitVFX;
        public GameObject lightningStakePrefab;
        public GameObject lightningStakeMuzzleVFX;
        public GameObject chargeLightningStakeVFX;
        public GameObject lightningStakeFlashVFX;
        public GameObject dashPrefab;
        public GameObject dashPrimaryVFX;

        [Header("Voltaic Onslaught Effects")]
        public GameObject specialBoltVFX;
        public GameObject specialMuzzleVFX;

        [Header("Photon Shot Effects")]
        public GameObject specialBeamTracer;
        public GameObject specialBeamImpact;
        public GameObject specialBeamImpactDetonate;
        public GameObject specialBeamMuzzleFlash;


        private void Awake()
        {
            this.body = base.GetComponent<CharacterBody>();
            this.model = base.GetComponentInChildren<CharacterModel>();


        }

        private void Start()
        {
            isBlue = this.model.GetComponent<ModelSkinController>().skins[this.body.skinIndex].nameToken == AmpPlugin.developerPrefix + "_NEMAMP_BODY_MASTERY_SKIN_NAME" && !Config.NemOriginPurpleLightning.Value;
            
            

            if (isBlue)
            {
                #region Death
                deathExplosionVFX = Asset.deathExplosionEffectBlue;    
                deathOverlay = Asset.matDeathOverlayBlue;
                #endregion

                #region Gathering Storm
                buffOffVFX = Asset.maxBuffOffEffectBlue;
                buffOnVFX = Asset.maxBuffFlashEffectBlue;
                buffOverlayMat = Asset.buffOverlayMatBlue;
                #endregion

                #region Fulmination
                streamVFX = Asset.lightningStreamEffectBlue;
                streamMuzzleFlashVFX = Asset.lightningStreamMuzzleFlashBlue;
                streamMuzzleVFX = Asset.lightningStreamMuzzleEffectBlue;
                streamChainVFX = Asset.lightningStreamChainEffectPrefabBlue;
                streamReticlePrefab = Asset.lightningCrosshairBlue;
                streamImpactVFX = Asset.lightningStreamImpactEffectBlue;
                #endregion

                #region Lorentz Blades              
                bladePrepVFX = Asset.bladePrepObjectBlue;
                bladeFireVFX = Asset.bladeFireEffectBlue;
                bladePrefab = Projectiles.bladeProjectilePrefabBlue;
                #endregion

                #region Furious Spark
                beamMuzzleVFX = Asset.beamMuzzleFlashEffectBlue;
                beamChargeVFX = Asset.chargeBeamMuzzleEffectBlue;
                beamObject = Asset.chargeBeamTracerPrefabBlue;
                #endregion

                #region Static Field
                fieldAimVFX = Asset.aimFieldMuzzleEffectBlue;
                fieldMuzzleVFX = Asset.releaseFieldMuzzleEffectBlue;
                fieldPrefab = Projectiles.fieldProjectilePrefabBlue;
                #endregion

                #region Voidsurge
                dashEnterExitVFX = Asset.dashEnterEffectBlue;
                dashPrefab = Asset.dashVFXPrefabBlue;
                lightningStakePrefab = Projectiles.lightningStakePrefabBlue;
                lightningStakeMuzzleVFX = Asset.lightningBallMuzzleFlashEffectBlue;
                lightningStakeFlashVFX = Asset.lightningStakeFlashEffectBlue;
                chargeLightningStakeVFX = Asset.lightningStakeMuzzleObjectBlue;
                dashPrimaryVFX = Asset.plasmaActiveVFXBlue;
                #endregion

                #region Voltaic Onslaught
                specialMuzzleVFX = Asset.stormMuzzleFlashEffectBlue;
                specialBoltVFX = LegacyResourcesAPI.Load<GameObject>("Prefabs/Effects/ImpactEffects/SimpleLightningStrikeImpact");
                #endregion

                #region Photon Shot 
                specialBeamImpact = Asset.photonImpactBlue;
                specialBeamImpactDetonate = Asset.photonImpactDetonateBlue;
                specialBeamMuzzleFlash = Asset.photonMuzzleFlashBlue;
                specialBeamTracer = Asset.photonTracerBlue;
                #endregion
            }
            else
            {
                #region Death
                deathExplosionVFX = Asset.deathExplosionEffect;
                deathOverlay = Asset.matDeathOverlay;
                #endregion

                #region Gathering Storm
                buffOffVFX = Asset.maxBuffOffEffect;
                buffOnVFX = Asset.maxBuffFlashEffect;
                buffOverlayMat = Asset.buffOverlayMat;
                #endregion

                #region Fulmination
                streamVFX = Asset.lightningStreamEffect;
                streamMuzzleFlashVFX = Asset.lightningStreamMuzzleFlash;
                streamMuzzleVFX = Asset.lightningStreamMuzzleEffect;
                streamChainVFX = Asset.lightningStreamChainEffectPrefab;
                streamReticlePrefab = Asset.lightningCrosshair;
                streamImpactVFX = Asset.lightningStreamImpactEffect;
                #endregion

                #region Lorentz Blades
                bladePrepVFX = Asset.bladePrepObject;
                bladeFireVFX = Asset.bladeFireEffect;
                bladePrefab = Projectiles.bladeProjectilePrefab;
                #endregion

                #region Furious Spark
                beamMuzzleVFX = Asset.beamMuzzleFlashEffect;
                beamChargeVFX = Asset.chargeBeamMuzzleEffect;
                beamObject = Asset.chargeBeamTracerPrefab;
                #endregion

                #region Static Field
                fieldAimVFX = Asset.aimFieldMuzzleEffect;
                fieldMuzzleVFX = Asset.releaseFieldMuzzleEffect;
                fieldPrefab = Projectiles.fieldProjectilePrefab;
                #endregion

                #region Voidsurge
                dashEnterExitVFX = Asset.dashEnterEffect;
                dashPrefab = Asset.dashVFXPrefab;
                lightningStakePrefab = Projectiles.lightningStakePrefab;
                lightningStakeMuzzleVFX = Asset.lightningBallMuzzleFlashEffect;
                lightningStakeFlashVFX = Asset.lightningStakeFlashEffect;
                chargeLightningStakeVFX = Asset.lightningStakeMuzzleObject;
                dashPrimaryVFX = Asset.plasmaActiveVFX;
                #endregion

                #region Voltaic Onslaught
                specialMuzzleVFX = Asset.stormMuzzleFlashEffect;
                specialBoltVFX = Asset.purpleStormBoltEffect;
                #endregion

                #region Photon Shot 
                specialBeamImpact = Asset.photonImpact;
                specialBeamImpactDetonate = Asset.photonDetonateExplosion;
                specialBeamMuzzleFlash = Asset.photonMuzzleFlash;
                specialBeamTracer = Asset.photonTracer;
                #endregion
            }
        }

    }
}

