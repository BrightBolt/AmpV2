using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using RoR2;

namespace AmpMod.SkillStates.SkillComponents
{
	internal class ElectrifiedEffectController : MonoBehaviour
	{
		private TemporaryOverlayInstance temporaryOverlay;
		public GameObject target;
		private Material electrifiedMaterial = Modules.Asset.electrifiedMaterial;
		public CharacterBody electrifiedBody;
		private float duration = Modules.StaticValues.electrifiedDuration;
		private float age;

		private void Start()
		{
			this.temporaryOverlay = TemporaryOverlayManager.AddOverlay(base.gameObject);
			this.temporaryOverlay.originalMaterial = this.electrifiedMaterial;


			if (this.target)
			{
				CharacterModel component = this.target.GetComponent<CharacterModel>();
				if (component)
				{
					if (this.temporaryOverlay != null)
					{
						this.temporaryOverlay.AddToCharacterModel(component);
					}

				}
			}
		}



		private void FixedUpdate()
        {
			
			if (!electrifiedBody.HasBuff(Modules.Buffs.electrified)) 
			{
				if (this.temporaryOverlay != null)
				{
					Debug.Log(age);
					temporaryOverlay.Destroy();
				}
				UnityEngine.Component.Destroy(this);
			}
        
        }

		private void OnDestroy()
		{

			


		}
	}
}
