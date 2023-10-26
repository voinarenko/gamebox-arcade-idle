using Assets.Scripts.Objects;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Common
{
    /// <summary>
    /// Игра.
    /// </summary>
    public class Game : MonoBehaviour
    {
        private const string ConstantsPath = "ScriptableObjects/GameConstants"; // путь к файлу констант
        private Constants Constants { get; set; }
        private Player.Player _player;
        private Inventory Inventory => GetComponent<Inventory>();
        public TradeSettings TradeSettings => FindAnyObjectByType<Interactive>().TradeSettings;

        // метки
        public string GroundTag { get; private set; } // метка земли
        public string PlayerTag { get; private set; } // метка игрока
        public string ShopTag { get; private set; } // метка магазина
        public string TreeTag { get; private set; } // метка дерева
        public string RockTag { get; private set; } // метка камня

        private Transform _objects; // объекты

        public Vector3 MousePosition { get; internal set; } // координаты мыши на плоскости
        public bool MoveToCollect { get; internal set; } // движение к ресурсу
        public bool MoveToTrade { get; internal set; } // движение к магазину
        public Vector3 MoveToCollectPosition { get; internal set; } // координаты ресурса
        public Vector3 MoveToTradePosition { get; internal set; } // координаты магазина
        public bool WaitForClick { get; internal set; } // ожидание нажатия кнопки мыши
        public bool NearTree { get; internal set; } // игрок возле дерева
        public bool NearRock { get; internal set; } // игрок возле камня

        //инструменты
        public bool Axe { get; set; } // топор
        public bool Pick { get; set; } // кирка

        // экраны
        public bool OverUi { get; set; } // мышь над интерфейсом
        public static TradeScreen TradeScreen => FindAnyObjectByType<TradeScreen>(FindObjectsInactive.Include);

        private void Start()
        {
            Constants = Resources.Load<Constants>(ConstantsPath);

            #region Загрузка и инициализация объектов

            var groundPrefab = Resources.Load(Constants.GroundPrefabPath);
            Instantiate(groundPrefab, transform);
            GroundTag = Constants.GroundTag;

            var playerPrefab = Resources.Load(Constants.PlayerPrefabPath);
            Instantiate(playerPrefab, transform);
            _player = GetComponentInChildren<Player.Player>();
            PlayerTag = Constants.PlayerTag;

            _objects = GameObject.FindWithTag(Constants.ObjectsTag).transform;

            var shopPrefab = Resources.Load(Constants.ShopPrefabPath);
            Instantiate(shopPrefab, _objects);
            ShopTag = Constants.ShopTag;

            var treePrefab = Resources.Load(Constants.TreePrefabPath);
            Instantiate(treePrefab, _objects);
            TreeTag = Constants.TreeTag;

            var rockPrefab = Resources.Load(Constants.RockPrefabPath);
            Instantiate(rockPrefab, _objects);
            RockTag = Constants.RockTag;

            #endregion

            Axe = Inventory.Axe;
            Pick = Inventory.Pick;
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

        /// <summary>
        /// Метод добавления дерева в инвентарь
        /// </summary>
        /// <param name="amount">количество дерева</param>
        public void AddMoney(int amount) => Inventory.AddMoney(amount);

        /// <summary>
        /// Метод вычитания денег из инвентаря
        /// </summary>
        /// <param name="amount">количество денег</param>
        public void RemoveMoney(int amount) => Inventory.RemoveMoney(amount);

        /// <summary>
        /// Метод добавления дерева в инвентарь
        /// </summary>
        /// <param name="amount">количество дерева</param>
        public void AddWood(int amount) => Inventory.AddWood(amount);

        /// <summary>
        /// Метод вычитания дерева из инвентаря
        /// </summary>
        /// <param name="amount">количество дерева</param>
        public void RemoveWood(int amount) => Inventory.RemoveWood(amount);
        
        /// <summary>
        /// Метод добавления камня в инвентарь
        /// </summary>
        /// <param name="amount">количество камня</param>
        public void AddStone(int amount) => Inventory.AddStone(amount);

        /// <summary>
        /// Метод вычитания камня из инвентаря
        /// </summary>
        /// <param name="amount">количество камня</param>
        public void RemoveStone(int amount) => Inventory.RemoveStone(amount);

    }
}