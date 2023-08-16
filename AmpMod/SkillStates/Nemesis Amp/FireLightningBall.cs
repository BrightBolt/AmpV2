﻿using RoR2;
using EntityStates;
using RoR2.Projectile;
using UnityEngine;
using UnityEngine.Networking;
using AmpMod.Modules;
using AmpMod.SkillStates.Nemesis_Amp.Components;

namespace AmpMod.SkillStates.Nemesis_Amp
{
    public class FireLightningBall : BaseSkillState
    {
        private GameObject projectilePrefab;
        private string shootString = StaticValues.plasmaFireString;
        private bool hasFired;
        private NemLightningColorController lightningController;
        public QuickDash src;
        private ChildLocator childLocator;
        private GameObject muzzleFlashPrefab;
        private int growthBuffCount;
        private float damageCoefficient = Modules.StaticValues.lightningBallDamageCoefficient;
        private StackDamageController stackDamageController;
        private float duration = .2f;
        private float waitDuration = .3f;
        private Transform muzzleTransform;
        private Transform muzzleObjectTransform;
        private Ray aimRay;

        public override void OnEnter()
        {
            base.OnEnter();
            childLocator = base.GetModelChildLocator();
            //base.characterBody.SetAimTimer(2f);
            this.aimRay = base.GetAimRay();
            base.StartAimMode(this.aimRay, 3f, true);
            stackDamageController = base.GetComponent<StackDamageController>();
            growthBuffCount = base.characterBody.GetBuffCount(Modules.Buffs.damageGrowth);
            base.PlayAnimation("Gesture, Override", "FirePlasmaBall", "BaseSkill.playbackRate", 4*this.duration);
            muzzleTransform = childLocator.FindChild("HandR");
            Util.PlaySound(shootString, base.gameObject);
            lightningController = base.GetComponent<NemLightningColorController>();
            muzzleFlashPrefab = lightningController.lightningBallMuzzleVFX;
            projectilePrefab = lightningController.lightningBallPrefab;
            
        }
         
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (base.isAuthority && !hasFired)
            {
                hasFired = true;
                Fire();
            }
            
            if (this.hasFired && this.fixedAge >= duration)
            {
                //Debug.Log("exiting");
                this.outer.SetNextStateToMain();
            }
        }
        private void Fire()
        {
           
            if (base.isAuthority)
            {
                Ray aimRay = base.GetAimRay();
                //Debug.Log(projectilePrefab);
                if (projectilePrefab)
                {
                    float calcedDamage = damageCoefficient + (damageCoefficient * growthBuffCount * Modules.StaticValues.growthDamageCoefficient);
                    //projectilePrefab.GetComponent<ProjectileController>().teamFilter = base.GetComponent<TeamFilter>();
                    //Debug.Log(calcedDamage);
                    FireProjectileInfo fireProjectileInfo = new FireProjectileInfo
                    {
                        projectilePrefab = this.projectilePrefab,
                        position = aimRay.origin,
                        rotation = Util.QuaternionSafeLookRotation(aimRay.direction),
                        owner = base.gameObject,
                        damage = base.characterBody.damage * calcedDamage,
                        crit = base.RollCrit(),
                    };
                    ModifyProjectile(ref fireProjectileInfo);
                    ProjectileManager.instance.FireProjectile(fireProjectileInfo);
                }

                //play shoot sound
                Util.PlaySound(shootString, base.gameObject);

            }

            //EffectManager.SimpleMuzzleFlash(muzzleFlashPrefab, base.gameObject, "HandR", true);
            muzzleObjectTransform = UnityEngine.Object.Instantiate(muzzleFlashPrefab, muzzleTransform).transform;
            stackDamageController.newSkillUsed = this;
            stackDamageController.resetComboTimer();
        }
        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.PrioritySkill;
        }

        protected virtual void ModifyProjectile(ref FireProjectileInfo projectileInfo)
        {
        }

        public override void OnExit()
        {
            base.OnExit();
            //resets primary back to fulmination
            if (base.skillLocator.primary)
            {
                base.skillLocator.primary.UnsetSkillOverride(QuickDash.src, QuickDash.primaryOverrideSkillDef, GenericSkill.SkillOverridePriority.Contextual);
            }

            if (muzzleObjectTransform)
            {
                Destroy(muzzleObjectTransform.gameObject);
            }
        }
    }
}
