using UnityEngine;

namespace Assets.Scripts.Common
{
    /// <summary>
    /// Инвентарь.
    /// </summary>
    public class Inventory : MonoBehaviour
    {
        public int WoodAmount { get; private set; }
        public int StoneAmount { get; private set; }

        /// <summary>
        /// Метод добавления дерева в инвентарь
        /// </summary>
        /// <param name="amount">количество дерева</param>
        public void AddWood(int amount) => WoodAmount += amount;
        
        /// <summary>
        /// Метод добавления камня в инвентарь
        /// </summary>
        /// <param name="amount">количество камня</param>
        public void AddStone(int amount) => StoneAmount += amount;
    }
}