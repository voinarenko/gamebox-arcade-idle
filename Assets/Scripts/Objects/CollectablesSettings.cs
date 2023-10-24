using UnityEngine;

namespace Assets.Scripts.Objects
{
    /// <summary>
    /// Настройки собираемых ресурсов.
    /// </summary>
    [CreateAssetMenu(fileName = "Collectables Settings", menuName = "Game/Collectables/Settings")]
    public class CollectablesSettings : ScriptableObject
    {
        public Color SelectionColor; // цвет выделения

        public float TreeRestoreTime; // время восстановления уровня дерева
        public int TreeCollectCost; // стоимость дерева

        public float RockRestoreTime; // время восстановления уровня камня
        public int RockCollectCost; // стоимость камня
    }
}