using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    /// <summary>
    /// Предмет инвентаря.
    /// </summary>
    public class Item : MonoBehaviour
    {
        public bool Resource { get; private set; }
        [SerializeField] private Image _buttonImage; // изображение иконки
        private TMP_Text ButtonText => GetComponentInChildren<TMP_Text>(); // количество ресурса
        [SerializeField] private Sprite[] _resourceIcons; // массив иконок ресурсов
        [SerializeField] private Sprite[] _toolIcons; // массив иконок инструментов
        public int ResourceId { get; private set; } // индекс ресурса
        public int Amount { get; private set; } // количество

        /// <summary>
        /// Метод инициализации инструмента
        /// </summary>
        /// <param name="id">индекс изображения</param>
        public void Init(int id)
        {
            _buttonImage.sprite = _toolIcons[id];
            ButtonText.text = "";
        }

        /// <summary>
        /// Метод инициализации ресурса
        /// </summary>
        /// <param name="resourceId">индекс изображения</param>
        /// <param name="amount">количество ресурса</param>
        public void Init(int resourceId, int amount)
        {
            Resource = true;
            ResourceId = resourceId;
            _buttonImage.sprite = _resourceIcons[ResourceId];
            Amount = amount;
            ButtonText.text = Amount.ToString();
        }
    }
}