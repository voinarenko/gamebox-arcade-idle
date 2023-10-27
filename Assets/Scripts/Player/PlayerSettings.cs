﻿using UnityEngine;

namespace Assets.Scripts.Player
{
    /// <summary>
    ///     Настройки игрока.
    /// </summary>
    [CreateAssetMenu(fileName = "Player Settings", menuName = "Game/Player/Settings")]
    public class PlayerSettings : ScriptableObject
    {
        /// <summary>
        ///     скорость движения игрока
        /// </summary>
        public float MovementSpeed;

        public string PlayerCollectAnimLabel = "Collecting";

        // анимация
        public string PlayerWalkAnimLabel = "Walking";

        /// <summary>
        ///     скорость вращения игрока
        /// </summary>
        public float RotationSpeed;
    }
}