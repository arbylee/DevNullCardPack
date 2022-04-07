using UnityEngine;
using UnboundLib;

namespace DevNullCardPack.MonoBehaviours
{
    internal class ShrinkyDinkAttacher : DealtDamageEffect
    {
    public override void DealtDamage(Vector2 damage, bool selfDamage, Player damagedPlayer)
        {
            Player player = this.gameObject.GetComponent<Player>();
            ShrinkyDinkEffect shrinkyDinkEffect = player.gameObject.GetComponent<ShrinkyDinkEffect>();
            if (shrinkyDinkEffect == null)
            {
                player.gameObject.AddComponent<ShrinkyDinkEffect>();
            }
            else
            {
                shrinkyDinkEffect = player.gameObject.GetComponent<ShrinkyDinkEffect>();
                shrinkyDinkEffect.Shrink();
            }
        }
    }
}
