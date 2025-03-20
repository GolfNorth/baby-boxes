namespace Game.Enums
{
    /// <summary>
    /// Состояния коробки
    /// </summary>
    public enum BoxState : byte
    {
        None,
        Idle,
        Dragging,
        Placed,
        Removed,
        Destroyed
    }
}