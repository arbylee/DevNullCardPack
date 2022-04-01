using ModdingUtils.MonoBehaviours;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace DevNullCardPack.MonoBehaviours
{
    internal class GrowOthersEffect : ReversibleEffect
    {
        public void Grow()
        {
            // characterStatModifiers.sizeMultiplier *= 1.1f;
            base.transform.localScale *= 1.4f;
        }
    }
}
