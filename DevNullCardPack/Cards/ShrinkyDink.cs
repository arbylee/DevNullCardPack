using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using DevNullCardPack.MonoBehaviours;

namespace DevNullCardPack.Cards
{
    class ShrinkyDink : CustomCard
    {
        private MonoBehaviours.ShrinkyDinkAttacher shrinkyDinkAttacher;
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
            cardInfo.allowMultiple = false;
            statModifiers.lifeSteal = 0.10f;
            block.cdMultiplier = 1.15f;
            UnityEngine.Debug.Log($"[{DevNullCardPack.ModInitials}][Card] {GetTitle()} has been setup.");
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Edits values on player when card is selected
            shrinkyDinkAttacher = player.gameObject.GetOrAddComponent<ShrinkyDinkAttacher>();

            UnityEngine.Debug.Log($"[{DevNullCardPack.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");

        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Run when the card is removed from the player
            Destroy(shrinkyDinkAttacher);
            UnityEngine.Debug.Log($"[{DevNullCardPack.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}.");
        }

        protected override string GetTitle()
        {
            return "Shrinky Dink";
        }
        protected override string GetDescription()
        {
            return "Hitting enemies cause you to shrink.\nShrink yo'self before you dink yo'self";
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
                    stat = "Size per hit",
                    amount = "-15%",
                    simepleAmount = CardInfoStat.SimpleAmount.aLittleBitOf
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Life steal",
                    amount = "+10%",
                    simepleAmount = CardInfoStat.SimpleAmount.aLittleBitOf
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Block cooldown",
                    amount = "+15%",
                    simepleAmount = CardInfoStat.SimpleAmount.aLittleBitOf
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
