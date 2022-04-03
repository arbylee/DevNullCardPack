using ModdingUtils.MonoBehaviours;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace DevNullCardPack.MonoBehaviours
{
    internal class GrowOthersEffect : ReversibleEffect
    {
        private bool ranOnce = false;
        public override void OnUpdate()
        {
            if (!ranOnce)
            {
                Grow();
            }
        }
        public void Grow()
        {
            // characterStatModifiers.sizeMultiplier *= 1.1f;
            //characterStatModifiersModifier.sizeMultiplier_add = 0.5f;
            UnityEngine.Debug.Log($"Local scale before {base.transform.localScale}");
            if (player != null && player.transform.localScale.x < 10)
            {
                player.transform.localScale *= 1.4f;
                UnityEngine.Debug.Log($"Local scale after {base.transform.localScale}");
                //this.ApplyModifiers();
                ranOnce = true;
            }
        }
    }
}
