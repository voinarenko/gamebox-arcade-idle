﻿using UnityEngine;

namespace Assets.Scripts.Common
{
    /// <summary>
    /// Игра.
    /// </summary>
    public class Game : MonoBehaviour
    {
        private const string ConstantsPath = "ScriptableObjects/GameConstants";
        public Constants Constants { get; private set; } // константы
        public Player.Player Player { get; private set; } // игрок

        public Vector3 MousePosition { get; set; } // координаты мыши на плоскости

        private void Awake()
        {
            Constants = Resources.Load<Constants>(ConstantsPath);
            Player = FindAnyObjectByType<Player.Player>();
        }
    }
}