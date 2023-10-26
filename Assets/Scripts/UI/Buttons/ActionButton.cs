using System;
using Assets.Scripts.Common;
using Assets.Scripts.Objects;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI.Buttons
{
    /// <summary>
    /// Кнопка продажи.
    /// </summary>
    public class ActionButton : Button
    {
        private Game Game => GetComponentInParent<Screen>().Game; 
        private TradeSettings Settings => Game.TradeSettings;
        private Inventory Inventory => Game.GetComponent<Inventory>();

        public override void OnPointerClick(PointerEventData eventData)
        {
            var item = GetComponent<Item>();
            
            if (item.Resource){
                switch (item.Id)
                {
                    case 0:
                        Game.AddMoney(Settings.WoodCost * item.Amount);
                        Game.RemoveWood(item.Amount);
                        Destroy(gameObject);
                        break;
                    case 1:
                        Game.AddMoney(Settings.StoneCost * item.Amount);
                        Game.RemoveStone(item.Amount);
                        Destroy(gameObject);
                        break;
                }
            }
            else
            {
                switch (item.Id)
                {
                    case 0:
                        var axePrice = Convert.ToInt32(Settings.AxeInitialCost *
                                                    Math.Exp(Settings.AxeUpgradeGrowthRate * (Inventory.AxeLevel + 1)));
                        if (axePrice > Inventory.MoneyAmount) return;
                        Game.RemoveMoney(axePrice);
                        Inventory.AxeLevel++;
                        break;
                    case 1:
                        var pickPrice = Convert.ToInt32(Settings.PickInitialCost *
                                                    Math.Exp(Settings.PickUpgradeGrowthRate * (Inventory.PickLevel + 1)));
                        if (pickPrice > Inventory.MoneyAmount) return;
                        Game.RemoveMoney(pickPrice);
                        Inventory.PickLevel++;
                        Inventory.CheckPick();
                        break;
                }
                item.Init(item.Id);
            }
        }
    }
}