using Game.Presentation.Infractructure;
using Game.Presentation.Views;
using UnityEngine.Pool;
using VContainer;
using VContainer.Unity;

namespace Game.Presentation.Context
{
    public class PresentationLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<BoxObjectPool>().As<IObjectPool<BoxView>>();
            builder.Register<PresentationManager>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}