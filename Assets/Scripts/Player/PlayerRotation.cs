using UnityEngine;

namespace Assets.Scripts.Player
{
    /// <summary>
    /// Вращение игрока.
    /// </summary>
    public class PlayerRotation : MonoBehaviour
    {
        private Player _player; // игрок
        private Plane _ground = new(Vector3.up, 0); // плоскость для получения координат

        private void Start() => _player = GetComponent<Player>();

        private void Update()
        {
            if (!_player.IsMoving) Rotate();
        }

        /// <summary>
        /// Метод вращения за мышью
        /// </summary>
        private void Rotate()
        {
            var camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!_ground.Raycast(camRay, out var distance)) return;
            _player.MousePosition = camRay.GetPoint(distance);
            var playerToMouse = _player.MousePosition - transform.position;
            playerToMouse.y = 0f;
            _player.transform.rotation = Quaternion.RotateTowards(_player.transform.rotation, Quaternion.LookRotation(playerToMouse), _player.RotationSpeed * Time.deltaTime);
        }
    }
}