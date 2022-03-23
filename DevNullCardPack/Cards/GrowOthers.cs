using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using DevNullCardPack.MonoBehaviours;

namespace DevNullCardPack.Cards
{
    class GrowOthers : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
            cardInfo.allowMultiple = false;
            gun.damage = 0.3f;

            UnityEngine.Debug.Log($"[{DevNullCardPack.ModInitials}][Card] {GetTitle()} has been setup.");
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Edits values on player when card is selected
            player.gameObject.GetOrAddComponent<GrowOthersAttacher>();

            UnityEngine.Debug.Log($"[{DevNullCardPack.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");

        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Run when the card is removed from the player
            UnityEngine.Debug.Log($"[{DevNullCardPack.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}.");
        }

        protected override string GetTitle()
        {
            return "Grow Others";
        }
        protected override string GetDescription()
        {
            return "Targets you hit grow larger";
        }
        protected override GameObject GetCardArt()
        {
            return null;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Common;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Size",
                    amount = "10%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Damage",
                    amount = "-70%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.ColdBlue;
        }
        public override string GetModName()
        {
            return DevNullCardPack.ModInitials;
        }
    }
}
