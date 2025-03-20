using Game.Controllers;
using Game.Factories.Interfaces;
using Game.Models;
using Game.UI.Views;
using UnityEngine;
using UnityEngine.Pool;
using VContainer;
using VContainer.Unity;

namespace Game.Factories
{
    /// <summary>
    /// Фабрика создания кубов
    /// </summary>
    public sealed class BoxFactory : IBoxFactory
    {
        private readonly IObjectResolver _container;
        
        private readonly IObjectPool<BoxView> _objectPool;

        public BoxFactory(IObjectResolver container, IObjectPool<BoxView> objectPool)
        {
            _container = container;
            _objectPool = objectPool;
        }

        public BoxInstance CreateBox(int id, Color color)
        {
            var model = new BoxModel(id, color);
            var view = _objectPool.Get();
            var controller = new BoxController(model, view);

            _container.InjectGameObject(view.gameObject);
            view.Init(model.Id, model.Color);
            view.name = $"Box #{model.Id}";

            return new BoxInstance(model, view, controller);
        }
    }
}