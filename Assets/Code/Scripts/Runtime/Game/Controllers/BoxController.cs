using Game.Models;
using Game.UI.Views;

namespace Game.Controllers
{
    /// <summary>
    /// Котроллер куба
    /// </summary>
    public class BoxController
    {
        private readonly BoxModel _model;

        private readonly BoxView _view;

        public BoxController(BoxModel model, BoxView view)
        {
            _model = model;
            _view = view;
        }
    }
}