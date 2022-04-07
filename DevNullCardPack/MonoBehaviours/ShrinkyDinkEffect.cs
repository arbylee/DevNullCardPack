using ModdingUtils.MonoBehaviours;

namespace DevNullCardPack.MonoBehaviours
{
    internal class ShrinkyDinkEffect : ReversibleEffect
    {
        private static float minLocalScale = 0.65f;
        private float sizeMultiplier = 0.85f;
        public override void OnStart()
        {
            characterStatModifiersModifier.sizeMultiplier_mult = sizeMultiplier;
            gunStatModifier.size_mult = sizeMultiplier;

        }
        public void Shrink()
        {
            UnityEngine.Debug.Log($"current multiplier {characterStatModifiers.sizeMultiplier} current scale {player.gameObject.transform.localScale.x}");

            if (player.gameObject.transform.localScale.x < minLocalScale || player.gameObject.transform.localScale.y < minLocalScale)
            {
                UnityEngine.Debug.Log($"Too small");

                return;
            }

            ClearModifiers();
            characterStatModifiersModifier.sizeMultiplier_mult *= sizeMultiplier;
            gunStatModifier.size_mult *= sizeMultiplier;
            ApplyModifiers();
        }
    }
}
