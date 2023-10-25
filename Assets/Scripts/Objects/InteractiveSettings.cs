using UnityEngine;

namespace Assets.Scripts.Objects
{
    /// <summary>
    /// Настройки собираемых ресурсов.
    /// </summary>
    [CreateAssetMenu(fileName = "Interactive Settings", menuName = "Game/Interactive/Settings")]
    public class InteractiveSettings : ScriptableObject
    {
        public Color SelectionColor; // цвет выделения

        public float TreeRestoreTime; // время восстановления уровня дерева
        public int WoodCollectAmount; // базовое количество собираемого дерева
        public int WoodCost; // стоимость единицы дерева

        public float RockRestoreTime; // время восстановления уровня камня
        public int StoneCollectAmount; // базовое количество собираемого камня
        public int StoneCost; // стоимость единицы камня
    }
}