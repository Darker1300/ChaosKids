using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AnimationLibrary
{
    public class AnimatorConstructor : MonoBehaviour
    {
        [SerializeField]
        public List<AnimationComponent> components = new List<AnimationComponent>();
        // Start is called before the first frame update
        void Start()
        {
            ConfigureAwake();
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void ConfigureAwake()
        {
            //go throw all animation components and initiate
            foreach (AnimationComponent item in components)
            {
                item.AwakeFunctions();
            }

        }
        public void ConfigureStartEnd(bool Start)
        {
            foreach (AnimationComponent item in components)
            {
                item.ConfigureStart(Start);
            }

        }

        public void AnimateAll(float percent)
        {
            foreach (AnimationComponent item in components)
            {
                item.Animate(percent);
            }
        }

    }
}
