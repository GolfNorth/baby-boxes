using Game.Events;
using Game.SDK.Infrastructure.Interfaces;
using Game.SDK.Services.Interfaces;
using R3;
using UnityEngine;
using VContainer;

namespace Game.Presentation.Infractructure
{
    /// <summary>
    /// Контроллер звуков
    /// </summary>
    public class AudioController : MonoBehaviour
    {
        [SerializeField]
        private string musicAudio;

        [SerializeField]
        private string clickAudio;

        [SerializeField]
        private string placeAudio;

        [SerializeField]
        private string removeAudio;

        [SerializeField]
        private string destroyAudio;

        private IAudioService _audioService;
        private IEventBus _eventBus;

        [Inject]
        public void Construct(IAudioService audioService, IEventBus eventBus)
        {
            _audioService = audioService;
            _eventBus = eventBus;
        }

        public void Start()
        {
            _audioService.PlayMusic(musicAudio);

            _eventBus.Subscribe<BoxPlacedEvent>(_ => _audioService.PlaySound(placeAudio)).AddTo(this);
            _eventBus.Subscribe<BoxRemovedEvent>(_ => _audioService.PlaySound(removeAudio)).AddTo(this);
            _eventBus.Subscribe<BoxDestroyedEvent>(_ => _audioService.PlaySound(destroyAudio)).AddTo(this);
        }
    }
}