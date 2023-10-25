using UnityEngine;

namespace Assets.Scripts.Player
{
    /// <summary>
    /// Движение игрока.
    /// </summary>
    public class PlayerMovement : MonoBehaviour
    {
        private Player Player => GetComponent<Player>();

        private void Update()
        {
            if (Player.IsMoving) Move(Player.MovePosition);
        }

        /// <summary>
        /// Метод движения
        /// </summary>
        /// <param name="position">координаты цели</param>
        private void Move(Vector3 position)
        {
            Player.Rotation.Rotate(position);
            if (Player.IsRotating) return;
            Player.SwitchMoveAnimation(true);
            transform.position = Vector3.MoveTowards(transform.position, position, Player.MovementSpeed * Time.deltaTime);
            if (transform.position == position) Player.StopMoving();
        }
    }
}