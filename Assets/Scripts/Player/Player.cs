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
        public PlayerRotation Rotation { get; private set; } // вращение игрока
        public float RotationSpeed { get; private set; } // скорость вращения
        public float MovementSpeed { get; private set; } // скорость движения
        public Vector3 MovePosition { get; private set; } // цель движения
        public bool IsMoving { get; private set; } // игрок движется
        public bool IsRotating { get; set; } // игрок поворачивается

        private void Start()
        {
            _game = GetComponentInParent<Game>();
            _settings = _game.PlayerSettings;
            RotationSpeed = _settings.RotationSpeed;
            MovementSpeed = _settings.MovementSpeed;
            _animator = GetComponent<Animator>();
            Rotation = GetComponent<PlayerRotation>();
        }

        public void Move(Vector3 position)
        {
            MovePosition = position;
            IsMoving = true;
        }

        public void StopMoving()
        {
            IsMoving = false;
            SwitchMoveAnimation(false);
        }

        public void SwitchMoveAnimation(bool value) => _animator.SetBool(_settings.PlayerWalkAnimLabel, value);
    }
}