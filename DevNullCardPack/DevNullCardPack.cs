using BepInEx;
using UnboundLib;
using UnboundLib.Cards;
using DevNullCardPack.Cards;
using HarmonyLib;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;
using Jotunn.Utils;
using UnityEngine;

namespace DevNullCardPack
{
    // These are the mods required for our mod to work
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch", BepInDependency.DependencyFlags.HardDependency)]

    // Declares our mod to Bepin
    [BepInPlugin(ModId, ModName, Version)]
    // The game our mod is associated with
    [BepInProcess("Rounds.exe")]
    public class DevNullCardPack : BaseUnityPlugin
    {
        public static DevNullCardPack instance { get; private set; }
        private const string ModId = "com.arbylee.rounds.DevNullCardPack";
        private const string ModName = "DevNullCardPack";
        public const string Version = "0.8.0"; // What version are we on (major.minor.patch)?
        public const string ModInitials = "DNCP";

        internal static AssetBundle ArtAssets;

        void Awake()
        {
            // Use this to call any harmony patch files your mod may have
            var harmony = new Harmony(ModId);
            harmony.PatchAll();
        }
        void Start()
        {

            DevNullCardPack.ArtAssets = AssetUtils.LoadAssetBundleFromResources("dncp_asset_bundle", typeof(DevNullCardPack).Assembly);
            CustomCard.BuildCard<GrowOthers>();
            CustomCard.BuildCard<ShrinkyDink>();
            CustomCard.BuildCard<Mirror>();
            //CustomCard.BuildCard<RapidFire>();
            instance = this;
        }

    }
}
