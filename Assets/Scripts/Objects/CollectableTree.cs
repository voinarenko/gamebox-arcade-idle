namespace Assets.Scripts.Objects
{
    /// <summary>
    /// Собираемое дерево.
    /// </summary>
    public class CollectableTree : Collectable
    {
        protected override void Start()
        {
            base.Start();
            RestoreTime = Settings.TreeRestoreTime;
        }
    }
}