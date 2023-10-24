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
        public int TreeCollectCost; // стоимость дерева

        public float RockRestoreTime; // время восстановления уровня камня
        public int RockCollectCost; // стоимость камня
    }
}