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
        public string GroundTag = "Ground";
    }
}
