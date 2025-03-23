using System.Collections.Generic;
using Game.Models;
using UnityEngine;

namespace Game.Infrastructure
{
    /// <summary>
    /// Строитель игровой конфигурации
    /// На случай, если в дальнейшем там окажется большое число данных
    /// </summary>
    public class GameConfigBuilder
    {
        private Vector2 _boxSize;
        
        private IEnumerable<Color> _boxColors;

        public GameConfigBuilder SetBoxSize(Vector2 boxSize)
        {
            _boxSize = boxSize;

            return this;
        }

        public GameConfigBuilder SetBoxColors(IEnumerable<Color> boxColors)
        {
            _boxColors = boxColors;

            return this;
        }

        public GameConfig Build()
        {
            return new GameConfig(_boxColors, _boxSize);
        }
    }
}