using Assets.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Buttons
{
    public class Button : MonoBehaviour, IButton
    {
        protected readonly Sprite[] Sprites = new Sprite[3]; // спрайты состояний кнопки
        private Image ButtonImage => GetComponent<Image>(); // компонент изображения

        private void Start()
        {
            Sprites[0] = Resources.Load<Sprite>("Images/button_50_down");
            Sprites[1] = Resources.Load<Sprite>("Images/button_50");
            Sprites[2] = Resources.Load<Sprite>("Images/button_50_hover");
        }

        public virtual void OnPointerClick(PointerEventData eventData)
        {
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (Sprites[2] == null) return;
            ButtonImage.sprite = Sprites?[2];
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (Sprites[1] == null) return;
            ButtonImage.sprite = Sprites?[1];
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (Sprites[2] == null) return;
            ButtonImage.sprite = Sprites?[2];
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (Sprites[0] == null) return;
            ButtonImage.sprite = Sprites?[0];
        }
    }
}