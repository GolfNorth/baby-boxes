using Game.UI.Views;

namespace Game.Controllers
{
    /// <summary>
    /// Контроллер утилизатора кубов
    /// </summary>
    public class BinController
    {
        private BinView _view;

        public BinController(BinView view)
        {
            _view = view;
        }
    }
}