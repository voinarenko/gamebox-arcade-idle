using Assets.Scripts.Objects;
using Assets.Scripts.UI.Screens;
using UnityEngine;

namespace Assets.Scripts.Common
{
    /// <summary>
    ///     Игра.
    /// </summary>
    public class Game : MonoBehaviour
    {
        // пути к файлам
        private const string GroundPrefabPath = "Prefabs/Ground"; // путь к файлу земли
        private const string PlayerPrefabPath = "Prefabs/Player"; // путь к файлу игрока
        private const string TreePrefabPath = "Prefabs/Tree"; // путь к файлу дерева
        private const string RockPrefabPath = "Prefabs/Rock"; // путь к файлу скалы
        private const string ShopPrefabPath = "Prefabs/Shop"; // путь к файлу магазина

        // метки
        public const string GroundTag = "Ground"; // метка земли
        public const string PlayerTag = "Player"; // метка игрока
        private const string ObjectsTag = "Objects"; // метка места генерации объектов
        public const string ShopTag = "Shop"; // метка магазина
        public const string TreeTag = "Tree"; // метка дерева
        public const string RockTag = "Rock"; // метка камня

        private Transform _objects; // объекты
        private Player.Player _player;
        public bool MoveToCollect; // { get; internal set; } // движение к ресурсу
        public bool MoveToTrade; // { get; internal set; } // движение к магазину
        public bool NearRock; // { get; internal set; } // игрок возле камня
        public bool NearTree; // { get; internal set; } // игрок возле дерева
        public bool WaitForClick; // { get; internal set; } // ожидание нажатия кнопки мыши
        public Inventory Inventory => GetComponent<Inventory>();
        public static TradeSettings TradeSettings => FindAnyObjectByType<Interactive>().TradeSettings;
        public static TradeScreen TradeScreen => FindAnyObjectByType<TradeScreen>(FindObjectsInactive.Include);

        public static PickRequiredScreen PickRequiredScreen =>
            FindAnyObjectByType<PickRequiredScreen>(FindObjectsInactive.Include);

        public Vector3 MousePosition { get; internal set; } // координаты мыши на плоскости
        public Vector3 MoveToCollectPosition { get; internal set; } // координаты ресурса
        public Vector3 MoveToTradePosition { get; internal set; } // координаты магазина
        public bool OverUi { get; set; } // мышь над интерфейсом
        public Tooltip Tooltip => FindAnyObjectByType<Tooltip>(FindObjectsInactive.Include);

        private void Start()
        {
            FindAnyObjectByType<ManualScreen>(FindObjectsInactive.Include).gameObject.SetActive(true);

            var groundPrefab = Resources.Load(GroundPrefabPath);
            Instantiate(groundPrefab, transform);

            var playerPrefab = Resources.Load(PlayerPrefabPath);
            Instantiate(playerPrefab, transform);
            _player = GetComponentInChildren<Player.Player>();

            _objects = GameObject.FindWithTag(ObjectsTag).transform;

            var shopPrefab = Resources.Load(ShopPrefabPath);
            Instantiate(shopPrefab, _objects);

            var treePrefab = Resources.Load(TreePrefabPath);
            Instantiate(treePrefab, _objects);

            var rockPrefab = Resources.Load(RockPrefabPath);
            Instantiate(rockPrefab, _objects);
        }

        /// <summary>
        ///     Метод движения игрока
        /// </summary>
        /// <param name="position">координаты цели</param>
        public void Move(Vector3 position)
        {
            _player.Move(position);
        }

        /// <summary>
        ///     Метод остановки движения игрока
        /// </summary>
        /// <param name="other">игрок</param>
        public static void StopMoving(Player.Player other)
        {
            other.StopMoving();
        }

        /// <summary>
        ///     Метод добавления дерева в инвентарь
        /// </summary>
        /// <param name="amount">количество дерева</param>
        public void AddMoney(int amount)
        {
            Inventory.AddMoney(amount);
        }

        /// <summary>
        ///     Метод вычитания денег из инвентаря
        /// </summary>
        /// <param name="amount">количество денег</param>
        public void RemoveMoney(int amount)
        {
            Inventory.RemoveMoney(amount);
        }

        /// <summary>
        ///     Метод добавления дерева в инвентарь
        /// </summary>
        /// <param name="amount">количество дерева</param>
        public void AddWood(int amount)
        {
            Inventory.AddWood(amount);
        }

        /// <summary>
        ///     Метод вычитания дерева из инвентаря
        /// </summary>
        /// <param name="amount">количество дерева</param>
        public void RemoveWood(int amount)
        {
            Inventory.RemoveWood(amount);
        }

        /// <summary>
        ///     Метод добавления камня в инвентарь
        /// </summary>
        /// <param name="amount">количество камня</param>
        public void AddStone(int amount)
        {
            Inventory.AddStone(amount);
        }

        /// <summary>
        ///     Метод вычитания камня из инвентаря
        /// </summary>
        /// <param name="amount">количество камня</param>
        public void RemoveStone(int amount)
        {
            Inventory.RemoveStone(amount);
        }
    }
}