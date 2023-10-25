using UnityEngine;

namespace Assets.Scripts.Player
{
    /// <summary>
    /// Вращение игрока.
    /// </summary>
    public class PlayerRotation : MonoBehaviour
    {
        private Player Player => GetComponent<Player>();

        /// <summary>
        /// Метод вращения
        /// </summary>
        public void Rotate(Vector3 position)
        {
            Player.IsRotating = true;
            var playerToMouse = position - transform.position;
            playerToMouse.y = 0f;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(playerToMouse), Player.RotationSpeed * Time.deltaTime);
            if (transform.rotation == Quaternion.LookRotation(playerToMouse)) Player.IsRotating = false;
        }
    }
}