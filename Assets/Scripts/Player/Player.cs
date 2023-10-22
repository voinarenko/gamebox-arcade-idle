using Assets.Scripts.Common;
using UnityEngine;

namespace Assets.Scripts.Player
{
    /// <summary>
    /// Игрок.
    /// </summary>
    public class Player : MonoBehaviour
    {
        private Game _game; // игра
        private Animator _animator; // аниматор
        private PlayerSettings _settings; // параметры игрока
        public float RotationSpeed { get; private set; } // скорость вращения
        public float MovementSpeed { get; private set; } // скорость движения
        public Vector3 MousePosition { get; set; } // положение мыши на плоскости
        public Vector3 MovePosition { get; private set; } // цель движения
        public bool IsMoving { get; private set; } // игрок движется

        private void Start()
        {
            _game = FindAnyObjectByType<Game>();
            _settings = Resources.Load<PlayerSettings>(_game.Constants.PlayerSettingsPath);
            RotationSpeed = _settings.RotationSpeed;
            MovementSpeed = _settings.MovementSpeed;
            _animator = GetComponent<Animator>();
        }

        public void Move()
        {
            MovePosition = MousePosition;
            IsMoving = true;
            _animator.SetBool("Walking", true);
        }

        public void StopMoving()
        {
            transform.position = MovePosition;
            IsMoving = false;
            _animator.SetBool("Walking", false);
        }
    }
}