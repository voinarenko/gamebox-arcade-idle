using Assets.Scripts.Common;
using Assets.Scripts.UI.TextFields;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    /// <summary>
    /// Отображение на экране наличных ресурсов
    /// </summary>
    public class ResourcesAvailability : MonoBehaviour
    {
        private Inventory _inventory;
        private TMP_Text _moneyText; // количество денег
        private TMP_Text _woodText; // количество дерева
        private TMP_Text _stoneText; // количество камня
        private TMP_Text _axeLevel; // уровень топора
        private TMP_Text _pickLevel; // уровень кирки

        private void Start()
        {
            _inventory = FindAnyObjectByType<Inventory>();
            _moneyText = GetComponentInChildren<MoneyText>().GetComponent<TMP_Text>();
            _woodText = GetComponentInChildren<WoodText>().GetComponent<TMP_Text>();
            _stoneText = GetComponentInChildren<StoneText>().GetComponent<TMP_Text>();
            _axeLevel = GetComponentInChildren<AxeLevel>().GetComponent<TMP_Text>();
            _pickLevel = GetComponentInChildren<PickLevel>().GetComponent<TMP_Text>();
            _inventory.LoadData();
            UpdateView();
        }

        /// <summary>
        /// Метод обновления отображения данных на экране
        /// </summary>
        public void UpdateView()
        {
            _moneyText.text = _inventory.MoneyAmount.ToString();
            _woodText.text = _inventory.WoodAmount.ToString();
            _stoneText.text = _inventory.StoneAmount.ToString();
            _axeLevel.text = _inventory.AxeLevel.ToString();
            _pickLevel.text = _inventory.PickLevel.ToString();
            _pickLevel.transform.parent.gameObject.SetActive(_inventory.Pick);
        }
    }
}