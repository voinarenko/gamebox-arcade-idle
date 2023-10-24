using UnityEngine;

namespace Assets.Scripts.Player
{
    /// <summary>
    /// Движение игрока.
    /// </summary>
    public class PlayerMovement : MonoBehaviour
    {
        private Player _player;

        private void Start() => _player = GetComponent<Player>();

        private void Update()
        {
            if (_player.IsMoving) Move(_player.MovePosition);
        }

        /// <summary>
        /// Метод движения
        /// </summary>
        /// <param name="position">координаты цели</param>
        private void Move(Vector3 position)
        {
            _player.Rotation.Rotate(position);
            if (_player.IsRotating) return;
            _player.SwitchMoveAnimation(true);
            transform.position = Vector3.MoveTowards(transform.position, position, _player.MovementSpeed * Time.deltaTime);
            if (transform.position == position) _player.StopMoving();
        }
    }
}