using Assets.Scripts.Common;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    /// <summary>
    ///     Интерактивный объект.
    /// </summary>
    public class Interactive : MonoBehaviour
    {
        private const string
            InteractiveSettingsPath = "ScriptableObjects/InteractiveSettings"; // файл настроек объектов

        private const string TradeSettingsPath = "ScriptableObjects/TradeSettings"; // файл настроек торговли
        public Game Game;
        public InteractiveSettings Settings => Resources.Load<InteractiveSettings>(InteractiveSettingsPath);
        public TradeSettings TradeSettings => Resources.Load<TradeSettings>(TradeSettingsPath);

        protected virtual void Start()
        {
            Game = GetComponentInParent<Game>();
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Game.PlayerTag) &&
                ((Game.MoveToCollectPosition == transform.position && Game.MoveToCollect) ||
                 (Game.MoveToTradePosition == transform.position && Game.MoveToTrade)))
                Game.StopMoving(other.GetComponent<Player.Player>());
        }

        protected virtual void OnTriggerStay(Collider other)
        {
            if (other.CompareTag(Game.PlayerTag) &&
                ((Game.MoveToCollectPosition == transform.position && Game.MoveToCollect) ||
                 (Game.MoveToTradePosition == transform.position && Game.MoveToTrade)))
                Game.StopMoving(other.GetComponent<Player.Player>());
        }

        protected virtual void OnTriggerExit(Collider other)
        {
            Game.WaitForClick = false;
        }
    }
}