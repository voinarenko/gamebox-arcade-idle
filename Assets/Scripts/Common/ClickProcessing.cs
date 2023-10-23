using UnityEngine;

namespace Assets.Scripts.Common
{
    /// <summary>
    /// Обработка нажатия мыши.
    /// </summary>
    public class ClickProcessing : MonoBehaviour
    {
        private Game _game; // игра

        private void Start() => _game = GetComponent<Game>();

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0)) return;
            var camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(camRay, out var hitInfo)) return;
            if (hitInfo.transform.CompareTag(_game.Constants.GroundTag)) _game.Move(_game.MousePosition);
            if (hitInfo.transform.CompareTag(_game.Constants.TreeTag) || hitInfo.transform.CompareTag(_game.Constants.RockTag))
            {
                _game.MoveToCollect = true;
                _game.Move(hitInfo.transform.position);
            }
        }
    }
}