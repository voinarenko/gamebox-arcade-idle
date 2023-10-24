using Assets.Scripts.Common;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    /// <summary>
    /// Интерактивный объект.
    /// </summary>
    public class Interactive : MonoBehaviour
    {
        protected Game Game;
        public InteractiveSettings Settings { get; private set; }

        protected virtual void Start()
        {
            Game = GetComponentInParent<Game>();
            Settings = Game.InteractiveSettings;
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Game.PlayerTag) && ((Game.MoveToCollectPosition == transform.position && Game.MoveToCollect) || 
                                                     (Game.MoveToTradePosition == transform.position && Game.MoveToTrade))) 
                Game.StopMoving(other.GetComponent<Player.Player>());
        }

        protected virtual void OnTriggerStay(Collider other)
        {
            if (other.CompareTag(Game.PlayerTag) && ((Game.MoveToCollectPosition == transform.position && Game.MoveToCollect) || 
                                                     (Game.MoveToTradePosition == transform.position && Game.MoveToTrade))) 
                Game.StopMoving(other.GetComponent<Player.Player>());
        }

        protected virtual void OnTriggerExit(Collider other) => Game.WaitForClick = false;
    }
}