using UnityEngine;

namespace Assets.Scripts.Common
{
    /// <summary>
    /// Общие константы.
    /// </summary>
    [CreateAssetMenu(fileName = "Game Constants", menuName = "Game/Global/Constants")]
    public class Constants : ScriptableObject
    {
        public string PlayerSettingsPath = "ScriptableObjects/PlayerSettings";

        // метки
        public string GroundTag = "Ground";

        // анимация
        public string PlayerWalkAnimLabel = "Walking";
    }
}
