using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI.Buttons
{
    /// <summary>
    /// Кнопка выхода из игры.
    /// </summary>
    public class QuitButton : Button
    {
        public override void OnPointerClick(PointerEventData eventData) => Application.Quit();
    }
}