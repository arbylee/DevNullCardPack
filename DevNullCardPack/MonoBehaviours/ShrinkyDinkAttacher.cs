using UnityEngine;
using UnboundLib;

namespace DevNullCardPack.MonoBehaviours
{
    internal class ShrinkyDinkAttacher : DealtDamageEffect
    {
        private const int maxEffects = 7;
    public override void DealtDamage(Vector2 damage, bool selfDamage, Player damagedPlayer)
        {
            ShrinkyDinkEffect[] components = this.gameObject.GetComponent<Player>().gameObject.GetComponents<ShrinkyDinkEffect>();
            if (components.Length < maxEffects)
            {
                this.gameObject.GetComponent<Player>().gameObject.AddComponent<ShrinkyDinkEffect>();
            }
        }
    }
}
