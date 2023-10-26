using UnityEngine;

namespace Assets.Scripts.Objects
{
    /// <summary>
    /// Настройки торговли в магазине.
    /// </summary>
    [CreateAssetMenu(fileName = "Trade Settings", menuName = "Game/Interactive/Trade Settings")]
    public class TradeSettings : ScriptableObject
    {
        public int WoodCost; // стоимость единицы дерева
        public int StoneCost; // стоимость единицы камня

        public int AxeInitialCost; // начальная стоимость топора
        public float AxeUpgradeGrowthRate; // коэффициента роста стоимости топора

        public int PickInitialCost; // начальная стоимость кирки
        public float PickUpgradeGrowthRate; // коэффициент роста стоимости кирки
    }
}