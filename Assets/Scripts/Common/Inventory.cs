using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Common
{
    /// <summary>
    /// Инвентарь.
    /// </summary>
    public class Inventory : MonoBehaviour
    {
        private ResourcesAvailability _resourcesDisplay;

        // метки сохранения
        private const string MoneyLabel = "MoneyAmount"; // ключ для сохранения денег
        private const string WoodLabel = "WoodAmount"; // ключ для сохранения дерева
        private const string StoneLabel = "StoneAmount"; // ключ для сохранения камня
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
            _resourcesDisplay = FindAnyObjectByType<ResourcesAvailability>();
            Axe = true;
            GetComponent<Game>().Axe = Axe;
        }

        private void OnDisable() => SaveData();

        /// <summary>
        /// Метод добавления дерева в инвентарь
        /// </summary>
        /// <param name="amount">количество дерева</param>
        public void AddMoney(int amount)
        {
            MoneyAmount += amount;
            _resourcesDisplay.UpdateView();
        }

        /// <summary>
        /// Метод добавления денег в инвентарь
        /// </summary>
        /// <param name="amount">количество денег</param>
        public void AddWood(int amount)
        {
            WoodAmount += amount;
            _resourcesDisplay.UpdateView();
        }

        /// <summary>
        /// Метод добавления камня в инвентарь
        /// </summary>
        /// <param name="amount">количество камня</param>
        public void AddStone(int amount)
        {
            StoneAmount += amount;
            _resourcesDisplay.UpdateView();
        }

        /// <summary>
        /// Метод загрузки сохранённых данных
        /// </summary>
        public void LoadData()
        {
            MoneyAmount = PlayerPrefs.GetInt(MoneyLabel);
            WoodAmount = PlayerPrefs.GetInt(WoodLabel);
            StoneAmount = PlayerPrefs.GetInt(StoneLabel);
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
            PlayerPrefs.SetInt(WoodLabel, WoodAmount);
            PlayerPrefs.SetInt(StoneLabel, StoneAmount);
            PlayerPrefs.SetInt(AxeLevelLabel, AxeLevel);
            PlayerPrefs.SetInt(PickObtainedLabel, Pick ? 1 : 0);
            PlayerPrefs.SetInt(PickLevelLabel, PickLevel);
        }
    }
}