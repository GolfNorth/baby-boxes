using Game.Controllers;
using Game.UI.Views;

namespace Game.Models
{
    /// <summary>
    /// Объект для хранения связанных данных башни
    /// </summary>
    public class TowerInstance
    {
        public TowerModel Model { get; }

        public TowerView View { get; }

        public TowerController Controller { get; }

        public TowerInstance(TowerModel model, TowerView view, TowerController controller)
        {
            Model = model;
            View = view;
            Controller = controller;
        }
    }
}