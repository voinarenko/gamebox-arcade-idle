using Assets.Scripts.Common;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    public class Interactive : MonoBehaviour
    {
        protected Game Game; // игра

        protected virtual void Start() => Game = GetComponentInParent<Game>();

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Game.PlayerTag)) Game.StopMoving(other.GetComponent<Player.Player>());
        }
    }
}