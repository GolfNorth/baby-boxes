using Game.ViewModels;
using VContainer;

namespace Game.Infrastructure
{
    public class PlacementFactory : IPlacementFactory
    {
        private readonly IObjectResolver _container;

        public PlacementFactory(IObjectResolver container)
        {
            _container = container;
        }

        public IPlacementStrategy GetStrategy(TowerViewModel towerViewModel, BoxViewModel boxViewModel)
        {
            return _container.Resolve<IPlacementStrategy>();
        }
    }
}