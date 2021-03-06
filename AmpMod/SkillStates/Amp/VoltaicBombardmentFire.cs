using UnityEngine;
using RoR2;
using EntityStates;
using UnityEngine.Networking;
using RoR2.Projectile;
using R2API;
using System.Linq;
using System.Collections.ObjectModel;

namespace AmpMod.SkillStates.Amp
{
    public class VoltaicBombardmentFire : BaseSkillState
    {
        public GameObject muzzleflashEffectPrefab;
        public float baseDuration;
        public Vector3 boltPosition;
        public Quaternion lightningRotation;
        private float duration = 1f;
        private Vector3 strikePosition;
        public float charge;
        static public float lightningChargeTimer = .5f;
        public GameObject lightningStrikeEffect;
        public GameObject lightningStrikeExplosion;
        private float overchargeDuration = Modules.StaticValues.overChargeDuration;
        bool hasFired;
        public float strikeRadius = 12f;
        protected Animator animator;
        private string AmpName = "NT_AMP_BODY_NAME";


        public override void OnEnter()
        {

            base.OnEnter();

            animator = base.GetModelAnimator();
            hasFired = false;
            this.duration = this.baseDuration / this.attackSpeedStat;
            animator.SetBool("HasFired", true);
            base.PlayAnimation("LeftArm, Override", "SummonLightning", "Spell.playbackRate", .5f);
            strikePosition = this.boltPosition + Vector3.up * 10;

            if (this.muzzleflashEffectPrefab)
            {
                EffectManager.SimpleMuzzleFlash(this.muzzleflashEffectPrefab, base.gameObject, "HandL", false);
            }
            
            
        }

        public void LightningSearch()
        {

            /* BullseyeSearch search = new BullseyeSearch
             {
                 teamMaskFilter = TeamMask.all,
                 filterByLoS = false,
                 searchOrigin = strikePosition,
                 searchDirection = Random.onUnitSphere,
                 sortMode = BullseyeSearch.SortMode.Distance,
                 maxDistanceFilter = 12f,
                 maxAngleFilter = 360f
             };
             Debug.Log("searching");

             search.RefreshCandidates();

             HurtBox target = search.GetResults().FirstOrDefault<HurtBox>();
             if (target)
             {
                 if (target.healthComponent && target.healthComponent.body)
                 {
                     if (target.healthComponent.body.baseNameToken == AmpName)
                     {
                         base.characterBody.AddTimedBuff(Modules.Buffs.overCharge, overchargeDuration);

                     }
                 }
             } */
            ReadOnlyCollection<TeamComponent> teamMembers = TeamComponent.GetTeamMembers(base.characterBody.teamComponent.teamIndex);
            float num = 144f;
            Vector3 position = strikePosition;
            for (int i = 0; i < teamMembers.Count; i++)
            {
                if ((teamMembers[i].transform.position - position).sqrMagnitude <= num)
                {
                    CharacterBody body = teamMembers[i].GetComponent<CharacterBody>();
                    if (body)
                    {
                        body.AddTimedBuff(Modules.Buffs.overCharge, overchargeDuration);
                    }
                }
            }
        }

        //used to set delay for attack
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            
            if (!hasFired)
            {
                //if age of fixedupdate is > .5 seconds 
                if (base.fixedAge > lightningChargeTimer)
                {
                    hasFired = true;
                    Fire();
                }

                //i dont know why but this line is necessary for the .5 second delay to actually work
                duration = .5f;
            }

                if (base.isAuthority && base.fixedAge >= this.duration)
                {
                    this.outer.SetNextStateToMain();
                } 
            }

        

        public override void OnExit()
        {
            base.OnExit();
            animator.SetBool("HasFired", false);
        }

        private void Fire()
        {
            

            if (base.isAuthority)
            {
                

                Ray aimRay = base.GetAimRay();

                // lightningStrikeEffect = RoR2.LegacyResourcesAPI.Load<GameObject>("Prefabs/Effects/ImpactEffects/LightningStrikeImpact");

                //prefabs to use for the actual strike effect; a copy of the royal capacitor's effect
                lightningStrikeEffect = LegacyResourcesAPI.Load<GameObject>("Prefabs/Effects/ImpactEffects/LightningStrikeImpact");

                //prefab to use for the explosion effect of the lightning; a copy of artificer's nano bomb explosion
                lightningStrikeExplosion = RoR2.LegacyResourcesAPI.Load<GameObject>("Prefabs/Effects/MageLightningBombExplosion");


                //effect data for lightning)
                EffectData lightning = new EffectData
                {
                    origin = this.boltPosition,
                    scale = 5f,
                };
                
                //effect data for lightningexplosion
                EffectData lightningExplosion = new EffectData
                {
                    origin = this.boltPosition,
                    scale = 5f,

                };
                //spawns lightning/lightningexplosion effects
                EffectManager.SpawnEffect(lightningStrikeEffect, lightning, true);
                //EffectManager.SpawnEffect(lightningStrikeExplosion, lightningExplosion, true);


                //create blastattack
                BlastAttack lightningStrike = new BlastAttack
                {
                    attacker = base.gameObject,
                    baseDamage = Modules.StaticValues.lightningStrikeCoefficient * base.characterBody.damage,
                    baseForce = 2f,
                    attackerFiltering = AttackerFiltering.NeverHitSelf,
                    crit = base.characterBody.RollCrit(),
                    damageColorIndex = DamageColorIndex.Item,
                    damageType = DamageType.Generic,
                    falloffModel = BlastAttack.FalloffModel.None,
                    inflictor = base.gameObject,

                    //blastattack is positioned 10 units above where the reticle is placed
                    position = strikePosition,
                    procChainMask = default(ProcChainMask),
                    procCoefficient = 1f,
                    radius = this.strikeRadius,
                    teamIndex = base.characterBody.teamComponent.teamIndex
                };
                lightningStrike.AddModdedDamageType(Modules.DamageTypes.apply2Charge);
                
                lightningStrike.Fire();
                LightningSearch();


            }
        } 

           

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.PrioritySkill;
        }

    }

}


        




