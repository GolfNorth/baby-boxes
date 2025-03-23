using Game.ViewModels;

namespace Game.Infrastructure
{
    /// <summary>
    /// Фабрика стратегий размещения кубов
    /// </summary>
    public interface IPlacementFactory
    {
        /// <summary>
        /// Получить стратегию размещения куба
        /// </summary>
        IPlacementStrategy GetStrategy(TowerViewModel towerViewModel, BoxViewModel boxViewModel);
    }
}