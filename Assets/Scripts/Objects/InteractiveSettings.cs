using UnityEngine;

namespace Assets.Scripts.Objects
{
    /// <summary>
    ///     Настройки собираемых ресурсов.
    /// </summary>
    [CreateAssetMenu(fileName = "Interactive Settings", menuName = "Game/Interactive/Collect Settings")]
    public class InteractiveSettings : ScriptableObject
    {
        public float RockRestoreTime; // время восстановления уровня камня
        public Color SelectionColor; // цвет выделения
        public int StoneCollectAmount; // базовое количество собираемого камня
        public float StoneCollectCoefficient; // коэффициент увеличения сбора камня за каждый уровень инструмента

        public float TreeRestoreTime; // время восстановления уровня дерева
        public int WoodCollectAmount; // базовое количество собираемого дерева
        public float WoodCollectCoefficient; // коэффициент увеличения сбора дерева за каждый уровень инструмента
    }
}