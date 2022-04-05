using UnityEngine;
using UnboundLib;

namespace DevNullCardPack.MonoBehaviours
{
    internal class GrowOthersAttacher : DealtDamageEffect
    {
        private const int maxEffects = 5;
    public override void DealtDamage(Vector2 damage, bool selfDamage, Player damagedPlayer)
        {
            GrowOthersEffect[] components = damagedPlayer.gameObject.GetComponents<GrowOthersEffect>();
            if (components.Length < maxEffects)
            {
                damagedPlayer.gameObject.AddComponent<GrowOthersEffect>();
            }
        }
    }
}
