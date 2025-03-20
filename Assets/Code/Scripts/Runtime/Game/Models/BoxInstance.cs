using Game.Controllers;
using Game.UI.Views;

namespace Game.Models
{
    /// <summary>
    /// Объект для хранения связанных данных куба
    /// </summary>
    public class BoxInstance
    {
        public BoxModel Model { get; }
        public BoxView View { get; }
        public BoxController Controller { get; }

        public BoxInstance(BoxModel model, BoxView view, BoxController controller)
        {
            Model = model;
            View = view;
            Controller = controller;
        }
    }
}