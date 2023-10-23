using UnityEngine;

namespace Assets.Scripts.Player
{
    /// <summary>
    /// Вращение игрока.
    /// </summary>
    public class PlayerRotation : MonoBehaviour
    {
        private Player _player; // игрок

        private void Start() => _player = GetComponent<Player>();

        /// <summary>
        /// Метод вращения за мышью
        /// </summary>
        public void Rotate(Vector3 position)
        {
            _player.IsRotating = true;
            var playerToMouse = position - transform.position;
            playerToMouse.y = 0f;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(playerToMouse), _player.RotationSpeed * Time.deltaTime);
            if (transform.rotation == Quaternion.LookRotation(playerToMouse)) _player.IsRotating = false;
        }
    }
}