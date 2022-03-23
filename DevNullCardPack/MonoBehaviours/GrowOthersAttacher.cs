using UnityEngine;
using UnboundLib;

namespace DevNullCardPack.MonoBehaviours
{
    internal class GrowOthersAttacher : DealtDamageEffect
    {
        public override void DealtDamage(Vector2 damage, bool selfDamage, Player damagedPlayer)
        {
            var effect = damagedPlayer.gameObject.GetOrAddComponent<GrowOthersEffect>();
            effect.Grow();
        }
    }
}
