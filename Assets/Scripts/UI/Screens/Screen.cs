using Assets.Scripts.Common;
using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.UI.Screens
{
    /// <summary>
    /// Экран.
    /// </summary>
    public class Screen : MonoBehaviour
    {
        public Game Game => FindAnyObjectByType<Game>();

        protected void OnEnable()
        {
            transform.localScale = Vector3.zero;
            transform.DOScale(Vector3.one, Ui.Settings.ScreenOpenTime);
            Game.OverUi = true;
        }

        protected void OnDisable() => Game.OverUi = false;

        /// <summary>
        /// Метод плавного закрытия окна
        /// </summary>
        public void FadeOut() => transform.DOScale(Vector3.zero, Ui.Settings.ScreenCloseTime).OnComplete(() => gameObject.SetActive(false));
    }
}