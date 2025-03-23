using Game.Presentation.Infractructure;
using Game.Presentation.Views;
using UnityEngine;
using UnityEngine.Pool;
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

            builder.RegisterFactory<int, BoxView>(id => spawnController.GetView(id));
        }
    }
}