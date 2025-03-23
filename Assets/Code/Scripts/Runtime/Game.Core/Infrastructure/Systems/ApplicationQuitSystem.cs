using Game.Events;
using Game.SDK.Infrastructure.Interfaces;
using UnityEngine;
using VContainer;

namespace Game.Infrastructure
{
    public class ApplicationQuitSystem : MonoBehaviour
    {
        private IEventBus _eventBus;
        
        [Inject]
        public void Construct(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        
        private void OnApplicationQuit()
        {
            _eventBus.Publish(new ApplicationQuitEvent());
        }
    }
}