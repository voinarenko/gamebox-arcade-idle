using Assets.Scripts.UI.Screens;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI.Buttons
{
    /// <summary>
    ///     Кнопка закрытия окна.
    /// </summary>
    public class CloseButton : Button
    {
        private Screen Screen => GetComponentInParent<Screen>();

        public override void OnPointerClick(PointerEventData eventData)
        {
            Screen.FadeOut();
        }
    }
}