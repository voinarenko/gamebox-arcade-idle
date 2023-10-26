using Assets.Scripts.Common;
using System;
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
            Mine();
        }

        protected override void OnTriggerStay(Collider other)
        {
            if (!other.CompareTag(Game.PlayerTag)) return;
            if (!Game.MoveToCollect) return;
            base.OnTriggerStay(other);
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
            var collectAmount = Convert.ToInt32(Settings.StoneCollectAmount + Settings.StoneCollectAmount * Settings.StoneCollectCoefficient * Game.GetComponent<Inventory>().PickLevel);
            Game.AddStone(collectAmount);
            Game.WaitForClick = true;
        }
    }
}