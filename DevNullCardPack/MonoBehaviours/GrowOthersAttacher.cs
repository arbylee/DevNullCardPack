using UnityEngine;
using UnboundLib;

namespace DevNullCardPack.MonoBehaviours
{
    internal class GrowOthersAttacher : DealtDamageEffect
    {
    public override void DealtDamage(Vector2 damage, bool selfDamage, Player damagedPlayer)
        {
            GrowOthersEffect growOthersEffect = damagedPlayer.gameObject.GetComponent<GrowOthersEffect>();
            if (growOthersEffect == null)
            {
                damagedPlayer.gameObject.AddComponent<GrowOthersEffect>();
            }
            else
            {
                growOthersEffect = damagedPlayer.gameObject.GetComponent<GrowOthersEffect>();
                growOthersEffect.Grow();
            }
        }
    }
}
