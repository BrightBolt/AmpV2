﻿using System;
using System.Collections.Generic;
using UnityEngine;
using RoR2.Orbs;
using RoR2;
using R2API;
using System.Linq;

namespace AmpMod.SkillStates.Nemesis_Amp.Orbs
{
	public class NemAmpLightningLockOrb : Orb
	{
		private BullseyeSearch search;
		public LightningOrb.LightningType lightningType;
		public float range = 30f;
		public List<HealthComponent> bouncedObjects;
		public float damageValue;
		public GameObject attacker;
		public GameObject inflictor;
		public int bouncesRemaining;
		public TeamIndex teamIndex;
		public bool isCrit;
		public ProcChainMask procChainMask;
		public float procCoefficient;
		public float damageCoefficientPerBounce = 1f;
		private bool failedToKill;
		public DamageColorIndex damageColorIndex;
		public DamageType damageType;
		private Vector3 startPosition;
		private bool canBounceOnSameTarget = false;
		public int targetsToFindPerBounce = 1;
		public static event Action<NemAmpLightningLockOrb> onLightningOrbKilledOnAllBounces;
		public bool procControlledCharge;
		public bool isChaining;
		private Components.NemAmpLightningChainNoise chainObject;

		public override void Begin()
		{
            //Debug.Log("lightning attack spawning");
            //base.Begin();
            base.duration = 0.1f;
			//this.speed = 120f;
			string path = null;
			switch (this.lightningType)
			{
				case LightningOrb.LightningType.Loader:
					path = null;
					break;
				case LightningOrb.LightningType.MageLightning:
					path = "Prefabs/Effects/OrbEffects/MageLightningOrbEffect";
					base.duration = 0.1f;
					break;
			}
			EffectData effectData = new EffectData
			{
				//origin = this.origin,
				origin = this.target.healthComponent.gameObject.transform.position,
				genericFloat = base.duration,
			};

			effectData.SetHurtBoxReference(this.target);
			if (this.lightningType != LightningOrb.LightningType.Loader)
            {
				EffectManager.SpawnEffect(LegacyResourcesAPI.Load<GameObject>(path), effectData, true);
			}
            else
            {	//this prefab is empty of everything except for the impact effect; the actual lightning stream is controlled by the lightningeffectcontroller
				EffectManager.SpawnEffect(Modules.Assets.lightningStreamImpactEffect, effectData, true);
			}
			if (this.isChaining)
			{
				/*EffectData chainEffectData = new EffectData
				{
					origin = this.origin,
					//origin = this.target.healthComponent.gameObject.transform.position,
					genericFloat = base.duration,
				}; 
				//chainEffectData.SetHurtBoxReference(this.target);
				EffectManager.SpawnEffect(Modules.Assets.lightningStreamChainEffect, chainEffectData, true);
				*/
				chainObject = UnityEngine.Object.Instantiate(Modules.Assets.lightningStreamChainEffectPrefab).GetComponent<Components.NemAmpLightningChainNoise>();
				chainObject.startPosition = this.origin;
				chainObject.healthComponent = this.target.healthComponent;

			}



		}
		public override void OnArrival()
		{
			if (this.target)
			{
				HealthComponent healthComponent = this.target.healthComponent;
				if (healthComponent)
				{
					DamageInfo damageInfo = new DamageInfo();
					damageInfo.damage = this.damageValue;
					damageInfo.attacker = this.attacker;
					damageInfo.inflictor = this.inflictor;
					damageInfo.force = Vector3.zero;
					damageInfo.crit = this.isCrit;
					damageInfo.procChainMask = this.procChainMask;
					damageInfo.procCoefficient = this.procCoefficient;
					damageInfo.position = this.target.transform.position;
					damageInfo.damageColorIndex = this.damageColorIndex;
					damageInfo.damageType = this.damageType;
					if (procControlledCharge)
                    {
						damageInfo.AddModdedDamageType(Modules.DamageTypes.controlledChargeProc);
                    }
					healthComponent.TakeDamage(damageInfo);
					GlobalEventManager.instance.OnHitEnemy(damageInfo, healthComponent.gameObject);
					GlobalEventManager.instance.OnHitAll(damageInfo, healthComponent.gameObject);
				}
				this.failedToKill |= (!healthComponent || healthComponent.alive);
				if (this.bouncesRemaining > 0)
				{
					for (int i = 0; i < this.targetsToFindPerBounce; i++)
					{
						if (this.bouncedObjects != null)
						{
							if (this.canBounceOnSameTarget)
							{
								this.bouncedObjects.Clear();
							}
							this.bouncedObjects.Add(this.target.healthComponent);
						}

						HurtBox hurtBox = this.PickNextTarget(this.target.transform.position);
						if (hurtBox)
						{
							NemAmpLightningLockOrb lightningOrb = new NemAmpLightningLockOrb();
							lightningOrb.search = this.search;
							lightningOrb.origin = this.target.transform.position;
							lightningOrb.target = hurtBox;
							lightningOrb.attacker = this.attacker;
							lightningOrb.inflictor = this.inflictor;
							lightningOrb.teamIndex = this.teamIndex;
							lightningOrb.damageValue = this.damageValue * this.damageCoefficientPerBounce;
							lightningOrb.bouncesRemaining = this.bouncesRemaining - 1;
							lightningOrb.isCrit = this.isCrit;
							lightningOrb.bouncedObjects = this.bouncedObjects;
							lightningOrb.lightningType = this.lightningType;
							lightningOrb.procChainMask = this.procChainMask;
							lightningOrb.procCoefficient = this.procCoefficient;
							lightningOrb.damageColorIndex = this.damageColorIndex;
							lightningOrb.damageCoefficientPerBounce = this.damageCoefficientPerBounce;
							lightningOrb.range = Modules.StaticValues.lightningChainRange;
							lightningOrb.damageType = this.damageType;
							lightningOrb.failedToKill = this.failedToKill;
							lightningOrb.isChaining = true;
							OrbManager.instance.AddOrb(lightningOrb);
						}
					}
					return;
				}
				if (!this.failedToKill)
				{
					Action<NemAmpLightningLockOrb> action = NemAmpLightningLockOrb.onLightningOrbKilledOnAllBounces;
					if (action == null)
					{
						return;
					}
					action(this);
				}
			}
		}


		public HurtBox PickNextTarget(Vector3 position)
		{
			if (this.search == null)
			{
				this.search = new BullseyeSearch();
			}
			this.search.searchOrigin = position;
			this.search.searchDirection = Vector3.zero;
			this.search.teamMaskFilter = TeamMask.allButNeutral;
			this.search.teamMaskFilter.RemoveTeam(this.teamIndex);
			this.search.filterByLoS = false;
			this.search.sortMode = BullseyeSearch.SortMode.Distance;
			this.search.maxDistanceFilter = this.range;
			this.search.RefreshCandidates();
			HurtBox hurtBox = (from v in this.search.GetResults()
							   where !this.bouncedObjects.Contains(v.healthComponent)
							   select v).FirstOrDefault<HurtBox>();
			if (hurtBox)
			{
				this.bouncedObjects.Add(hurtBox.healthComponent);
			}
			return hurtBox;
		}

	}
}
