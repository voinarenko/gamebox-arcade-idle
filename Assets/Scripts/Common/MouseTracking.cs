using UnityEngine;

namespace Assets.Scripts.Common
{
    /// <summary>
    ///     Отслеживание положения мыши
    /// </summary>
    public class MouseTracking : MonoBehaviour
    {
        private Plane _ground = new(Vector3.up, 0); // плоскость для получения координат
        private Game Game => GetComponent<Game>();

        private void Update()
        {
            if (Game.OverUi) return;
            var camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!_ground.Raycast(camRay, out var distance)) return;
            Game.MousePosition = camRay.GetPoint(distance);
        }
    }
}