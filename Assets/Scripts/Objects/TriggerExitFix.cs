using UnityEngine;

namespace Assets.Scripts.Objects
{
    /// <summary>
    ///     Обход проблемы отсутствия срабатывания выхода из коллайдера при выключении объекта.
    /// </summary>
    public class TriggerExitFix : MonoBehaviour
    {
        private Collectable _collectable;

        private void Start()
        {
            _collectable = GetComponentInParent<Collectable>();
        }

        private void OnDisable()
        {
            if (_collectable.CompareTag(_collectable.TreeTag)) _collectable.ClearNearTree();
            if (_collectable.CompareTag(_collectable.RockTag)) _collectable.ClearNearRock();
        }
    }
}