using ModdingUtils.MonoBehaviours;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace DevNullCardPack.MonoBehaviours
{
    internal class ShrinkyDinkEffect : ReversibleEffect
    {
        public override void OnStart()
        {
            characterStatModifiersModifier.sizeMultiplier_mult = 0.85f;
            gunStatModifier.size_mult = 0.85f;
        }
    }
}
