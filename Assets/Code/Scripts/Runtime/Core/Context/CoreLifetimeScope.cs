using Core.Infrastructure;
using Core.Services.Interfaces;
using Core.Infrastructure.Interfaces;
using Core.Services;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core.Context
{
    /// <summary>
    /// Основной контекст приложения
    /// </summary>
    public class CoreLifetimeScope : LifetimeScope
    {
        [SerializeField]
        private AudioService audioService;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<SceneService>(Lifetime.Singleton).As<ISceneService>();
            builder.RegisterComponent(audioService).As<IAudioService>();
            builder.Register<R3EventBus>(Lifetime.Singleton).As<IEventBus>();
            builder.RegisterEntryPoint<CoreEntryPoint>();
        }
    }
}
