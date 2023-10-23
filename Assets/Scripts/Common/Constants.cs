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

        // объекты
        public string TreePrefabPath = "Prefabs/Tree";
        public string RockPrefabPath = "Prefabs/Rock";
        public string CollectablesSettingsPath = "ScriptableObjects/CollectablesSettings";

        // метки
        public string GroundTag = "Ground";
        public string PlayerTag = "Player";
        public string ObjectsTag = "Objects";
        public string TreeTag = "Tree";
        public string RockTag = "Rock";
    }
}
