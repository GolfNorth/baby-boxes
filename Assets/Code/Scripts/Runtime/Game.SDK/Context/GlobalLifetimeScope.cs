using Game.SDK.Infrastructure;
using Game.SDK.Infrastructure.Interfaces;
using Game.SDK.Services;
using Game.SDK.Services.Interfaces;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.SDK.Context
{
    /// <summary>
    /// Основной контекст приложения
    /// </summary>
    public class GlobalLifetimeScope : LifetimeScope
    {
        [SerializeField]
        private AudioService audioService;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<SceneService>(Lifetime.Singleton).As<ISceneService>();
            builder.RegisterComponent(audioService).As<IAudioService>();
            builder.Register<R3EventBus>(Lifetime.Singleton).As<IEventBus>();
            builder.RegisterEntryPoint<GlobalEntryPoint>();
        }
    }
}
