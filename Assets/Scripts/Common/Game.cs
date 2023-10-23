using UnityEngine;

namespace Assets.Scripts.Common
{
    /// <summary>
    /// Игра.
    /// </summary>
    public class Game : MonoBehaviour
    {
        private const string ConstantsPath = "ScriptableObjects/GameConstants";
        public Constants Constants { get; private set; } // константы
        public Player.Player Player { get; private set; } // игрок

        public Vector3 MousePosition { get; set; } // координаты мыши на плоскости

        private void Start()
        {
            Constants = Resources.Load<Constants>(ConstantsPath);
            var playerPrefab = Resources.Load<Player.Player>(Constants.PlayerPrefabPath);
            Instantiate(playerPrefab, transform);
            Player = GetComponentInChildren<Player.Player>();
        }
    }
}