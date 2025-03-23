using Game.Enums;
using Game.ViewModels;
using UnityEngine;

namespace Game.Infrastructure
{
    /// <summary>
    /// Стратегия размещения новых кубов
    /// </summary>
    public interface IPlacementStrategy
    {
        bool TryPlace(BoxViewModel boxViewModel, Vector2 boxPosition, out PlacementError error);
    }
}