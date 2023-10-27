using UnityEngine.EventSystems;

namespace Assets.Scripts.Interfaces
{
    /// <summary>
    ///     Интерфейс кнопки.
    /// </summary>
    public interface IButton : IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler,
        IPointerDownHandler
    {
    }
}