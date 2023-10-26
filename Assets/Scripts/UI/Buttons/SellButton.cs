using Assets.Scripts.Common;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI.Buttons
{
    /// <summary>
    /// Кнопка продажи.
    /// </summary>
    public class SellButton : Button
    {
        private Game Game => GetComponentInParent<Screen>().Game; 

        public override void OnPointerClick(PointerEventData eventData)
        {
            var item = GetComponent<Item>();
            switch (item.ResourceId)
            {
                case 0:
                    Game.AddMoney(Game.InteractiveSettings.WoodCost * item.Amount);
                    Game.RemoveWood(item.Amount);
                    Destroy(gameObject);
                    break;
                case 1:
                    Game.AddMoney(Game.InteractiveSettings.StoneCost * item.Amount);
                    Game.RemoveStone(item.Amount);
                    Destroy(gameObject);
                    break;
            }
        }
    }
}