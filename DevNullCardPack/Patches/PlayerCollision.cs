using HarmonyLib;
using UnityEngine;
using DevNullCardPack.Extensions;

namespace DevNullCardPack.Patches
{
    [HarmonyPatch(typeof(PlayerCollision), "FixedUpdate")]
    class PlayerCollisionPatchFixedUpdate
    {
        private static bool Prefix(CharacterData ___data)
        {
            CharacterDataDevNullData data = ___data.GetDevNullData();
            if (data.reverseControls)
            {
                ___data.input.direction *= -1f;
            }
            return true;
        }
    }
}
