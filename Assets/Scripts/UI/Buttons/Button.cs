using Assets.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Buttons
{
    public class Button : MonoBehaviour, IButton
    {
        private Image ButtonImage => GetComponent<Image>(); // компонент изображения
        [SerializeField] private Sprite[] _sprites = new Sprite[3]; // спрайты состояний кнопки

        public virtual void OnPointerClick(PointerEventData eventData) { }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_sprites[2] == null) return;
            ButtonImage.sprite = _sprites?[2];
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (_sprites[1] == null) return;
            ButtonImage.sprite = _sprites?[1];
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (_sprites[2] == null) return;
            ButtonImage.sprite = _sprites?[2];
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_sprites[0] == null) return;
            ButtonImage.sprite = _sprites?[0];
        }
    }
}