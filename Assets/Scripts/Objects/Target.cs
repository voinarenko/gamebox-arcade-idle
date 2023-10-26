using Assets.Scripts.Common;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    /// <summary>
    /// Цель.
    /// </summary>
    public class Target : MonoBehaviour
    {
        private Renderer _renderer;
        private Color SelectionColor => GetComponent<Interactive>().Settings.SelectionColor;
        private Interactive Interactive => GetComponent<Interactive>();

        private void Start() => Refresh();

        private void OnMouseEnter()
        {
            if (Interactive.Game.OverUi) return;
            Refresh();
            if (_renderer != null) _renderer.material.color = SelectionColor;
        }

        private void OnMouseOver()
        {
            if (Interactive.Game.OverUi) return;
            if (_renderer != null) _renderer.material.color = SelectionColor;
        }

        private void OnMouseExit()
        {
            if (_renderer != null) _renderer.material.color = Color.white;
        }

        /// <summary>
        /// Метод обновления рендерера.
        /// </summary>
        public void Refresh() => _renderer = GetComponentInChildren<Renderer>();
    }
}