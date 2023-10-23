using Assets.Scripts.Objects;
using Assets.Scripts.Player;
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
        private Player.Player _player; // игрок
        public string PlayerTag { get; private set; }
        public PlayerSettings PlayerSettings { get; private set; } // параметры игрока
        public CollectablesSettings CollectablesSettings { get; private set; } // параметры собираемых ресурсов


        private Transform _objects; // объекты

        public Vector3 MousePosition { get; internal set; } // координаты мыши на плоскости
        public bool MoveToCollect { get; internal set; }

        private void Start()
        {
            Constants = Resources.Load<Constants>(ConstantsPath);
            PlayerSettings = Resources.Load<PlayerSettings>(Constants.PlayerSettingsPath);
            CollectablesSettings = Resources.Load<CollectablesSettings>(Constants.CollectablesSettingsPath);

            var playerPrefab = Resources.Load<Player.Player>(Constants.PlayerPrefabPath);
            Instantiate(playerPrefab, transform);
            _player = GetComponentInChildren<Player.Player>();
            PlayerTag = Constants.PlayerTag;

            _objects = GameObject.FindWithTag(Constants.ObjectsTag).transform;

            var treePrefab = Resources.Load<CollectableTree>(Constants.TreePrefabPath);
            Instantiate(treePrefab, _objects);

            var rockPrefab = Resources.Load<CollectableRock>(Constants.RockPrefabPath);
            Instantiate(rockPrefab, _objects);
        }

        public void Move(Vector3 position) => _player.Move(position);

        public void StopMoving(Player.Player other) => other.StopMoving();
    }
}