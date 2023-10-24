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
            base.OnTriggerEnter(other);
            Game.NearTree = true;
            Game.NearRock = false;
            Chop();
        }

        protected override void OnTriggerStay(Collider other)
        {
            if (!other.CompareTag(Game.PlayerTag)) return;
            base.OnTriggerStay(other);
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
            Collect();
            Game.AddWood(Settings.TreeCollectAmount);
            Game.WaitForClick = true;
        }
    }
}