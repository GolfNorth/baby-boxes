using Game.Factories;
using Game.Factories.Interfaces;
using Game.Infrastructure;
using Game.Infrastructure.Interfaces;
using Game.Services;
using Game.Services.Interfaces;
using Game.Systems.Interfaces;
using Game.UI.Views;
using UnityEngine;
using UnityEngine.Pool;
using VContainer;
using VContainer.Unity;

namespace Game.Context
{
    /// <summary>
    /// Игровой контекст приложения
    /// </summary>
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField]
        private BaseConfigLoader configLoader;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(configLoader).As<IConfigLoader>();
            builder.RegisterComponentInHierarchy<BoxObjectPool>().As<IObjectPool<BoxView>>();
            builder.Register<ConfigService>(Lifetime.Singleton).As<IConfigService>();
            builder.Register<BoxFactory>(Lifetime.Singleton).As<IBoxFactory>();
            builder.Register<SaveService>(Lifetime.Singleton).As<ISaveService>();
            builder.Register<BinRepository>(Lifetime.Singleton).As<IBinRepository>();
            builder.Register<BoxRepository>(Lifetime.Singleton).As<IBoxRepository>();
            builder.Register<TowerRepository>(Lifetime.Singleton).As<ITowerRepository>();
            builder.Register<GameManager>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}