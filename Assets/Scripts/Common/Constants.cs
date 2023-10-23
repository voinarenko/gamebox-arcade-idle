using UnityEngine;

namespace Assets.Scripts.Common
{
    /// <summary>
    /// Общие константы.
    /// </summary>
    [CreateAssetMenu(fileName = "Game Constants", menuName = "Game/Global/Constants")]
    public class Constants : ScriptableObject
    {
        // игрок
        public string PlayerPrefabPath = "Prefabs/Player";
        public string PlayerSettingsPath = "ScriptableObjects/PlayerSettings";

        // метки
        public string GroundTag = "Ground";
        public string PlayerTag = "Player";

        // анимация
        public string PlayerWalkAnimLabel = "Walking";
    }
}
