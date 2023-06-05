﻿using System;
using System.Collections.Generic;
using System.Text;
using RoR2;
using EntityStates;
using RoR2.Skills;
using UnityEngine;
using R2API;
using RoR2.Orbs;
using UnityEngine.Networking;
using AmpMod.Modules;
using AmpMod.SkillStates.Nemesis_Amp.Orbs;

namespace AmpMod.SkillStates.Nemesis_Amp
{
     class LightningStream : BaseSkillState
    {

        [Header("Attack Variables")]
        private float lightningTickDamage = Modules.StaticValues.lightningStreamPerSecondDamageCoefficient / 3f;
        private StackDamageController stackDamageController;
        private NemAmpLightningTetherController lightningEffectController;
        private float procCoefficient = Modules.StaticValues.lightningStreamProcCoefficient;
        private float baseTickTime = Modules.StaticValues.lightningStreamBaseTickTime;
        private float tickTime;
        private float tickTimer;

        [Header("Tracking/Effect Variables")]
        private NemAmpLightningTracker tracker;
        private HurtBox targetHurtbox;
        private bool lightningTetherActive;
        private Transform rightMuzzleTransform;
        private Transform nexusMuzzleTransform;
        private GameObject muzzleEffect = Assets.lightningStreamMuzzleEffect;

        [Header("Animation Variables")]
        private Animator animator;
        private ChildLocator childLocator;

        [Header("Sounds")]
        private string startSoundString = StaticValues.lightningStreamStartString;
        private string loopSoundString = StaticValues.lightningStreamLoopSoundString;
        private string endSoundString = StaticValues.lightningStreamEndString;
        private uint endLoopSoundID = 0;
        private float soundTimer;
        private bool hasBegunSound;

        public override void OnEnter()
        {
            base.OnEnter();
            stackDamageController = base.GetComponent<StackDamageController>();
            lightningEffectController = base.GetComponent<NemAmpLightningTetherController>();
            lightningEffectController.isAttacking = true;

            
            tracker = base.GetComponent<NemAmpLightningTracker>();

            Transform modelTransform = base.GetModelTransform();
            if (modelTransform)
            {
                this.childLocator = modelTransform.GetComponent<ChildLocator>();
                this.animator = modelTransform.GetComponent<Animator>();
            }

            this.tickTime= this.baseTickTime / this.attackSpeedStat;


            if (tracker.GetTrackingTarget())
            {
                animator.SetBool("NemIsFulminating", true);
                base.PlayAnimation("RightArm, Override", "ShootLightning", "BaseSkill.playbackRate", 0.4f);
                rightMuzzleTransform = childLocator.FindChild("LightningNexusMuzzle").transform;
                
                this.nexusMuzzleTransform = UnityEngine.Object.Instantiate<GameObject>(muzzleEffect, rightMuzzleTransform).transform;
                //Debug.Log(nexusMuzzleTransform);

                //nexusMuzzleTransform = childLocator.FindChild("LightningNexusMuzzle").transform;
                //Debug.Log("starting at " + rightMuzzleTransform.position);
            }
            //animations


        }

        private void FireLightning()
        {
            if (!NetworkServer.active || tickTimer > 0f)
            {
                return;
            }
            this.tickTimer = this.tickTime;

            if (targetHurtbox)
            {
                NemAmpLightningLockOrb lightningOrb = createDmgOrb();
                lightningOrb.procControlledCharge = false;

                if (Util.CheckRoll(procCoefficient * 100f, base.characterBody.master))
                {
                    lightningOrb.procControlledCharge = true;
                }


                if (base.GetBuffCount(Buffs.damageGrowth) == StaticValues.growthBuffMaxStacks)
                {
                    //lightningOrb.isChaining = true;
                    lightningOrb.bouncesRemaining = 2;
                }
                else
                {
                    lightningOrb.isChaining = false;
                    lightningOrb.bouncesRemaining = 0;
                }
                OrbManager.instance.AddOrb(lightningOrb);

            }

            
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            soundTimer += Time.fixedDeltaTime;

            this.tickTimer -= Time.fixedDeltaTime;

            if (base.characterBody)
            {
                base.characterBody.SetAimTimer(this.baseTickTime + 1f);
            }

            if (this.tracker && base.isAuthority)
            {
                this.targetHurtbox = this.tracker.GetTrackingTarget();
                if (targetHurtbox && !lightningTetherActive)
                {
                    lightningEffectController.CreateLightningTether(base.gameObject, rightMuzzleTransform);
                    lightningTetherActive = true;
                }

                if (soundTimer >= .1f && !hasBegunSound && targetHurtbox)
                {
                    endLoopSoundID = Util.PlaySound(loopSoundString, base.gameObject);
                    hasBegunSound = true;
                }

        

            }


            this.FireLightning();
            
            stackDamageController.newSkillUsed = this;
            stackDamageController.resetComboTimer();

            
            if ((base.isAuthority && !base.inputBank.skill1.down) || (base.isAuthority && this.targetHurtbox && this.targetHurtbox.healthComponent.health <= 0) || (base.isAuthority && !this.targetHurtbox))
            {
                this.outer.SetNextStateToMain();
            }
        }

        private NemAmpLightningLockOrb createDmgOrb()
        {
            return new NemAmpLightningLockOrb
            {
                origin = rightMuzzleTransform.position,
                damageValue = lightningTickDamage * damageStat + ((StaticValues.growthDamageCoefficient * base.GetBuffCount(Buffs.damageGrowth)) * lightningTickDamage * damageStat),
                isCrit = base.characterBody.RollCrit(),
                damageType = DamageType.Generic,
                teamIndex = teamComponent.teamIndex,
                attacker = gameObject,
                procCoefficient = .2f,
                lightningType = LightningOrb.LightningType.Loader,
                damageColorIndex = DamageColorIndex.Default,
                target = targetHurtbox,
                bouncedObjects = new List<HealthComponent>(),
                range = tracker.maxTrackingDistance,
                damageCoefficientPerBounce = .8f,

        };
        }


        public override void OnExit()
        {
            base.OnExit();
            AkSoundEngine.StopPlayingID(endLoopSoundID, 0);
            //Util.PlaySound(endSoundString, base.gameObject);

            lightningEffectController.isAttacking = false;
            //Debug.Log("Exiting");
            this.FireLightning();
            if (nexusMuzzleTransform)
            {
                EntityState.Destroy(nexusMuzzleTransform.gameObject);
            }

            lightningEffectController.DestroyLightningTether();
            lightningTetherActive = false;
            animator.SetBool("NemIsFulminating", false);


        }

        public override void OnSerialize(NetworkWriter writer)
        {
            writer.Write(HurtBoxReference.FromHurtBox(this.targetHurtbox));
        }

        public override void OnDeserialize(NetworkReader reader)
        {
            this.targetHurtbox = reader.ReadHurtBoxReference().ResolveHurtBox();
        }
        
        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.Skill;
        }

   
    }
}
