using UnityEngine;

namespace Assets.Scripts.Objects
{
    /// <summary>
    /// Настройки собираемых ресурсов.
    /// </summary>
    [CreateAssetMenu(fileName = "Collectables Settings", menuName = "Game/Collectables/Settings")]
    public class CollectablesSettings : ScriptableObject
    {
        public Color SelectionColor;

        public float TreeRestoreTime;
        public int TreeCollectCost;

        public float RockRestoreTime;
        public int RockCollectCost;
    }
}