namespace Game.Enums
{
    /// <summary>
    /// Состояния коробки
    /// </summary>
    public enum BoxState : byte
    {
        None,
        Idle,
        Placed,
        Removed,
        Destroyed
    }
}