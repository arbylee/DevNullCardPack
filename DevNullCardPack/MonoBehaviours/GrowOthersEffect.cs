using ModdingUtils.MonoBehaviours;

namespace DevNullCardPack.MonoBehaviours
{
    internal class GrowOthersEffect : ReversibleEffect
    {
        private static float maxLocalScale = 3.5f;
        private float sizeMultiplier = 1.25f;
        public override void OnStart()
        {
            characterStatModifiersModifier.sizeMultiplier_mult = sizeMultiplier;
            gunStatModifier.size_mult = sizeMultiplier;
        }
        public void Grow()
        {
            UnityEngine.Debug.Log($"current multiplier {characterStatModifiers.sizeMultiplier} current scale {player.gameObject.transform.localScale.x}");
            if (player.gameObject.transform.localScale.x > maxLocalScale || player.gameObject.transform.localScale.y > maxLocalScale)
            {
                UnityEngine.Debug.Log($"Too big");
                return;
            }

            ClearModifiers();
            characterStatModifiersModifier.sizeMultiplier_mult *= sizeMultiplier;
            gunStatModifier.size_mult *= sizeMultiplier;
            ApplyModifiers();
        }
    }
}
