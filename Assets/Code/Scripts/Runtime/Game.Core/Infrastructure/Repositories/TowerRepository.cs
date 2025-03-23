using System;
using System.Collections.Generic;
using Game.ViewModels;
using Game.Infrastructure.Interfaces;
using Game.Models;

namespace Game.Infrastructure
{
    public class TowerRepository : ITowerRepository
    {
        private TowerViewModel _towerViewModel;

        private readonly Func<IEnumerable<int>, TowerModel> _modelFactory;

        private readonly IBoxRepository _boxRepository;

        public TowerRepository(Func<IEnumerable<int>, TowerModel> modelFactory, IBoxRepository boxRepository)
        {
            _modelFactory = modelFactory;
            _boxRepository = boxRepository;
        }

        public TowerViewModel GetTower(IEnumerable<int> boxIds = null)
        {
            if (_towerViewModel == null)
            {
                var model = _modelFactory.Invoke(boxIds);

                _towerViewModel = new TowerViewModel(model, _boxRepository);
            }

            return _towerViewModel;
        }
    }
}