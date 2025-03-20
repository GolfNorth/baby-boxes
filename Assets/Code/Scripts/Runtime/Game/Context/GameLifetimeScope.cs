using Game.Infrastructure;
using Game.Infrastructure.Interfaces;
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
            builder.Register<ConfigService>(Lifetime.Singleton).As<IConfigService>();
            builder.RegisterInstance(configLoader).As<IConfigLoader>();
            builder.RegisterEntryPoint<GameEntryPoint>();
        }
    }
}