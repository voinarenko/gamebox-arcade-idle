using Assets.Scripts.Common;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    /// <summary>
    /// Собираемое дерево.
    /// </summary>
    public class CollectableTree : Collectable
    {
        protected override void Start()
        {
            base.Start();
            RestoreTime = Settings.TreeRestoreTime;
        }

        protected override void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Game.PlayerTag)) return;
            if (!Game.MoveToCollect) return;
            base.OnTriggerEnter(other);
            Game.NearTree = true;
            Game.NearRock = false;
            if (transform.position != Game.MoveToCollectPosition) return;
            Chop();
        }

        protected override void OnTriggerStay(Collider other)
        {
            if (!other.CompareTag(Game.PlayerTag)) return;
            if (!Game.MoveToCollect) return;
            base.OnTriggerStay(other);
            Game.NearTree = true;
            Game.NearRock = false;
            if (transform.position != Game.MoveToCollectPosition) return;
            Chop();
        }

        protected override void OnTriggerExit(Collider other)
        {
            Game.NearTree = false;
            base.OnTriggerExit(other);
        }

        /// <summary>
        /// Метод рубки дерева
        /// </summary>
        private void Chop()
        {
            if (Game.WaitForClick) return;
            if (!Game.Axe) return;
            Collect();
            var collectAmount = Game.GetComponent<Inventory>().GetAmount(0);
            Game.AddWood(collectAmount);
            Game.WaitForClick = true;
        }
    }
}