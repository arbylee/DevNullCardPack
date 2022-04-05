using ModdingUtils.MonoBehaviours;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace DevNullCardPack.MonoBehaviours
{
    internal class GrowOthersEffect : ReversibleEffect
    {
        public override void OnStart()
        {
            UnityEngine.Debug.Log($"Local scale before {base.transform.localScale}");
                characterStatModifiersModifier.sizeMultiplier_mult = 1.4f;
        }
    }
}
