using UnityEngine;

namespace Assets.Scripts.UI
{
    public class Ui :MonoBehaviour
    {
        private const string UiSettingsPath = "ScriptableObjects/UISettings"; // файл настроек интерфейса

        public static UiSettings Settings => Resources.Load<UiSettings>(UiSettingsPath);
    }
}