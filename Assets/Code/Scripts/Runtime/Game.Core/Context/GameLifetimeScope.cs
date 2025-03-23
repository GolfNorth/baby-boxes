using System;
using System.Collections.Generic;
using Game.Infrastructure;
using Game.Infrastructure.Interfaces;
using Game.Models;
using Game.Services;
using Game.Services.Interfaces;
using UnityEngine;
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

            builder.Register<ConfigService>(Lifetime.Singleton).As<IConfigService>();
            builder.Register<SaveService>(Lifetime.Singleton).As<ISaveService>();

            builder.Register<BoxRepository>(Lifetime.Singleton).As<IBoxRepository>();
            builder.Register<TowerRepository>(Lifetime.Singleton).As<ITowerRepository>();

            builder.Register<SaveSystem>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<SpawnSystem>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<PlacementSystem>(Lifetime.Singleton).AsImplementedInterfaces();

            builder.Register<DefaultPlacementStrategy>(Lifetime.Scoped).As<IPlacementStrategy>();
            builder.Register<PlacementFactory>(Lifetime.Singleton).As<IPlacementFactory>();

            builder.RegisterFactory<int, Color, BoxModel>((id, color) => new BoxModel(id, color));
            builder.RegisterFactory<IEnumerable<int>, TowerModel>(boxIds => new TowerModel(boxIds));
        }
    }
}