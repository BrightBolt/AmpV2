﻿using EntityStates;
using System;
using UnityEngine;
using UnityEngine.Networking;
using RoR2;


namespace HenryMod.SkillStates
{
	// Token: 0x0200028D RID: 653
	[RequireComponent(typeof(VehicleSeat))]
	[RequireComponent(typeof(Rigidbody))]
	public class BoltVehicle : MonoBehaviour, ICameraStateProvider
	{


		// Token: 0x06000E25 RID: 3621 RVA: 0x0003A68C File Offset: 0x0003888C
		private void Awake()
		{
			this.vehicleSeat = base.GetComponent<VehicleSeat>();
			this.vehicleSeat.onPassengerEnter += this.OnPassengerEnter;
			this.vehicleSeat.onPassengerExit += this.OnPassengerExit;
			this.rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x06000E2A RID: 3626 RVA: 0x0003A7B0 File Offset: 0x000389B0
		private void OnPassengerExit(GameObject passenger)
		{
			if (NetworkServer.active)
			{
				this.DetonateServer();
			}
			foreach (CameraRigController cameraRigController in CameraRigController.readOnlyInstancesList)
			{
				if (cameraRigController.target == passenger)
				{
					cameraRigController.SetOverrideCam(this, 0f);
					cameraRigController.SetOverrideCam(null, this.cameraLerpTime);
				}
			}
		}

		// Token: 0x06000E2B RID: 3627 RVA: 0x0003A82C File Offset: 0x00038A2C
		private void OnPassengerEnter(GameObject passenger)
		{
			if (!this.vehicleSeat.currentPassengerInputBank)
			{
				return;
			}
			Vector3 aimDirection = this.vehicleSeat.currentPassengerInputBank.aimDirection;
			this.rigidbody.rotation = Quaternion.LookRotation(aimDirection);
			this.rigidbody.velocity = aimDirection * this.initialSpeed;
			CharacterBody currentPassengerBody = this.vehicleSeat.currentPassengerBody;
			this.overlapAttack = new OverlapAttack
			{
				attacker = currentPassengerBody.gameObject,
				damage = this.overlapDamageCoefficient * currentPassengerBody.damage,
				pushAwayForce = this.overlapForce,
				isCrit = currentPassengerBody.RollCrit(),
				damageColorIndex = DamageColorIndex.Item,
				inflictor = base.gameObject,
				procChainMask = default(ProcChainMask),
				procCoefficient = this.overlapProcCoefficient,
				teamIndex = currentPassengerBody.teamComponent.teamIndex,
				hitBoxGroup = base.gameObject.GetComponent<HitBoxGroup>(),
				hitEffectPrefab = this.overlapHitEffectPrefab
			};
		}

		// Token: 0x06000E2C RID: 3628 RVA: 0x0003A92C File Offset: 0x00038B2C
		private void DetonateServer()
		{
			if (this.hasDetonatedServer)
			{
				return;
			}
			this.hasDetonatedServer = true;
			CharacterBody currentPassengerBody = this.vehicleSeat.currentPassengerBody;
			if (currentPassengerBody)
			{
				EffectData effectData = new EffectData
				{
					origin = base.transform.position,
					scale = this.blastRadius
				};
				explosionEffectPrefab = UnityEngine.Object.Instantiate<GameObject>(Modules.Assets.mainAssetBundle.LoadAsset<GameObject>("ElectricExplosion"));

				EffectManager.SpawnEffect(this.explosionEffectPrefab, effectData, true);
		
			}
			Util.PlaySound(this.explosionSoundString, base.gameObject);
			UnityEngine.Object.Destroy(base.gameObject);
		}

		// Token: 0x06000E2D RID: 3629 RVA: 0x0003AA74 File Offset: 0x00038C74
		private void FixedUpdate()
		{
			if (!this.vehicleSeat)
			{
				return;
			}
			if (!this.vehicleSeat.currentPassengerInputBank)
			{
				return;
			}
			this.age += Time.fixedDeltaTime;
			this.overlapFireAge += Time.fixedDeltaTime;
			this.overlapResetAge += Time.fixedDeltaTime;
			if (NetworkServer.active)
			{
				if (this.overlapFireAge > 1f / this.overlapFireFrequency)
				{
					if (this.overlapAttack.Fire(null))
					{
						this.age = Mathf.Max(0f, this.age - this.overlapVehicleDurationBonusPerHit);
					}
					this.overlapFireAge = 0f;
				}
				if (this.overlapResetAge >= 1f / this.overlapResetFrequency)
				{
					this.overlapAttack.ResetIgnoredHealthComponents();
					this.overlapResetAge = 0f;
				}
			}
			Ray originalAimRay = this.vehicleSeat.currentPassengerInputBank.GetAimRay();
			float num;
			originalAimRay = CameraRigController.ModifyAimRayIfApplicable(originalAimRay, base.gameObject, out num);
			Vector3 velocity = this.rigidbody.velocity;
			Vector3 target = originalAimRay.direction * this.targetSpeed;
			Vector3 a = Vector3.MoveTowards(velocity, target, this.acceleration * Time.fixedDeltaTime);
			this.rigidbody.MoveRotation(Quaternion.LookRotation(originalAimRay.direction));
			this.rigidbody.AddForce(a - velocity, ForceMode.VelocityChange);
			if (NetworkServer.active && this.duration <= this.age)
			{
				this.DetonateServer();
			}
		}

		// Token: 0x06000E2E RID: 3630 RVA: 0x0003ABED File Offset: 0x00038DED
		private void OnCollisionEnter(Collision collision)
		{
			if (this.detonateOnCollision && NetworkServer.active)
			{
				this.DetonateServer();
			}
		}

		// Token: 0x06000E2F RID: 3631 RVA: 0x00004381 File Offset: 0x00002581
		public void GetCameraState(CameraRigController cameraRigController, ref CameraState cameraState)
		{
		}

		// Token: 0x06000E30 RID: 3632 RVA: 0x00013F7C File Offset: 0x0001217C
		public bool IsUserLookAllowed(CameraRigController cameraRigController)
		{
			return true;
		}

		// Token: 0x06000E31 RID: 3633 RVA: 0x00013F7C File Offset: 0x0001217C
		public bool IsUserControlAllowed(CameraRigController cameraRigController)
		{
			return true;
		}

		// Token: 0x06000E32 RID: 3634 RVA: 0x00013F7C File Offset: 0x0001217C
		public bool IsHudAllowed(CameraRigController cameraRigController)
		{
			return true;
		}

		// Token: 0x04000D53 RID: 3411
		[Header("Vehicle Parameters")]
		public float duration = 10f;

		// Token: 0x04000D54 RID: 3412
		public float initialSpeed = 50f;

		// Token: 0x04000D55 RID: 3413
		public float targetSpeed = 50f;

		// Token: 0x04000D56 RID: 3414
		public float acceleration = 1000f;

		// Token: 0x04000D57 RID: 3415
		public float cameraLerpTime = 1f;

		// Token: 0x04000D58 RID: 3416
		[Header("Blast Parameters")]
		public bool detonateOnCollision;

		// Token: 0x04000D59 RID: 3417
		public GameObject explosionEffectPrefab;

		// Token: 0x04000D5A RID: 3418
		public float blastDamageCoefficient;

		// Token: 0x04000D5B RID: 3419
		public float blastRadius;

		// Token: 0x04000D5C RID: 3420
		public float blastForce;

		// Token: 0x04000D5D RID: 3421
		public BlastAttack.FalloffModel blastFalloffModel;

		// Token: 0x04000D5E RID: 3422
		public DamageType blastDamageType;

		// Token: 0x04000D5F RID: 3423
		public Vector3 blastBonusForce;

		// Token: 0x04000D60 RID: 3424
		public float blastProcCoefficient;

		// Token: 0x04000D61 RID: 3425
		public string explosionSoundString;

		// Token: 0x04000D62 RID: 3426
		[Header("Overlap Parameters")]
		public float overlapDamageCoefficient = .5f;

		// Token: 0x04000D63 RID: 3427
		public float overlapProcCoefficient;

		// Token: 0x04000D64 RID: 3428
		public float overlapForce;

		// Token: 0x04000D65 RID: 3429
		public float overlapFireFrequency;

		// Token: 0x04000D66 RID: 3430
		public float overlapResetFrequency;

		// Token: 0x04000D67 RID: 3431
		public float overlapVehicleDurationBonusPerHit;

		// Token: 0x04000D68 RID: 3432
		public GameObject overlapHitEffectPrefab;

		// Token: 0x04000D69 RID: 3433
		private float age;

		// Token: 0x04000D6A RID: 3434
		private bool hasDetonatedServer;

		// Token: 0x04000D6B RID: 3435
		private VehicleSeat vehicleSeat;

		// Token: 0x04000D6C RID: 3436
		private Rigidbody rigidbody;

		// Token: 0x04000D6D RID: 3437
		private OverlapAttack overlapAttack;

		// Token: 0x04000D6E RID: 3438
		private float overlapFireAge;

		// Token: 0x04000D6F RID: 3439
		private float overlapResetAge;
	}
}
