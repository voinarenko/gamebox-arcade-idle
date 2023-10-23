using Assets.Scripts.Common;
using TMPro.EditorUtilities;
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
        public PlayerRotation Rotation { get; private set; }
        public float RotationSpeed { get; private set; } // скорость вращения
        public float MovementSpeed { get; private set; } // скорость движения
        public Vector3 MovePosition { get; private set; } // цель движения
        public bool IsMoving { get; private set; } // игрок движется
        public bool IsRotating { get; set; } // игрок поворачивается

        private void Start()
        {
            _game = FindAnyObjectByType<Game>();
            _settings = Resources.Load<PlayerSettings>(_game.Constants.PlayerSettingsPath);
            RotationSpeed = _settings.RotationSpeed;
            MovementSpeed = _settings.MovementSpeed;
            _animator = GetComponent<Animator>();
            Rotation = GetComponent<PlayerRotation>();
        }

        public void Move()
        {
            MovePosition = _game.MousePosition;
            IsMoving = true;
        }

        public void StopMoving()
        {
            IsMoving = false;
            SwitchMoveAnimation(false);
        }

        public void SwitchMoveAnimation(bool value) => _animator.SetBool(_game.Constants.PlayerWalkAnimLabel, value);
    }
}