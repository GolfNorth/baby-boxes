using System;
using System.Collections.Generic;
using Game.Controllers;
using Game.Infrastructure.Interfaces;
using Game.Models;

namespace Game.Infrastructure
{
    public class TowerRepository : ITowerRepository
    {
        private TowerViewModel _towerViewModel;

        private Func<IEnumerable<int>, TowerModel> _modelFactory;

        public TowerRepository(Func<IEnumerable<int>, TowerModel> modelFactory)
        {
            _modelFactory = modelFactory;
        }

        public TowerViewModel GetTower(IEnumerable<int> boxIds = null)
        {
            if (_towerViewModel == null)
            {
                var model = _modelFactory.Invoke(boxIds);

                _towerViewModel = new TowerViewModel(model);
            }

            return _towerViewModel;
        }
    }
}