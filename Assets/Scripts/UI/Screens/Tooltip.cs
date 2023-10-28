using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI.Screens
{
    /// <summary>
    ///     Информационное окно.
    /// </summary>
    public class Tooltip : MonoBehaviour
    {
        private const float OffsetX = 220; // смещение по горизонтали
        private const float OffsetY = 120; // смещение по вертикали
        public TMP_Text Name => GetComponentInChildren<TooltipName>().GetComponent<TMP_Text>(); // название в подсказке
        public TMP_Text Info => GetComponentInChildren<TooltipInfo>().GetComponent<TMP_Text>(); // информация в подсказке
        public TMP_Text Data => GetComponentInChildren<TooltipData>().GetComponent<TMP_Text>(); // данные в подсказке

        private void Start()
        {
            gameObject.SetActive(false);
        }

        private void Update()
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)transform.parent, Input.mousePosition, null,
                out var localPoint);
            transform.localPosition = new Vector2(localPoint.x + OffsetX, localPoint.y - OffsetY);
        }
    }
}