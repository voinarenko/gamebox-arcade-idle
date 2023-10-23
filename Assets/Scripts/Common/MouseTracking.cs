using UnityEngine;

namespace Assets.Scripts.Common
{
    /// <summary>
    /// Отслеживание положения мыши
    /// </summary>
    public class MouseTracking : MonoBehaviour
    {
        private Game _game; // игра
        private Plane _ground = new(Vector3.up, 0); // плоскость для получения координат

        private void Start() => _game = GetComponent<Game>();

        private void Update()
        {
            var camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!_ground.Raycast(camRay, out var distance)) return;
            _game.MousePosition = camRay.GetPoint(distance);
        }
    }
}