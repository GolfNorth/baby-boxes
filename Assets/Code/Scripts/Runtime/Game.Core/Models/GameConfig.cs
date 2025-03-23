using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Models
{
    /// <summary>
    /// Конфигурация игры
    /// </summary>
    public sealed class GameConfig
    {
        /// <summary>
        /// Число кубиков
        /// </summary>
        public int BoxCount { get; }

        /// <summary>
        /// Размер куба
        /// </summary>
        public Vector2 BoxSize { get; }

        /// <summary>
        /// Цвета кубиков
        /// </summary>
        public IReadOnlyCollection<Color> BoxColors { get; }

        public GameConfig(IEnumerable<Color> boxColors, Vector2 boxSize)
        {
            if (boxColors == null)
                throw new ArgumentNullException(nameof(boxColors));

            BoxSize = boxSize;
            BoxColors = boxColors.ToList();
            BoxCount = BoxColors.Count;
        }
    }
}