using Game.Presentation.Infractructure;
using Game.Presentation.Views;
using Game.ViewModels;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Serialization;
using VContainer;
using VContainer.Unity;

namespace Game.Presentation.Context
{
    public class PresentationLifetimeScope : LifetimeScope
    {
        [SerializeField]
        private BoxSpawnController spawnController;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<BoxObjectPool>().As<IObjectPool<BoxView>>();
            builder.Register<PresentationManager>(Lifetime.Singleton).AsImplementedInterfaces();

            builder.RegisterFactory<int, BoxView>(id => spawnController.GetView(id));
        }
    }
}