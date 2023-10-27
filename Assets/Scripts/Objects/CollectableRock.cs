using Assets.Scripts.Common;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    /// <summary>
    /// Собираемый камень.
    /// </summary>
    public class CollectableRock : Collectable
    {
        protected override void Start()
        {
            base.Start();
            RestoreTime = Settings.RockRestoreTime;
        }

        protected override void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Game.PlayerTag)) return;
            if (!Game.MoveToCollect) return;
            base.OnTriggerEnter(other);
            Game.NearRock = true;
            Game.NearTree = false;
            if (transform.position != Game.MoveToCollectPosition) return;
            Mine();
        }

        protected override void OnTriggerStay(Collider other)
        {
            if (!other.CompareTag(Game.PlayerTag)) return;
            if (!Game.MoveToCollect) return;
            base.OnTriggerStay(other);
            Game.NearRock = true;
            Game.NearTree = false;
            if (transform.position != Game.MoveToCollectPosition) return;
            Mine();
        }

        protected override void OnTriggerExit(Collider other)
        {
            Game.NearRock = false;
            base.OnTriggerExit(other);
        }

        /// <summary>
        /// Метод добычи камня
        /// </summary>
        private void Mine()
        {
            if (Game.WaitForClick) return;
            if (!Game.Pick) return;
            Collect();
            var collectAmount = Game.GetComponent<Inventory>().GetAmount(1);
            Game.AddStone(collectAmount);
            Game.WaitForClick = true;
        }
    }
}