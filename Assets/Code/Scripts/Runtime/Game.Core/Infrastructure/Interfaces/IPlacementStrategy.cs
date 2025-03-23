using Game.ViewModels;
using UnityEngine;

namespace Game.Infrastructure
{
    /// <summary>
    /// Стратегия размещения новых кубов
    /// </summary>
    public interface IPlacementStrategy
    {
        bool TryPlace(TowerViewModel towerViewModel, BoxViewModel boxViewModel, Vector2 boxPosition);
    }
}