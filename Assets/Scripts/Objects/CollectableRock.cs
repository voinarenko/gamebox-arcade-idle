namespace Assets.Scripts.Objects
{
    /// <summary>
    /// Собираемый камень.
    /// </summary>
    public class CollectableRock : Collectable
    {
        protected override void Start()
        {
            base.Start();
            RestoreTime = Settings.RockRestoreTime;
        }
    }
}