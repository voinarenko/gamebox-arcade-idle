using UnityEngine;

namespace Assets.Scripts.Objects
{
    /// <summary>
    /// Цель.
    /// </summary>
    public class Target : MonoBehaviour
    {
        private Renderer _renderer;
        private Color _selectionColor;

        private void Start()
        {
            _selectionColor = GetComponent<Interactive>().Settings.SelectionColor;
            Refresh();
        }

        private void OnMouseEnter()
        {
            Refresh();
            if (_renderer != null) _renderer.material.color = _selectionColor;
        }

        private void OnMouseOver()
        {
            if (_renderer != null) _renderer.material.color = _selectionColor;
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