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
        private const string ConstantsPath = "ScriptableObjects/GameConstants"; // путь к файлу констант
        public Constants Constants { get; private set; }
        private Player.Player _player;
        public string PlayerTag { get; private set; } // метка игрока
        public string ShopTag { get; set; } // метка магазина
        public string TreeTag { get; private set; } // метка дерева
        public string RockTag { get; private set; } // метка камня
        public PlayerSettings PlayerSettings { get; private set; }
        public InteractiveSettings InteractiveSettings { get; private set; }


        private Transform _objects; // объекты

        public Vector3 MousePosition { get; internal set; } // координаты мыши на плоскости
        public bool MoveToCollect;// { get; internal set; } // движение к ресурсу
        public bool MoveToTrade;// { get; internal set; } // движение к магазину
        public Vector3 MoveToCollectPosition;// { get; internal set; } // координаты ресурса
        public Vector3 MoveToTradePosition;// { get; internal set; } // координаты магазина
        public bool WaitForClick;// { get; internal set; } // ожидание нажатия кнопки мыши
        public bool NearTree;// { get; internal set; } // игрок возле дерева
        public bool NearRock;// { get; internal set; } // игрок возле камня

        private void Start()
        {
            Constants = Resources.Load<Constants>(ConstantsPath);
            PlayerSettings = Resources.Load<PlayerSettings>(Constants.PlayerSettingsPath);
            InteractiveSettings = Resources.Load<InteractiveSettings>(Constants.InteractiveSettingsPath);

            var playerPrefab = Resources.Load<Player.Player>(Constants.PlayerPrefabPath);
            Instantiate(playerPrefab, transform);
            _player = GetComponentInChildren<Player.Player>();
            PlayerTag = Constants.PlayerTag;

            _objects = GameObject.FindWithTag(Constants.ObjectsTag).transform;

            var shopPrefab = Resources.Load<Shop>(Constants.ShopPrefabPath);
            Instantiate(shopPrefab, _objects);
            ShopTag = Constants.ShopTag;

            var treePrefab = Resources.Load<CollectableTree>(Constants.TreePrefabPath);
            Instantiate(treePrefab, _objects);
            TreeTag = Constants.TreeTag;

            var rockPrefab = Resources.Load<CollectableRock>(Constants.RockPrefabPath);
            Instantiate(rockPrefab, _objects);
            RockTag = Constants.RockTag;
        }


        /// <summary>
        /// Метод движения игрока
        /// </summary>
        /// <param name="position">координаты цели</param>
        public void Move(Vector3 position) => _player.Move(position);

        /// <summary>
        /// Метод остановки движения игрока
        /// </summary>
        /// <param name="other">игрок</param>
        public static void StopMoving(Player.Player other) => other.StopMoving();
    }
}