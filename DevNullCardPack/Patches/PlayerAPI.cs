using HarmonyLib;
using UnityEngine;
using DevNullCardPack.Extensions;

namespace DevNullCardPack.Patches
{
    [HarmonyPatch(typeof(PlayerMovement), "Move")]
    class PlayerMovementPatchMove
    {
        private static bool Prefix(ref Vector2 direction, PlayerMovement __instance)
        {
            CharacterDataDevNullData data = __instance.GetComponentInParent<CharacterData>().GetDevNullData();
            if (data.reverseControls)
            {
                direction *= -1f;
            }
            return true;
        }
    }
}
