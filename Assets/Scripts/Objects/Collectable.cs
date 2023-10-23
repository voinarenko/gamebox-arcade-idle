using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    /// <summary>
    /// Собираемый ресурс.
    /// </summary>
    public abstract class Collectable : Interactive
    {
        public CollectablesSettings Settings { get; private set; } // параметры собираемых ресурсов
        private float _timer; // таймер
        protected float RestoreTime; // время восстановления
        private Level[] _levels; // массив изображений уровня заполненности
        private int _currentLevelIndex; // индекс текущего уровня

        protected override void Start()
        {
            base.Start();
            Settings = Game.CollectablesSettings;
            LoadLevels();
            ActivateLevel();
        }

        private void Update()
        {
            _timer -= Time.deltaTime;
            if (_currentLevelIndex == _levels.Length - 1) return;
            if (_timer < 0) Restore();
        }

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

        private void ActivateLevel() => _levels[_currentLevelIndex].gameObject.SetActive(true);

        protected void Collect()
        {
            _levels[_currentLevelIndex].gameObject.GetComponent<Renderer>().material.color = Color.white;
            _levels[_currentLevelIndex].gameObject.SetActive(false);
            _currentLevelIndex--;
            if (_currentLevelIndex >= 0) _levels[_currentLevelIndex].gameObject.SetActive(true);
            GetComponentInChildren<Target>().Refresh();
            _timer = RestoreTime;
        }

        private void Restore()
        {
            _currentLevelIndex++;
            _levels[_currentLevelIndex].gameObject.SetActive(true);
            if (_currentLevelIndex > 0) _levels[_currentLevelIndex - 1].gameObject.SetActive(false);
            GetComponent<Target>().Refresh();
            _timer = RestoreTime;
        }
    }
}