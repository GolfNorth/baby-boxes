using System.Collections.Generic;
using System.Linq;
using Game.Enums;
using Game.Infrastructure.Interfaces;
using Game.Services.Interfaces;
using Game.ViewModels;
using UnityEngine;

namespace Game.Infrastructure
{
    public class DefaultPlacementStrategy : IPlacementStrategy
    {
        private readonly IBoxRepository _boxRepository;

        private readonly TowerViewModel _towerViewModel;

        private readonly Vector2 _boxSize;

        public DefaultPlacementStrategy(IBoxRepository boxRepository, ITowerRepository towerRepository,
            IConfigService configService)
        {
            _boxSize = configService.GetConfig().BoxSize;
            _boxRepository = boxRepository;
            _towerViewModel = towerRepository.GetTower();
        }

        public bool TryPlace(BoxViewModel boxViewModel, Vector2 boxPosition, out PlacementError error)
        {
            error = PlacementError.None;

            if (_towerViewModel.BoxIds.Count == 0)
            {
                boxViewModel.Position.Value = boxPosition;

                return true;
            }

            if (_towerViewModel.BoxIds.Contains(boxViewModel.Id.CurrentValue))
            {
                return true;
            }

            var boxes = GetSortedBoxes();
            var lastPosition = boxes.Last().Position.Value;
            var yPosition = lastPosition.y + _boxSize.y;
            var towerRect = new Rect(new Vector2(-_towerViewModel.Size.Value.x / 2, 0), _towerViewModel.Size.Value);

            if (yPosition + _boxSize.y / 2 > towerRect.yMax)
            {
                error = PlacementError.LimitReached;

                return false;
            }

            if (yPosition > boxPosition.y)
            {
                error = PlacementError.LowerLast;

                return false;
            }

            var xMinPosition = lastPosition.x - _boxSize.x / 2;
            var xMaxPosition = lastPosition.x + _boxSize.x / 2;

            xMinPosition = xMinPosition < towerRect.xMin + _boxSize.x ? towerRect.xMin + _boxSize.x : xMinPosition;
            xMaxPosition = xMaxPosition > towerRect.xMax + _boxSize.x ? towerRect.xMax - _boxSize.x : xMaxPosition;

            var xPosition = Random.Range(xMinPosition, xMaxPosition);

            boxViewModel.Position.Value = new Vector2(xPosition, yPosition);

            return true;
        }

        private IList<BoxViewModel> GetSortedBoxes()
        {
            return _towerViewModel.BoxIds
                .Select(x => _boxRepository.GetBoxById(x))
                .OrderBy(x => x.Position.Value.y)
                .ToList();
        }
    }
}