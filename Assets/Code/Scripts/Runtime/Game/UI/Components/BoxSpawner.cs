using System.Collections.Generic;
using Core.Infrastructure.Interfaces;
using Game.Events;
using Game.Systems.Interfaces;
using Game.UI.Components;
using UnityEngine;
using VContainer;

namespace Game.Controllers
{
    /// <summary>
    /// Контроллер спауна новых объектов
    /// </summary>
    public class BoxSpawner : MonoBehaviour
    {
        [SerializeField]
        private Transform parent;

        [SerializeField]
        private BoxPlaceholder placeholderPrefab;

        private IEventBus _eventBus;

        private IBoxRepository _boxRepository;

        private Dictionary<Color, BoxPlaceholder> _boxPlaceholders = new();

        [Inject]
        public void Init(IBoxRepository boxRepository, IEventBus eventBus)
        {
            _boxRepository = boxRepository;
            eventBus.Subscribe<BoxCreatedEvent>(OnBoxCreated);
        }

        private void OnBoxCreated(BoxCreatedEvent e)
        {
            var box = _boxRepository.GetCubeById(e.Id);

            if (!_boxPlaceholders.TryGetValue(box.Model.Color, out var placeholder))
            {
                placeholder = CreatePlaceholder();

                _boxPlaceholders.Add(box.Model.Color, placeholder);
            }

            placeholder.Place(box.View);
        }

        private BoxPlaceholder CreatePlaceholder()
        {
            var result = Instantiate(placeholderPrefab, parent);
            result.transform.localScale = Vector3.one;

            return result;
        }
    }
}