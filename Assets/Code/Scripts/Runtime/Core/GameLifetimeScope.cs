using Code.Services;
using Code.Services.Interfaces;
using Game.Infrastructure;
using Game.Infrastructure.Interfaces;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Core
{
    /// <summary>
    /// Основной контекст приложения
    /// </summary>
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField]
        private AudioService audioService;

        [SerializeField]
        private BaseConfigLoader configLoader;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<ConfigService>(Lifetime.Singleton).As<IConfigService>();
            builder.Register<SceneService>(Lifetime.Singleton).As<ISceneService>();
            builder.RegisterComponent(audioService).As<IAudioService>();
            builder.RegisterInstance(configLoader).As<IConfigLoader>();
            builder.Register<R3EventBus>(Lifetime.Singleton).As<IEventBus>();
            builder.RegisterEntryPoint<GameEntryPoint>();
        }
    }
}
