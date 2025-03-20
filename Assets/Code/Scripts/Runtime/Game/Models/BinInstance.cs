using Game.Controllers;
using Game.UI.Views;

namespace Game.Models
{
    /// <summary>
    /// Объект для хранения связанных данных утилизатора кубов
    /// </summary>
    public class BinInstance
    {
        public BinView View { get; }

        public BinController BinController { get; }

        public BinInstance(BinView view, BinController binController)
        {
            View = view;
            BinController = binController;
        }
    }
}