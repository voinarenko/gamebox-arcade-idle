using UnityEngine;

namespace Assets.Scripts.Player
{
    /// <summary>
    ///     Игрок.
    /// </summary>
    public class Player : MonoBehaviour
    {
        private const string PlayerSettingsPath = "ScriptableObjects/PlayerSettings"; // файл настроек игрока
        private Animator Animator => GetComponent<Animator>();
        private static PlayerSettings Settings => Resources.Load<PlayerSettings>(PlayerSettingsPath);
        public PlayerRotation Rotation => GetComponent<PlayerRotation>();
        public float RotationSpeed { get; private set; } // скорость вращения
        public float MovementSpeed { get; private set; } // скорость движения
        public Vector3 MovePosition { get; private set; } // цель движения
        public bool IsMoving { get; private set; } // игрок движется
        public bool IsRotating { get; set; } // игрок поворачивается

        private void Start()
        {
            RotationSpeed = Settings.RotationSpeed;
            MovementSpeed = Settings.MovementSpeed;
        }

        /// <summary>
        ///     Метод движения игрока
        /// </summary>
        /// <param name="position">цель</param>
        public void Move(Vector3 position)
        {
            MovePosition = position;
            IsMoving = true;
        }

        /// <summary>
        ///     Метод остановки движения игрока
        /// </summary>
        public void StopMoving()
        {
            IsMoving = false;
            SwitchMoveAnimation(false);
        }

        /// <summary>
        ///     Метод переключения анимации движения игрока
        /// </summary>
        /// <param name="value"></param>
        public void SwitchMoveAnimation(bool value)
        {
            Animator.SetBool(Settings.PlayerWalkAnimLabel, value);
        }
    }
}