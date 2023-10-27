using UnityEngine;

namespace Assets.Scripts.UI
{
    /// <summary>
    ///     Настройки пользовательского интерфейса.
    /// </summary>
    [CreateAssetMenu(fileName = "UI Settings", menuName = "Game/UI/Settings")]
    public class UiSettings : ScriptableObject
    {
        public float ScreenCloseTime; // время закрытия экрана
        public float ScreenOpenTime; // время открытия экрана
    }
}