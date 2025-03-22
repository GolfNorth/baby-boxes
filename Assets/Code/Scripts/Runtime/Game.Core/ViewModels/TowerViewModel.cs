using Game.Models;

namespace Game.Controllers
{
    public class TowerViewModel
    {
        private TowerModel _model;

        public TowerViewModel(TowerModel model)
        {
            _model = model;
        }
    }
}