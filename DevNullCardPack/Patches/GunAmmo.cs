using HarmonyLib;
using UnityEngine;
using Photon.Pun;
using DevNullCardPack.Extensions;

namespace DevNullCardPack.Patches
{
    public class GunAmmoPatch
    {
        [HarmonyPatch(typeof(GunAmmo), "Shoot")]
        class Patch_Shoot
        {
            // ReSharper disable once UnusedMember.Local
            private static void Postfix(GunAmmo __instance, GameObject projectile, Gun ___gun)
            {
                // DoRecoil
                if (___gun.holdable && ___gun.holdable.holder.view.IsMine && ___gun.holdable.holder.stats.GetAdditionalData().recoil != 0)
                {
                    var holdable = ___gun.holdable;
                    var healthHandler = holdable.holder.healthHandler;
                    var player = holdable.holder.player;
                    var direction = Utils.Aim.GetAimDirectionAsVector(player);
                    var recoil = holdable.holder.stats.GetAdditionalData().recoil;
                    var damage = ___gun.damage;

                    healthHandler.CallTakeForce(-new Vector2(1000 * direction.x, 1000 * direction.y) * (recoil * 2.5f * damage));
                }
            }
        }
    }
}
