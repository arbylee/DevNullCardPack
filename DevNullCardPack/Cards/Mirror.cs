using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using DevNullCardPack.MonoBehaviours;
using DevNullCardPack.Extensions;

namespace DevNullCardPack.Cards
{
    class Mirror : CustomCard
    {
        private MonoBehaviours.MirrorAttacher mirrorAttacher;
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
            cardInfo.allowMultiple = false;
            statModifiers.health = 1.5f;
            gun.ammo = 2;
            gun.reloadTime = 0.8f;
            UnityEngine.Debug.Log($"[{DevNullCardPack.ModInitials}][Card] {GetTitle()} has been setup.");
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Edits values on player when card is selected
            data.GetDevNullData().reverseControlsOnStart = true;
            data.GetDevNullData().reverseControls = true;
            mirrorAttacher = player.gameObject.GetOrAddComponent<MirrorAttacher>();
            UnityEngine.Debug.Log($"[{DevNullCardPack.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Run when the card is removed from the player
            Destroy(mirrorAttacher);
            data.GetDevNullData().reverseControlsOnStart = false;
            data.GetDevNullData().reverseControls = false;
            UnityEngine.Debug.Log($"[{DevNullCardPack.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}.");
        }

        protected override string GetTitle()
        {
            return "Mirror";
        }
        protected override string GetDescription()
        {
            return "Flips your controls and the controls of anyone you hit!";
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
                    positive = false,
                    stat = "Movement controls",
                    amount = "Flip",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Target controls on hit",
                    amount = "Flip",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Health",
                    amount = "+50%",
                    simepleAmount = CardInfoStat.SimpleAmount.aLotOf
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Reload time",
                    amount = "-20%",
                    simepleAmount = CardInfoStat.SimpleAmount.Some
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Ammo",
                    amount = "+2",
                    simepleAmount = CardInfoStat.SimpleAmount.Some
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
