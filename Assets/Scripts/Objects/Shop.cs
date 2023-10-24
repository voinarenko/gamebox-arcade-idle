using UnityEngine;

namespace Assets.Scripts.Objects
{
    /// <summary>
    /// Магазин.
    /// </summary>
    public class Shop : Interactive
    {
        protected override void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Game.PlayerTag)) return;
            base.OnTriggerEnter(other);
            if (Game.MoveToTrade && Game.MoveToTradePosition == transform.position) Game.MoveToTrade = false;
        }

        protected override void OnTriggerStay(Collider other)
        {
            if (!other.CompareTag(Game.PlayerTag)) return;
            base.OnTriggerEnter(other);
            if (Game.MoveToTrade && Game.MoveToTradePosition == transform.position) Game.MoveToTrade = false;
        }
    }
}