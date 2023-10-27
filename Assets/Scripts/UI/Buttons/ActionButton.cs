using Assets.Scripts.Common;
using Assets.Scripts.Objects;
using Assets.Scripts.UI.Screens;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI.Buttons
{
    /// <summary>
    ///     Кнопка продажи.
    /// </summary>
    public class ActionButton : Button
    {
        private Game Game => GetComponentInParent<Screen>().Game;
        private static TradeSettings Settings => Game.TradeSettings;
        private Inventory Inventory => Game.GetComponent<Inventory>();

        public override void OnPointerClick(PointerEventData eventData)
        {
            var item = GetComponent<Item>();

            if (item.Resource)
            {
                switch (item.Id)
                {
                    case 0:
                        Game.AddMoney(Settings.WoodCost * item.Value);
                        Game.RemoveWood(item.Value);
                        Destroy(gameObject);
                        break;
                    case 1:
                        Game.AddMoney(Settings.StoneCost * item.Value);
                        Game.RemoveStone(item.Value);
                        Destroy(gameObject);
                        break;
                }
            }
            else
            {
                switch (item.Id)
                {
                    case 0:
                        var axePrice = Inventory.GetToolPrice(item.Id);
                        if (axePrice > Inventory.MoneyAmount) return;
                        Game.RemoveMoney(axePrice);
                        Inventory.AxeLevel++;
                        break;
                    case 1:
                        var pickPrice = Inventory.GetToolPrice(item.Id);
                        if (pickPrice > Inventory.MoneyAmount) return;
                        Game.RemoveMoney(pickPrice);
                        Inventory.PickLevel++;
                        Inventory.CheckPick();
                        break;
                }

                item.Init(item.Id);
                Inventory.SaveData();
            }
        }
    }
}