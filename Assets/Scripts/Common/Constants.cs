using UnityEngine;

namespace Assets.Scripts.Common
{
    /// <summary>
    /// ����� ���������.
    /// </summary>
    [CreateAssetMenu(fileName = "Game Constants", menuName = "Game/Global/Constants")]
    public class Constants : ScriptableObject
    {
        public string PlayerSettingsPath = "ScriptableObjects/PlayerSettings";
        public string GroundTag = "Ground";
    }
}
