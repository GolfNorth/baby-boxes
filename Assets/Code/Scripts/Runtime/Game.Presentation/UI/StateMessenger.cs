using DG.Tweening;
using Game.Enums;
using Game.Events;
using Game.SDK.Infrastructure.Interfaces;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using VContainer;

namespace Game.Presentation.Components
{
    /// <summary>
    /// Информатор об игровых событиях
    /// </summary>
    public class StateMessenger : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text text;

        [SerializeField]
        private float duration;

        [SerializeField]
        private LocalizedString boxPlacement;

        [SerializeField]
        private LocalizedString boxRemoval;

        [SerializeField]
        private LocalizedString boxDropping;

        [SerializeField]
        private LocalizedString boxLimitation;

        private Color _defaultColor;

        private void Awake()
        {
            _defaultColor = text.color;

            boxPlacement.RefreshString();
            boxRemoval.RefreshString();
            boxDropping.RefreshString();
            boxLimitation.RefreshString();
        }

        [Inject]
        public void Construct(IEventBus eventBus)
        {
            eventBus.Subscribe<BoxPlacedEvent>(_ => ShowMessage(boxPlacement.GetLocalizedString())).AddTo(this);
            eventBus.Subscribe<BoxRemovedEvent>(_ => ShowMessage(boxRemoval.GetLocalizedString())).AddTo(this);
            eventBus.Subscribe<BoxDestroyedEvent>(_ => ShowMessage(boxDropping.GetLocalizedString())).AddTo(this);
            eventBus.Subscribe<BoxPlacementErrorEvent>(e =>
            {
                if (e.Error == PlacementError.LimitReached)
                {
                    ShowMessage(boxLimitation.GetLocalizedString());
                }
            }).AddTo(this);
        }

        private void ShowMessage(string message)
        {
            text.DOKill();
            text.color = _defaultColor;
            text.text = message;
            text.DOFade(0, duration);
        }
    }
}