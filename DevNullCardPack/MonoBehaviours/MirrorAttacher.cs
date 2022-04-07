using UnityEngine;
using UnboundLib;

namespace DevNullCardPack.MonoBehaviours
{
    internal class MirrorAttacher : DealtDamageEffect
    {
        public override void DealtDamage(Vector2 damage, bool selfDamage, Player damagedPlayer)
        {
                damagedPlayer.gameObject.GetOrAddComponent<MirrorEffect>();
        }
    }
}
