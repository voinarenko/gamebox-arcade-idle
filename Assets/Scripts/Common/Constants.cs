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

        // �����
        public string GroundTag = "Ground";
        public string PlayerTag = "Player";

        // ��������
        public string PlayerWalkAnimLabel = "Walking";
    }
}
