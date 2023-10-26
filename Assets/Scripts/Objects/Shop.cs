using Assets.Scripts.Common;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    /// <summary>
    /// Магазин.
    /// </summary>
    public class Shop : Interactive
    {
        protected override void OnTriggerEnter(Collider other) => OpenShopScreen(other);

        protected override void OnTriggerStay(Collider other) => OpenShopScreen(other);

        /// <summary>
        /// Метод открытия окна магазина при подходе игрока
        /// </summary>
        /// <param name="other">игрок</param>
        private void OpenShopScreen(Collider other)
        {
            if (!other.CompareTag(Game.PlayerTag)) return;
            if (!Game.MoveToTrade) return;
            base.OnTriggerEnter(other);
            if (Game.MoveToTrade && Game.MoveToTradePosition == transform.position) Game.MoveToTrade = false;
            if (Game.WaitForClick) return;
            Game.TradeScreen.gameObject.SetActive(true);
            Game.WaitForClick = true;
        }
    }
}