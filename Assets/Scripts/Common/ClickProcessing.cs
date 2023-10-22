using UnityEngine;

namespace Assets.Scripts.Common
{
    /// <summary>
    /// Обработка нажатия мыши.
    /// </summary>
    public class ClickProcessing : MonoBehaviour
    {
        private Game _game; // игра

        private void Start() => _game = FindAnyObjectByType<Game>();

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(camRay, out var hitInfo))
                {
                    if (hitInfo.transform.CompareTag(_game.Constants.GroundTag)) _game.Player.Move();
                }
            }
        }
    }
}