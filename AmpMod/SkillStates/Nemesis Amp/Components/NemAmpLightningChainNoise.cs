﻿using System.Collections.Generic;
using System.Text;
using UnityEngine;
using RoR2;
using RoR2.Orbs;    


namespace AmpMod.SkillStates.Nemesis_Amp.Components
{


    public class NemAmpLightningChainNoise : MonoBehaviour
    {
        private LineRenderer lineRenderer;
        private CharacterBody endBody;
        private float duration = .25f;
        private float age;
        public GameObject endGameObject;
        public Vector3 startPosition;
        private float posRange = 0.5f;
        private SkillStates.Nemesis_Amp.NemAmpLightningEffectController nemAmpLightningEffectController;
        private EffectComponent effectComponent;
        private int numLineRendererPoints;
        public HealthComponent healthComponent;
        private Vector3 lastKnownTargetPosition;
        public bool callArrivalIfTargetIsGone = true;

        private void Start()
        {
            lineRenderer = base.GetComponent<LineRenderer>();
            numLineRendererPoints = lineRenderer.positionCount;
            if (healthComponent)
            {
                endGameObject = healthComponent.gameObject;
                //Debug.Log(endGameObject + " is end gameobject");
                if (endGameObject)
                {
                    endBody = healthComponent.body;
                }

            }
            this.lastKnownTargetPosition = (this.endBody ? this.endBody.corePosition : this.startPosition);
        }

        private void Update()
        {
            age += Time.deltaTime;
            CreateLightningNoise();
            if (age > duration)//healthComponent.health <= 0 || Vector3.Distance(endTransform.position, startPosition) > 50f || )
            {
                Destroy(base.gameObject);
            }
        }
     

        private void CreateLightningNoise()
        {
            {
                if (lineRenderer && endBody)
                {
                    Vector3 normalizedVector;
                    lineRenderer.SetPosition(0, this.startPosition);

                    for (int i = 1; i < numLineRendererPoints - 1; i++)
                    {
                        //lineRenderer.SetPosition(i, victimBody.corePosition);
                        //float z = ((float)i) * (maxZ) / (float)(numLineRendererPoints - 1);
                        var pos = Vector3.Lerp(endBody.corePosition, startPosition, i / 11f);
                        pos.x += Random.Range(-posRange, posRange);
                        pos.y += Random.Range(-posRange, posRange);
                        /* var chooser = Random.Range(1, 4);
                        if (chooser == 1) pos.x += Random.Range(-posRange, posRange) + .2f;
                        else if (chooser == 2) pos.y += Random.Range(-posRange, posRange) + .2f;
                        else if (chooser == 3) pos.z += Random.Range(-posRange, posRange) + .2f; */


                        lineRenderer.SetPosition(i, pos);
                    }
                    normalizedVector = Vector3.Normalize((endBody.corePosition - startPosition));
                    
                    lineRenderer.SetPosition(numLineRendererPoints - 1, (endBody.corePosition + 2f*(normalizedVector)));

                    //Debug.Log(trackingTarget.gameObject.transform.position + " is position");

                }

            }
        }
    }
}
