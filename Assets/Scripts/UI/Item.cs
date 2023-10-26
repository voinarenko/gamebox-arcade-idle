using Assets.Scripts.Common;
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
        private Game Game => GetComponentInParent<Screen>(includeInactive:true).Game;
        private Inventory Inventory => Game.GetComponent<Inventory>();

        public bool Resource { get; private set; } // является ли предмет ресурсом
        [SerializeField] private Image _buttonImage; // изображение иконки
        private TMP_Text ButtonText => GetComponentInChildren<TMP_Text>(); // количество ресурса
        [SerializeField] private Sprite[] _resourceIcons; // массив иконок ресурсов
        [SerializeField] private Sprite[] _toolIcons; // массив иконок инструментов
        public int Id;// { get; private set; } // индекс
        public int Amount { get; private set; } // количество

        /// <summary>
        /// Метод инициализации инструмента
        /// </summary>
        /// <param name="id">индекс изображения</param>
        public void Init(int id)
        {
            _buttonImage.sprite = _toolIcons[id];
            Id = id;
            ButtonText.text = id switch
            {
                0 => (Inventory.AxeLevel + 1).ToString(),
                1 => (Inventory.PickLevel + 1).ToString(),
                _ => ButtonText.text
            };
        }

        /// <summary>
        /// Метод инициализации ресурса
        /// </summary>
        /// <param name="resourceId">индекс изображения</param>
        /// <param name="amount">количество ресурса</param>
        public void Init(int resourceId, int amount)
        {
            Resource = true;
            Id = resourceId;
            _buttonImage.sprite = _resourceIcons[Id];
            Amount = amount;
            ButtonText.text = Amount.ToString();
        }
    }
}