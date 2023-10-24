using UnityEngine;

namespace Assets.Scripts.Common
{
    /// <summary>
    /// ����� ���������.
    /// </summary>
    [CreateAssetMenu(fileName = "Game Constants", menuName = "Game/Global/Constants")]
    public class Constants : ScriptableObject
    {
        // �����
        public string PlayerPrefabPath = "Prefabs/Player";
        public string PlayerSettingsPath = "ScriptableObjects/PlayerSettings";

        // �������
        public string TreePrefabPath = "Prefabs/Tree";
        public string RockPrefabPath = "Prefabs/Rock";
        public string ShopPrefabPath = "Prefabs/Shop";
        public string InteractiveSettingsPath = "ScriptableObjects/InteractiveSettings";

        // �����
        public string GroundTag = "Ground";
        public string PlayerTag = "Player";
        public string ObjectsTag = "Objects";
        public string ShopTag = "Shop";
        public string TreeTag = "Tree";
        public string RockTag = "Rock";
    }
}
