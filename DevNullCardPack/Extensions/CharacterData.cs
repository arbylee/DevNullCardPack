using System;
using System.Runtime.CompilerServices;
using HarmonyLib;

namespace DevNullCardPack.Extensions
{
    // ADD FIELDS TO CHARACTERDATA
    [Serializable]
    public class CharacterDataDevNullData
    {
        public bool reverseControls;
        public bool reverseControlsOnStart;

        public CharacterDataDevNullData()
        {
            reverseControls = false;
            reverseControlsOnStart = false;
        }
    }
    public static class CharacterDataExtension
    {
        public static readonly ConditionalWeakTable<CharacterData, CharacterDataDevNullData> data =
            new ConditionalWeakTable<CharacterData, CharacterDataDevNullData>();

        public static CharacterDataDevNullData GetDevNullData(this CharacterData characterData)
        {
            return data.GetOrCreateValue(characterData);
        }

        public static void AddData(this CharacterData characterData, CharacterDataDevNullData value)
        {
            try
            {
                data.Add(characterData, value);
            }
            catch (Exception) { }
        }
    }
    // patch Player.FullReset to properly clear extra stats
    [HarmonyPatch(typeof(Player), "FullReset")]
    class PlayerPatchFullReset_CharacterDataExtension
    {
        private static void Prefix(Player __instance)
        {
            __instance.data.GetDevNullData().reverseControls = false;
            __instance.data.GetDevNullData().reverseControlsOnStart = false;
        }
    }
    
}
