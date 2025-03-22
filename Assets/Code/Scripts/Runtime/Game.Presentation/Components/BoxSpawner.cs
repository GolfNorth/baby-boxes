using System.Collections.Generic;
using Game.SDK.Infrastructure.Interfaces;
using Game.Events;
using Game.Presentation.Views;
using Game.Systems.Interfaces;
using Game.UI.Components;
using UnityEngine;
using UnityEngine.Pool;
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

        private IObjectPool<BoxView> _boxPool;

        private IBoxRepository _boxRepository;

        private Dictionary<Color, BoxPlaceholder> _boxPlaceholders = new();

        [Inject]
        public void Init(IBoxRepository boxRepository, IObjectPool<BoxView> boxPool, IEventBus eventBus)
        {
            _boxRepository = boxRepository;
            _boxPool = boxPool;

            eventBus.Subscribe<BoxCreatedEvent>(OnBoxCreated);
        }

        private void OnBoxCreated(BoxCreatedEvent e)
        {
            var viewModel = _boxRepository.GetCubeById(e.Id);

            if (!_boxPlaceholders.TryGetValue(viewModel.Color.CurrentValue, out var placeholder))
            {
                placeholder = CreatePlaceholder();

                _boxPlaceholders.Add(viewModel.Color.CurrentValue, placeholder);
            }

            var view = _boxPool.Get();

            // TODO Inject вьюшки

            placeholder.Place(view);
        }

        private BoxPlaceholder CreatePlaceholder()
        {
            var result = Instantiate(placeholderPrefab, parent);
            result.transform.localScale = Vector3.one;

            return result;
        }
    }
}