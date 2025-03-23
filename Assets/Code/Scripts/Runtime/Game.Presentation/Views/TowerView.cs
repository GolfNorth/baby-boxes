using System;
using Game.Infrastructure.Interfaces;
using Game.ViewModels;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Presentation.Views
{
    /// <summary>
    /// Вьюшка башни
    /// </summary>
    public class TowerView : MonoBehaviour
    {
        private RectTransform _rect;

        private TowerViewModel _towerViewModel;

        [Inject]
        public void Construct(ITowerRepository towerRepository)
        {
            _rect = (RectTransform)transform;
            _towerViewModel = towerRepository.GetTower();
            _towerViewModel.Size.Value = _rect.rect.size;
        }

        private void LateUpdate()
        {
            if (!transform.hasChanged)
                return;

            _towerViewModel.Size.Value = _rect.rect.size;

            transform.hasChanged = false;
        }
    }
}