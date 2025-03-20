using Game.Controllers;
using Game.Infrastructure.Interfaces;
using Game.Models;
using Game.UI.Views;
using UnityEngine;

namespace Game.Infrastructure
{
    public class TowerRepository : ITowerRepository
    {
        private TowerInstance _towerInstance;

        public TowerInstance GetTower()
        {
            if (_towerInstance == null)
            {
                var model = new TowerModel();
                var view = Object.FindObjectOfType<TowerView>();
                var controller = new TowerController(model, view);

                _towerInstance = new TowerInstance(model, view, controller);
            }

            return _towerInstance;
        }
    }
}