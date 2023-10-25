using UnityEngine;

namespace Assets.Scripts.Common
{
    /// <summary>
    /// ����� ���������.
    /// </summary>
    [CreateAssetMenu(fileName = "Game Constants", menuName = "Game/Global/Constants")]
    public class Constants : ScriptableObject
    {
        // ������� ����
        public string GroundPrefabPath = "Prefabs/Ground";

        // �����
        public string PlayerPrefabPath = "Prefabs/Player";

        // �������
        public string TreePrefabPath = "Prefabs/Tree";
        public string RockPrefabPath = "Prefabs/Rock";
        public string ShopPrefabPath = "Prefabs/Shop";

        // �����
        public string GroundTag = "Ground";
        public string PlayerTag = "Player";
        public string ObjectsTag = "Objects";
        public string ShopTag = "Shop";
        public string TreeTag = "Tree";
        public string RockTag = "Rock";
    }
}
