using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using RoR2.Projectile;
using RoR2;

namespace AmpMod.Modules
{
    internal class AmpLightningController : MonoBehaviour
    {
        public bool isRed;
        private CharacterBody body;
        private CharacterModel model;

        public GameObject chargeOrb;
        public GameObject chargeOrbFull;
        public GameObject surgeEnter;
        public GameObject fulminationEffect;
        public GameObject fulminationHitEffect;
        public GameObject lorentzProjectile;
        public GameObject fulminationChainEffect;
        public GameObject vortexMuzzle;
        public GameObject vortexProjectile;
        public GameObject chargeExplosion;
        public GameObject surgeVehicle;
        public GameObject swingEffect;
        public GameObject swingHitEffect;
        public GameObject surgeExitEffect;
        public GameObject bombardmentEffect;
        public GameObject bombardmentMuzzleEffect;
        public GameObject pulseLeapEffect;
        public GameObject pulseMuzzleEffect;
        public GameObject swordSparks;



        private void Awake()
        {
            this.body = base.GetComponent<CharacterBody>();
            this.model = base.GetComponentInChildren<CharacterModel>();
           

        }
        private void Start()
        {
            isRed = this.model.GetComponent<ModelSkinController>().skins[this.body.skinIndex].nameToken == AmpPlugin.developerPrefix + "_AMP_BODY_MASTERY_SKIN_NAME" && !Config.RedSpriteBlueLightning.Value;

            if (isRed) {
                surgeVehicle = Asset.boltVehicle;
                surgeVehicle.GetComponentInChildren<ParticleSystemRenderer>().trailMaterial = Asset.matRedLightning;
                Light light = surgeVehicle.GetComponentInChildren<Light>();
                light.color = new Color32(191, 2, 0, 255);
  
                surgeEnter = Asset.boltEnterEffectRed;
                surgeExitEffect = Asset.boltExitEffectRed;

                //vortexMuzzle = Assets.vortexMuzzleEffectRed;
                vortexMuzzle = Asset.vortexMuzzleEffect;

                lorentzProjectile = Projectiles.ferroshotPrefab;
                lorentzProjectile.GetComponent<ProjectileController>().ghostPrefab.GetComponentInChildren<TrailRenderer>().SetMaterial(Asset.matRedTrail);
                
                fulminationEffect = Asset.electricStreamEffectRed;
                fulminationHitEffect = Asset.electricImpactEffectRed;
                fulminationChainEffect = Asset.electricChainEffectRed;

                chargeOrb = Asset.chargeOrbRedObject;
                chargeOrbFull = Asset.chargeOrbFullRedObject;
                chargeExplosion = Asset.chargeExplosionEffectRed;
                swingEffect = Asset.swordSwingEffectRed;
                swingHitEffect = Asset.swordHitImpactEffectRed;

                pulseLeapEffect = Asset.pulseBlastEffectRed;
                pulseMuzzleEffect = Asset.pulseMuzzleEffectRed;

                bombardmentMuzzleEffect = Asset.lightningMuzzleChargePrefabRed;
                bombardmentEffect = Asset.lightningStrikePrefabRed;


            } 
            else
            {
                surgeVehicle = Asset.boltVehicle;
                surgeVehicle.GetComponentInChildren<ParticleSystemRenderer>().trailMaterial = Asset.matBlueLightning;
                Light light = surgeVehicle.GetComponentInChildren<Light>();
                light.color = new Color32(16, 192, 255, 0);
                surgeEnter = Asset.boltEnterEffect;
                surgeExitEffect = Asset.boltExitEffect;

                lorentzProjectile = Projectiles.ferroshotPrefab;
                lorentzProjectile.GetComponent<ProjectileController>().ghostPrefab.GetComponentInChildren<TrailRenderer>().SetMaterial(Asset.matBlueTrail);

                vortexMuzzle = Asset.vortexMuzzleEffect;

                fulminationEffect = Asset.electricStreamEffect;
                fulminationHitEffect = Asset.electricImpactEffect;
                fulminationChainEffect = Asset.electricChainEffect;

                chargeOrb = Asset.chargeOrbObject;
                chargeOrbFull = Asset.chargeOrbFullObject;
                chargeExplosion = Asset.chargeExplosionEffect;
                swingEffect = Asset.swordSwingEffect;
                swingHitEffect = Asset.swordHitImpactEffect;

                pulseLeapEffect = Asset.pulseBlastEffect;
                pulseMuzzleEffect = Asset.pulseMuzzleEffect;

                bombardmentMuzzleEffect = Asset.lightningMuzzleChargePrefab;
                bombardmentEffect = Asset.lightningStrikePrefab;


            }

        }
    }
}
