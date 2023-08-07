﻿using System;
using System.Collections.Generic;
using System.Text;
using RoR2;
using EntityStates;
using UnityEngine;
using AmpMod.Modules;

namespace AmpMod.SkillStates.Nemesis_Amp.Components
{
    public class NemAmpSpawnVFXController : MonoBehaviour
    {
        public GameObject ringVFX = Assets.spawnSecondaryExplosionEffect;
        public GameObject dustVFX = Assets.spawnDustEffect;
        private String dustSFX = Modules.StaticValues.spawnDustSoundString;
        private string burstSFX = Modules.StaticValues.spawnBurstSoundString;
        public ChildLocator childLocator;
        public CharacterBody characterBody;

        private void Start()
        {
            childLocator = base.gameObject.GetComponent<ChildLocator>();
        }
        public void SpawnReleaseRing()
        {
            
            EffectData ringEffect = new EffectData
            {
                scale = 1,
                origin = characterBody.corePosition,
            };
            EffectManager.SpawnEffect(ringVFX, ringEffect, true);
            Util.PlaySound(burstSFX, base.gameObject);
        }

        public void SpawnDust()
        {
            Transform leftHandTransform = childLocator.FindChild("HandL");
            EffectData dustEffect = new EffectData
            {
                scale = 1,
                origin = leftHandTransform.position,    
            };
            EffectManager.SpawnEffect(dustVFX, dustEffect, true);
            Util.PlaySound(dustSFX, base.gameObject);
            
            
        }
    }
    
}