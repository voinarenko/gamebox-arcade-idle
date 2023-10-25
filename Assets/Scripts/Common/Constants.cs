using UnityEngine;

namespace Assets.Scripts.Common
{
    /// <summary>
    /// Общие константы.
    /// </summary>
    [CreateAssetMenu(fileName = "Game Constants", menuName = "Game/Global/Constants")]
    public class Constants : ScriptableObject
    {
        // игровое поле
        public string GroundPrefabPath = "Prefabs/Ground";

        // игрок
        public string PlayerPrefabPath = "Prefabs/Player";

        // объекты
        public string TreePrefabPath = "Prefabs/Tree";
        public string RockPrefabPath = "Prefabs/Rock";
        public string ShopPrefabPath = "Prefabs/Shop";

        // метки
        public string GroundTag = "Ground";
        public string PlayerTag = "Player";
        public string ObjectsTag = "Objects";
        public string ShopTag = "Shop";
        public string TreeTag = "Tree";
        public string RockTag = "Rock";
    }
}
