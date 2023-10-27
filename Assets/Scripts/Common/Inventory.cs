using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Objects;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Screens;
using UnityEngine;

namespace Assets.Scripts.Common
{
    /// <summary>
    ///     Инвентарь.
    /// </summary>
    public class Inventory : MonoBehaviour
    {
        // экран магазина
        private const string ItemPrefabPath = "Prefabs/Item"; // путь к объекту предмета инвентаря

        // метки сохранения
        private const string MoneyLabel = "MoneyAmount"; // ключ для сохранения денег
        private const string AxeLevelLabel = "AxeLevel"; // ключ для сохранения уровня топора
        private const string PickObtainedLabel = "PickObtained"; // ключ для сохранения наличия кирки
        private const string PickLevelLabel = "PickLevel"; // ключ для сохранения кирки
        private GameObject _itemPrefab; // объект предмета инвентаря
        public static ResourcesAvailability ResourcesDisplay => FindAnyObjectByType<ResourcesAvailability>();
        private InteractiveSettings CollectSettings => FindAnyObjectByType<Interactive>().Settings;

        private static Transform SellParent =>
            FindAnyObjectByType<SellContent>(FindObjectsInactive.Include).transform; // место генерации ресурсов

        private static Transform BuyParent =>
            FindAnyObjectByType<BuyContent>(FindObjectsInactive.Include).transform; // место генерации инструментов

        // ресурсы
        public int MoneyAmount { get; private set; } // деньги
        public int WoodAmount { get; private set; } // дерево
        public int StoneAmount { get; private set; } // камень

        // инструменты
        public bool Axe { get; private set; } // топор
        public int AxeLevel { get; set; } // уровень топора
        public bool Pick { get; private set; } // кирка
        public int PickLevel { get; set; } // уровень кирки

        private void Start()
        {
            Axe = true;
            GetComponent<Game>().Axe = Axe;
            _itemPrefab = (GameObject)Resources.Load(ItemPrefabPath);
        }

        /// <summary>
        ///     Метод инициализации инструментов
        /// </summary>
        private void InitTools()
        {
            var itemPrefab = (GameObject)Resources.Load(ItemPrefabPath);
            var axe = Instantiate(itemPrefab, BuyParent);
            if (AxeLevel < 1) AxeLevel = 1;
            axe.GetComponent<Item>().Init(0);
            var pick = Instantiate(itemPrefab, BuyParent);
            if (!Pick) PickLevel = 0;
            else if (PickLevel < 1) PickLevel = 1;
            pick.GetComponent<Item>().Init(1);
        }

        /// <summary>
        ///     Метод проверки наличия кирки
        /// </summary>
        public void CheckPick()
        {
            Pick = PickLevel > 0;
        }

        /// <summary>
        ///     Метод добавления денег в инвентарь
        /// </summary>
        /// <param name="amount">количество денег</param>
        public void AddMoney(int amount)
        {
            MoneyAmount += amount;
            ResourcesDisplay.UpdateView();
            SaveResources();
        }

        /// <summary>
        ///     Метод вычитания денег из инвентаря
        /// </summary>
        /// <param name="amount">количество денег</param>
        public void RemoveMoney(int amount)
        {
            MoneyAmount -= amount;
            ResourcesDisplay.UpdateView();
            SaveResources();
        }

        /// <summary>
        ///     Метод добавления денег в инвентарь
        /// </summary>
        /// <param name="amount">количество денег</param>
        public void AddWood(int amount)
        {
            WoodAmount += amount;
            ResourcesDisplay.UpdateView();
            var item = Instantiate(_itemPrefab, SellParent);
            item.GetComponent<Item>().Init(0, amount);
            SaveResources();
        }

        /// <summary>
        ///     Метод вычитания дерева из инвентаря
        /// </summary>
        /// <param name="amount">количество дерева</param>
        public void RemoveWood(int amount)
        {
            WoodAmount -= amount;
            ResourcesDisplay.UpdateView();
            SaveResources();
        }

        /// <summary>
        ///     Метод добавления камня в инвентарь
        /// </summary>
        /// <param name="amount">количество камня</param>
        public void AddStone(int amount)
        {
            StoneAmount += amount;
            ResourcesDisplay.UpdateView();
            var item = Instantiate(_itemPrefab, SellParent);
            item.GetComponent<Item>().Init(1, amount);
            SaveResources();
        }

        /// <summary>
        ///     Метод вычитания камня из инвентаря
        /// </summary>
        /// <param name="amount">количество камня</param>
        public void RemoveStone(int amount)
        {
            StoneAmount -= amount;
            ResourcesDisplay.UpdateView();
            SaveResources();
        }

