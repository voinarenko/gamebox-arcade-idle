using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Common
{
    /// <summary>
    /// Инвентарь.
    /// </summary>
    public class Inventory : MonoBehaviour
    {
        private static ResourcesAvailability ResourcesDisplay => FindAnyObjectByType<ResourcesAvailability>();

        // экран магазина
        private const string ItemPrefabPath = "Prefabs/Item"; // путь к объекту предмета инвентаря
        private GameObject _itemPrefab; // объект предмета инвентаря

        private static Transform SellParent => FindAnyObjectByType<SellContent>(FindObjectsInactive.Include).transform;

        // метки сохранения
        private const string MoneyLabel = "MoneyAmount"; // ключ для сохранения денег
        private const string AxeLevelLabel = "AxeLevel"; // ключ для сохранения уровня топора
        private const string PickObtainedLabel = "PickObtained"; // ключ для сохранения наличия кирки
        private const string PickLevelLabel = "PickLevel"; // ключ для сохранения кирки

        // ресурсы
        public int MoneyAmount { get; private set; } // деньги
        public int WoodAmount { get; private set; } // дерево
        public int StoneAmount { get; private set; } // камень

        // инструменты
        public bool Axe { get; private set; } // топор
        public int AxeLevel { get; set; } // уровень топора
        public bool Pick { get; set; } // кирка
        public int PickLevel { get; set; } // уровень кирки

        private void Start()
        {
            Axe = true;
            GetComponent<Game>().Axe = Axe;
            _itemPrefab = (GameObject)Resources.Load(ItemPrefabPath);
        }

        private void OnDisable() => SaveData();

        /// <summary>
        /// Метод добавления денег в инвентарь
        /// </summary>
        /// <param name="amount">количество денег</param>
        public void AddMoney(int amount)
        {
            MoneyAmount += amount;
            ResourcesDisplay.UpdateView();
        }

        /// <summary>
        /// Метод вычитания денег из инвентаря
        /// </summary>
        /// <param name="amount">количество денег</param>
        public void RemoveMoney(int amount)
        {
            MoneyAmount -= amount;
            ResourcesDisplay.UpdateView();
        }

        /// <summary>
        /// Метод добавления денег в инвентарь
        /// </summary>
        /// <param name="amount">количество денег</param>
        public void AddWood(int amount)
        {
            WoodAmount += amount;
            ResourcesDisplay.UpdateView();
            var item = Instantiate(_itemPrefab, SellParent);
            item.GetComponent<Item>().Init(0, amount);
        }

        /// <summary>
        /// Метод вычитания дерева из инвентаря
        /// </summary>
        /// <param name="amount">количество дерева</param>
        public void RemoveWood(int amount)
        {
            WoodAmount -= amount;
            ResourcesDisplay.UpdateView();
        }

        /// <summary>
        /// Метод добавления камня в инвентарь
        /// </summary>
        /// <param name="amount">количество камня</param>
        public void AddStone(int amount)
        {
            StoneAmount += amount;
            ResourcesDisplay.UpdateView();
            var item = Instantiate(_itemPrefab, SellParent);
            item.GetComponent<Item>().Init(1, amount);
        }

        /// <summary>
        /// Метод вычитания камня из инвентаря
        /// </summary>
        /// <param name="amount">количество камня</param>
        public void RemoveStone(int amount)
        {
            StoneAmount -= amount;
            ResourcesDisplay.UpdateView();
        }

        /// <summary>
        /// Метод загрузки сохранённых данных
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
        }

        /// <summary>
        /// Метод сохранения данных
        /// </summary>
        private void SaveData()
        {
            PlayerPrefs.SetInt(MoneyLabel, MoneyAmount);
            SaveResources();
            PlayerPrefs.SetInt(AxeLevelLabel, AxeLevel);
            PlayerPrefs.SetInt(PickObtainedLabel, Pick ? 1 : 0);
            PlayerPrefs.SetInt(PickLevelLabel, PickLevel);
        }

        /// <summary>
        /// Метод поиска ресурсов на сцене.
        /// </summary>
        /// <returns>список ресурсов</returns>
        private static List<Item> FindResources()
        {
            var items = FindObjectsByType<Item>(FindObjectsInactive.Include, FindObjectsSortMode.None).ToList();
            foreach (var item in items.Where(item => !item.Resource)) items.Remove(item);
            return items;
        }

        /// <summary>
        /// Метод загрузки ресурсов
        /// </summary>
        private static void LoadResources()
        {
            var quantity = PlayerPrefs.GetInt("ResourcesQuantity");
            for(var i = 0; i < quantity; i++)
            {
                var itemPrefab = (GameObject)Resources.Load(ItemPrefabPath);
                var item = Instantiate(itemPrefab, SellParent);
                item.GetComponent<Item>().Init(PlayerPrefs.GetInt($"Resource{i}Image"), PlayerPrefs.GetInt($"Resource{i}Amount"));
            }
        }

        /// <summary>
        /// Метод сохранения ресурсов
        /// </summary>
        private static void SaveResources()
        {
            var items= FindResources();
            var quantity = items.Count();
            PlayerPrefs.SetInt("ResourcesQuantity", quantity);
            for(var i = 0; i < quantity; i++)
            {
                PlayerPrefs.SetInt($"Resource{i}Image", items[i].ResourceId);
                PlayerPrefs.SetInt($"Resource{i}Amount", items[i].Amount);
            }
        }

        /// <summary>
        /// Метод подсчёта ресурсов при загрузке
        /// </summary>
        /// <param name="resourceId">индекс ресурса</param>
        /// <returns>сумма ресурса</returns>
        private static int CalculateResources(int resourceId)
        {
            var items = FindResources();
            return items.Where(item => item.ResourceId == resourceId).Sum(item => item.Amount);
        }
    }
}