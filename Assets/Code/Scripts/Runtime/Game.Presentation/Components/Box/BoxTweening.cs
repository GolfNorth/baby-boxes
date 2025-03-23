using Game.Enums;
using Game.Presentation.Events;
using Game.SDK.Infrastructure.Interfaces;
using R3;
using UnityEngine;
using VContainer;

namespace Game.Presentation.Components
{
    public class BoxTweening : BoxComponent
    {
        [SerializeReference]
        private TweenBase toNone = new TweenScale();

        [SerializeReference]
        private TweenBase toStack = new TweenPunch();

        [SerializeReference]
        private TweenBase toTower = new TweenJump();

        [SerializeReference]
        private TweenBase toBin = new TweenJump();

        private RectTransform _rect;

        private IEventBus _eventBus;

        [Inject]
        public void Construct(IEventBus eventBus)
        {
            _rect = (RectTransform)transform;
            _eventBus = eventBus;

            _eventBus.Subscribe<BoxPlacementChangedEvent>(OnPlacementChanged).AddTo(this);
        }

        private void OnPlacementChanged(BoxPlacementChangedEvent e)
        {
            if (e.View != View)
                return;

            switch (e.Placement)
            {
                case BoxPlacement.Stack:
                    toStack.Play(_rect, Vector2.zero, OnComplete);
                    break;
                case BoxPlacement.Bin:
                    toBin.Play(_rect, Vector2.zero, OnComplete);
                    break;
                case BoxPlacement.Tower:
                    toTower.Play(_rect, DataContext.Position.Value, OnComplete);
                    break;
                default:
                    toNone.Play(_rect, Vector2.zero, OnComplete);
                    break;
            }
        }

        private void OnComplete()
        {
            _eventBus.Publish(new BoxTweenedEvent(View));
        }
    }
}