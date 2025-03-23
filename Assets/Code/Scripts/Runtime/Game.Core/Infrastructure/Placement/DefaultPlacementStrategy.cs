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
        private readonly TowerViewModel _towerViewModel;

        private readonly Vector2 _boxSize;

        public DefaultPlacementStrategy(ITowerRepository towerRepository, IConfigService configService)
        {
            _boxSize = configService.GetConfig().BoxSize;
            _towerViewModel = towerRepository.GetTower();
        }

        public bool TryPlace(BoxViewModel boxViewModel, Vector2 boxPosition, out PlacementError error)
        {
            error = PlacementError.None;

            if (_towerViewModel.Boxes.Count == 0)
            {
                boxViewModel.Position.Value = boxPosition;

                return true;
            }

            if (_towerViewModel.Boxes.Contains(boxViewModel))
            {
                return true;
            }

            var lastPosition = _towerViewModel.Boxes.Last().Position.Value;
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

            if (boxPosition.x < xMinPosition || boxPosition.x > xMaxPosition)
            {
                error = PlacementError.Missed;

                return false;
            }

            boxViewModel.Position.Value = new Vector2(boxPosition.x, yPosition);

            return true;
        }
    }
}