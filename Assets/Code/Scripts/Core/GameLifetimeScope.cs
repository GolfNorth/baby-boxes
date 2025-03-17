using Code.Services;
using Code.Services.Interfaces;
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
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<SceneService>(Lifetime.Singleton).As<ISceneService>();
            builder.RegisterComponent(audioService).As<IAudioService>();
            builder.RegisterEntryPoint<GameEntryPoint>();
        }
    }
}
