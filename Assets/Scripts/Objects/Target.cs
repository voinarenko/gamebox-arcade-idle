using Assets.Scripts.Common;
using Assets.Scripts.UI.Screens;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    /// <summary>
    ///     Цель.
    /// </summary>
    public class Target : MonoBehaviour
    {
        private Renderer _renderer;
        private Interactive Interactive => GetComponent<Interactive>();
        private Inventory Inventory => Interactive.Game.Inventory;
        private Color SelectionColor => Interactive.Settings.SelectionColor;
        private static Tooltip Tooltip => FindAnyObjectByType<Tooltip>(FindObjectsInactive.Include);

        private void Start()
        {
            Refresh();
        }

        private void OnMouseEnter()
        {
            if (Interactive.Game.OverUi) return;
            Refresh();
            if (_renderer != null) _renderer.material.color = SelectionColor;
            ShowTooltip();
        }

        private void OnMouseOver()
        {
            if (Interactive.Game.OverUi) return;
            if (_renderer != null) _renderer.material.color = SelectionColor;
            ShowTooltip();
        }

        private void OnMouseExit()
        {
            if (_renderer != null) _renderer.material.color = Color.white;
            HideTooltip();
        }

        /// <summary>
        ///     Метод обновления рендерера.
        /// </summary>
        public void Refresh()
        {
            _renderer = GetComponentInChildren<Renderer>();
        }

        /// <summary>
        ///     Метод отображения информационного окна
        /// </summary>
        private void ShowTooltip()
        {
            Tooltip.gameObject.SetActive(true);
            if (TryGetComponent<CollectableTree>(out _))
            {
                Tooltip.Name.text = "Дерево";
                Tooltip.Info.text = "требуется топор";
                Tooltip.Data.text = $"{Inventory.GetAmount(0)} дерева";
            }

            if (TryGetComponent<CollectableRock>(out _))
            {
                Tooltip.Name.text = "Камень";
                Tooltip.Info.text = "требуется кирка";
                Tooltip.Data.text = $"{Inventory.GetAmount(1)} камня";
            }

            if (TryGetComponent<Shop>(out _))
            {
                Tooltip.Name.text = "Магазин";
                Tooltip.Info.text = "для торговли";
                Tooltip.Data.text = "";
            }
        }

        /// <summary>
        ///     Метод скрытия информационного окна
        /// </summary>
        private static void HideTooltip()
        {
            Tooltip.Name.text = "";
            Tooltip.Info.text = "";
            Tooltip.Data.text = "";
            Tooltip.gameObject.SetActive(false);
        }
    }
}