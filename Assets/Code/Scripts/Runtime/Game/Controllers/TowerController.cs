using Game.Models;
using Game.UI.Views;

namespace Game.Controllers
{
    public class TowerController
    {
        private TowerModel _model;

        private TowerView _view;

        public TowerController(TowerModel model, TowerView view)
        {
            _model = model;
            _view = view;
        }
    }
}