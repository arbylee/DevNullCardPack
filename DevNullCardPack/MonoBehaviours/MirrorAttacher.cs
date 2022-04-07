using UnityEngine;
using UnboundLib;

namespace DevNullCardPack.MonoBehaviours
{
    internal class MirrorAttacher : DealtDamageEffect
    {
        public override void DealtDamage(Vector2 damage, bool selfDamage, Player damagedPlayer)
        {
            if (!selfDamage)
            {
                MirrorEffect mirrorEffect = damagedPlayer.gameObject.GetComponent<MirrorEffect>();
                if (mirrorEffect == null)
                {
                    // Flips on start, so no need to toggle now
                    damagedPlayer.gameObject.AddComponent<MirrorEffect>();
                }
                else
                {
                    mirrorEffect.Toggle();
                }
            }
        }
    }
}
