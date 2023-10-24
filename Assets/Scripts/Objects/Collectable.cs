using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    /// <summary>
    /// Собираемый ресурс.
    /// </summary>
    public abstract class Collectable : Interactive
    {
        public CollectablesSettings Settings { get; private set; }
        private float _timer; // таймер
        protected float RestoreTime; // время восстановления
        private Level[] _levels; // массив изображений уровня заполненности
        private int _currentLevelIndex; // индекс текущего уровня
        public string TreeTag { get; private set; } // метка дерева
        public string RockTag { get; private set; } // метка камня

        protected override void Start()
        {
            base.Start();
            Settings = Game.CollectablesSettings;
            TreeTag = Game.TreeTag;
            RockTag = Game.RockTag;
            LoadLevels();
            ActivateLevel(true);
        }

        private void Update()
        {
            _timer -= Time.deltaTime;
            if (_currentLevelIndex == _levels.Length - 1) return;
            if (_timer < 0) Restore();
        }

        protected override void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Game.PlayerTag)) return;
            base.OnTriggerEnter(other);
            if (Game.MoveToCollect && Game.MoveToCollectPosition == transform.position) Game.MoveToCollect = false;
        }

        protected override void OnTriggerStay(Collider other)
        {
            if (!other.CompareTag(Game.PlayerTag)) return;
            base.OnTriggerStay(other);
            if (Game.MoveToCollect && Game.MoveToCollectPosition == transform.position) Game.MoveToCollect = false;
        }


        /// <summary>
        /// Метод загрузки уровней
        /// </summary>
        private void LoadLevels()
        {
            var levels = GetComponentsInChildren<Level>(includeInactive:true);
            _levels = new Level[levels.Length];
            for (var i = 0; i < _levels.Length; i++)
            {
                foreach (var l in levels.ToList().Where(l => int.Parse(levels[i].name[4..]) == i))
                    _levels[i] = levels[i];
            }
            _currentLevelIndex = _levels.Length - 1;
        }

        /// <summary>
        /// Метод активации текущего уровня
        /// </summary>
        /// <param name="value">значение</param>
        private void ActivateLevel(bool value) => _levels[_currentLevelIndex].gameObject.SetActive(value);

        /// <summary>
        /// Метод сбора ресурса
        /// </summary>
        protected void Collect()
        {
            _levels[_currentLevelIndex].gameObject.GetComponent<Renderer>().material.color = Color.white;
           ActivateLevel(false);
            _currentLevelIndex--;
            if (_currentLevelIndex >= 0) ActivateLevel(true);
            GetComponentInChildren<Target>().Refresh();
            _timer = RestoreTime;
        }

        /// <summary>
        /// Метод восстановления ресурса
        /// </summary>
        private void Restore()
        {
            _currentLevelIndex++;
            ActivateLevel(true);
            if (_currentLevelIndex > 0) _levels[_currentLevelIndex - 1].gameObject.SetActive(false);
            GetComponent<Target>().Refresh();
            _timer = RestoreTime;
        }

        /// <summary>
        /// Метод очистки нахождения у дерева
        /// </summary>
        public void ClearNearTree() => Game.NearTree = false;


        /// <summary>
        /// Метод очистки нахождения у камня
        /// </summary>
        public void ClearNearRock() => Game.NearRock = false;
    }
}