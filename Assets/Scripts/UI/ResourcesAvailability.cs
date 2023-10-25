using Assets.Scripts.Common;
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
        private TMP_Text _moneyText; // деньги
        private TMP_Text _woodText; // дерево
        private TMP_Text _stoneText; // камень

        private void Start()
        {
            _inventory = FindAnyObjectByType<Inventory>();
            _moneyText = GetComponentInChildren<MoneyText>().GetComponent<TMP_Text>();
            _woodText = GetComponentInChildren<WoodText>().GetComponent<TMP_Text>();
            _stoneText = GetComponentInChildren<StoneText>().GetComponent<TMP_Text>();
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
        }
    }
}