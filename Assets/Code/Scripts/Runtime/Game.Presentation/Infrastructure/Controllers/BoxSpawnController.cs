using System.Collections.Generic;
using Game.Enums;
using Game.SDK.Infrastructure.Interfaces;
using Game.Events;
using Game.Infrastructure.Interfaces;
using Game.Presentation.Views;
using Game.Presentation.Components;
using Game.Presentation.Events;
using Game.ViewModels;
using R3;
using UnityEngine;
using UnityEngine.Pool;
using VContainer;

namespace Game.Presentation.Infractructure
{
    /// <summary>
    /// Контроллер спауна новых объектов
    /// </summary>
    public class BoxSpawnController : MonoBehaviour
    {
        [SerializeField]
        private Transform poolParent;

        [SerializeField]
        private BoxPlaceholder towerPlaceholder;

        [SerializeField]
        private BoxPlaceholder placeholderPrefab;

        private IEventBus _eventBus;

        private IObjectPool<BoxView> _boxPool;

        private IBoxRepository _boxRepository;

        private readonly Dictionary<int, BoxView> _boxViews = new();

        private readonly Dictionary<Color, BoxPlaceholder> _boxPlaceholders = new();

        [Inject]
        public void Construct(IBoxRepository boxRepository, IObjectPool<BoxView> boxPool, IEventBus eventBus)
        {
            _boxRepository = boxRepository;
            _boxPool = boxPool;
            _eventBus = eventBus;

            eventBus.Subscribe<BoxCreatedEvent>(OnBoxCreated).AddTo(this);
            eventBus.Subscribe<BoxReleasedEvent>(OnBoxDropped).AddTo(this);
        }

        public BoxView GetView(int id)
        {
            return _boxViews.GetValueOrDefault(id);
        }

        private void OnBoxCreated(BoxCreatedEvent e)
        {
            var viewModel = _boxRepository.GetBoxById(e.Id);

            CreateView(viewModel);
        }

        private void OnBoxDropped(BoxReleasedEvent e)
        {
            _boxViews.Remove(e.Id);
        }

        private void CreateView(BoxViewModel viewModel)
        {
            var view = _boxPool.Get();
            view.Init(viewModel);

            Place(viewModel, view);

            _boxViews.Add(viewModel.Id.CurrentValue, view);
        }

        private void Place(BoxViewModel viewModel, BoxView view)
        {
            switch (viewModel.State.Value)
            {
                case BoxState.Idle:
                    var placeholder = GetPlaceholder(viewModel.Color.CurrentValue);
                    placeholder.Place(view, Vector2.zero);
                    _eventBus.Publish(new BoxPlacementChangedEvent(view, BoxPlacement.Stack));
                    break;
                case BoxState.Placed:
                    towerPlaceholder.Place(view, viewModel.Position.Value);
                    _eventBus.Publish(new BoxPlacementChangedEvent(view, BoxPlacement.Tower));
                    break;
            }
        }

        private BoxPlaceholder GetPlaceholder(Color color)
        {
            if (!_boxPlaceholders.TryGetValue(color, out var placeholder))
            {
                placeholder = CreatePlaceholder();

                _boxPlaceholders.Add(color, placeholder);
            }

            return placeholder;
        }

        private BoxPlaceholder CreatePlaceholder()
        {
            var result = Instantiate(placeholderPrefab, poolParent);
            result.transform.localScale = Vector3.one;

            return result;
        }
    }
}