        /// <summary>
        ///     Метод загрузки сохранённых данных
        /// </summary>
        public void LoadData()
        {
            MoneyAmount = PlayerPrefs.GetInt(MoneyLabel);
            LoadResources();
            WoodAmount = CalculateResources(0);
            StoneAmount = CalculateResources(1);
            AxeLevel = PlayerPrefs.GetInt(AxeLevelLabel);
            Pick = PlayerPrefs.GetInt(PickObtainedLabel) == 1;
            PickLevel = PlayerPrefs.GetInt(PickLevelLabel);
            InitTools();
        }

        /// <summary>
        ///     Метод сохранения данных
        /// </summary>
        public void SaveData()
        {
            PlayerPrefs.SetInt(AxeLevelLabel, AxeLevel);
            PlayerPrefs.SetInt(PickObtainedLabel, Pick ? 1 : 0);
            PlayerPrefs.SetInt(PickLevelLabel, PickLevel);
        }

        /// <summary>
        ///     Метод поиска ресурсов на сцене.
        /// </summary>
        /// <returns>список ресурсов</returns>
        private static List<Item> FindResources()
        {
            var items = FindObjectsByType<Item>(FindObjectsInactive.Include, FindObjectsSortMode.None).ToList();
            foreach (var item in items.ToArray().Where(item => !item.Resource)) items.Remove(item);
            return items;
        }

        /// <summary>
        ///     Метод загрузки ресурсов
        /// </summary>
        private static void LoadResources()
        {
            var quantity = PlayerPrefs.GetInt("ResourcesQuantity");
            for (var i = 0; i < quantity; i++)
            {
                var itemPrefab = (GameObject)Resources.Load(ItemPrefabPath);
                var item = Instantiate(itemPrefab, SellParent);
                item.GetComponent<Item>().Init(PlayerPrefs.GetInt($"Resource{i}Image"),
                    PlayerPrefs.GetInt($"Resource{i}Amount"));
            }
        }

        /// <summary>
        ///     Метод сохранения ресурсов
        /// </summary>
        private static void SaveResources()
        {
            var items = FindResources();
            var quantity = items.Count;
            PlayerPrefs.SetInt("ResourcesQuantity", quantity);
            for (var i = 0; i < quantity; i++)
            {
                PlayerPrefs.SetInt($"Resource{i}Image", items[i].Id);
                PlayerPrefs.SetInt($"Resource{i}Amount", items[i].Value);
            }
        }

        /// <summary>
        ///     Метод подсчёта ресурсов при загрузке
        /// </summary>
        /// <param name="resourceId">индекс ресурса</param>
        /// <returns>сумма ресурса</returns>
        private static int CalculateResources(int resourceId)
        {
            var items = FindResources();
            return items.Where(item => item.Id == resourceId).Sum(item => item.Value);
        }

        /// <summary>
        ///     Метод получения цены инструмента
        /// </summary>
        /// <param name="id">индекс инструмента</param>
        /// <returns>цена</returns>
        public int GetToolPrice(int id)
        {
            var result = id switch
            {
                0 => Convert.ToInt32(Game.TradeSettings.AxeInitialCost *
                                     Math.Exp(Game.TradeSettings.AxeUpgradeGrowthRate * (AxeLevel + 1))),
                1 => Convert.ToInt32(Game.TradeSettings.PickInitialCost *
                                     Math.Exp(Game.TradeSettings.PickUpgradeGrowthRate * (PickLevel + 1))),
                _ => 0
            };

            return result;
        }

        /// <summary>
        ///     Метод получения цены ресурса
        /// </summary>
        /// <param name="id">индекс ресурса</param>
        /// <returns>цена</returns>
        public static int GetResourcePrice(int id)
        {
            var result = id switch
            {
                0 => Game.TradeSettings.WoodCost,
                1 => Game.TradeSettings.StoneCost,
                _ => 0
            };

            return result;
        }

        /// <summary>
        ///     Метод получения количества материала для сбора, в зависимости от уровня инструмента
        /// </summary>
        /// <param name="id">индекс материала</param>
        /// <returns>количество</returns>
        public int GetAmount(int id)
        {
            var result = id switch
            {
                0 => Convert.ToInt32(CollectSettings.WoodCollectAmount + CollectSettings.WoodCollectAmount *
                    CollectSettings.WoodCollectCoefficient *
                    (AxeLevel - 1)),
                1 => Convert.ToInt32(CollectSettings.StoneCollectAmount + CollectSettings.StoneCollectAmount *
                    CollectSettings.StoneCollectCoefficient *
                    (PickLevel - 1)),
                _ => 0
            };

            return result;
        }
    }
}