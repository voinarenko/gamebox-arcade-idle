using Assets.Scripts.Common;
using UnityEngine;

namespace Assets.Scripts.Player
{
    /// <summary>
    /// Игрок.
    /// </summary>
    public class Player : MonoBehaviour
    {
        private const string PlayerSettingsPath = "ScriptableObjects/PlayerSettings";
        private Animator _animator;
        private PlayerSettings _settings;
        public PlayerRotation Rotation { get; private set; }
        public float RotationSpeed { get; private set; } // скорость вращения
        public float MovementSpeed { get; private set; } // скорость движения
        public Vector3 MovePosition { get; private set; } // цель движения
        public bool IsMoving { get; private set; } // игрок движется
        public bool IsRotating { get; set; } // игрок поворачивается

        private void Start()
        {
            _settings = Resources.Load<PlayerSettings>(PlayerSettingsPath);
            RotationSpeed = _settings.RotationSpeed;
            MovementSpeed = _settings.MovementSpeed;
            _animator = GetComponent<Animator>();
            Rotation = GetComponent<PlayerRotation>();
        }

        /// <summary>
        /// Метод движения игрока
        /// </summary>
        /// <param name="position">цель</param>
        public void Move(Vector3 position)
        {
            MovePosition = position;
            IsMoving = true;
        }

        /// <summary>
        /// Метод остановки движения игрока
        /// </summary>
        public void StopMoving()
        {
            IsMoving = false;
            SwitchMoveAnimation(false);
        }

        /// <summary>
        /// Метод переключения анимации движения игрока
        /// </summary>
        /// <param name="value"></param>
        public void SwitchMoveAnimation(bool value) => _animator.SetBool(_settings.PlayerWalkAnimLabel, value);
    }
}