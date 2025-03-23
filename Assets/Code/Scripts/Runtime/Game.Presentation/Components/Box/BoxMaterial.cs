using Game.Events;
using Game.SDK.Infrastructure.Interfaces;
using R3;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Game.Presentation.Components
{
    /// <summary>
    /// Компонент смены материала
    /// </summary>
    public class BoxMaterial : BoxComponent
    {
        [SerializeField]
        private Image image;

        [SerializeField]
        private Material binMaterial;

        private Material _defaultMaterial;

        [Inject]
        public void Construct(IEventBus eventBus)
        {
            eventBus.Subscribe<BoxRemovedEvent>(OnBoxRemoved).AddTo(this);
        }

        protected override void Awake()
        {
            base.Awake();

            _defaultMaterial = image.material;
        }

        private void OnEnable()
        {
            image.material = _defaultMaterial;
        }

        private void OnBoxRemoved(BoxRemovedEvent e)
        {
            if (e.Id != View.Id)
                return;

            image.material = binMaterial;
        }
    }
}