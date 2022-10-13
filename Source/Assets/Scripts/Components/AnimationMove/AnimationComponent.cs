using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace AnimationLibrary
{
    [Serializable]
    public class AnimationComponent
    {

        public enum Stage
        {
            START, MIDDLE, END
        }
        public Stage currentStage;



        [SerializeField]
        private LerpScale lerpScale;

        [SerializeField]
        private LerpShapeScale lerpScaleShapes;
        [SerializeField]
        private LerpPosition lerpTransform;
        [SerializeField]
        private LerpRotation lerpRotation;
        // [SerializeField]
        [SerializeField]
        private OrbitLerp lerpOrbit;
        public float percent;
        private Vector3 transformCustomMultiplierPos;
        public List<TransformComponent> components = new List<TransformComponent>();

        //list of rotations 






        public void AwakeFunctions()
        {
            StartsceneInitiateComps();
        }


        public void Animate(float percent)
        {
            this.percent = percent;

            lerpTransform.MoveTransform(percent, Vector2.zero, ref lerpTransform.lerpTransDatas[lerpTransform.SequentialLerp.rangeIndex].TransformToMove);
            lerpRotation.HowToLerpRotation(percent);
            lerpOrbit.LerpOrbit(percent);
            lerpScale.ScaleLerp(percent);
            lerpScaleShapes.ScaleLerp(percent);
            ApplyAllAnimations();

        }
        public void AddTransformComponent()
        {
            components.Add(new TransformComponent());

        }

        public void ApplyAllAnimations()
        {
            foreach (var component in components)
            {
                if (component.ApplyRotation)
                {
                    component.ConfigurRotation(lerpRotation.rotationDatas[lerpRotation.SequentialLerp.rangeIndex].currentRotation);
                }
                if (component.ApplyTransform)
                {
                    //its Got this component has Custom Multipliers
                    if (component.multipliers != Vector2.zero)
                    {
                        // this will lerp with a custom multiplier
                        lerpTransform.MoveTransform(percent, component.multipliers, ref transformCustomMultiplierPos);
                        component.ConfigurTransforms(transformCustomMultiplierPos);
                    }
                    else
                        component.ConfigurTransforms(lerpTransform.lerpTransDatas[lerpTransform.SequentialLerp.rangeIndex].TransformToMove);

                    //if it does not have any custom multipliers 

                    //if (component.MultiplierIdentity == customMultiplier.NONE)
                    //{
                    //    component.ConfigurTransforms(lerpPosition.TransformToMove.localPosition);
                    //}
                    //else if (component.MultiplierIdentity == customMultiplier.BOTH)//
                    //{

                    //}
                    //else if (component.MultiplierIdentity == customMultiplier.MULTIPLIERX)//
                    //{ 

                    //}
                    //else if (component.MultiplierIdentity == customMultiplier.MULTIPLIERY)//
                    //{

                    //}
                    //if doesnt have a custom multiplier 
                    ////COLOR lERP

                    ///

                }
                if (component.ApplyOrbit)
                {
                    component.ConfigurOrbit(lerpOrbit.orbitDatas[lerpOrbit.SequentialLerp.rangeIndex].TransformOrbitPos);
                }
                if (component.ApplyScale)
                {
                    component.ConfigurOjectScaleScale(lerpScale.lerpScaleDatas[lerpScale.SequentialLerp.rangeIndex].TransformScale);
                }
                if (component.ApplyShapeScale)
                {
                    component.ConfigurShapeScale(lerpScaleShapes.lerpScaleDatas[lerpScaleShapes.SequentialLerp.rangeIndex].ShapeCurrentScale);
                }
                component.lerpColor.LerpColorNow(percent);
                // component.transform.localRotation = () lerpRotation.RotTransform.localRotation : Quaternion.identity;

            }


        }
        //public void LerpTransformComponentColors(float percent)
        //{
        //    foreach (var component in components)
        //    {



        //    }
        //}
        public void StartsceneInitiateComps()
        {
            foreach (var component in components)
            {

                component.GetShapeComponent();
            }
        }
        public void StartAllTransformCompsStartFunctions(bool start)
        {
            foreach (var component in components)
            {
                if (start)
                {
                    component.StartComponents(start);

                }
                else component.StartComponents(false);

            }
        }
        //ESENTIAL AND SHOULD BE CALLED AT START AND END OF LERP
        public void ConfigureStart(bool Start)
        {
            lerpOrbit.StartFinished(Start);
            lerpRotation.StartFinished(Start);
            lerpTransform.StartFinished(Start);
            lerpScale.StartFinished(Start);
            lerpScaleShapes.StartFinished(Start);
            StartAllTransformCompsStartFunctions(Start);

        }


    }
}
