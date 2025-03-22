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
        /// Цвета кубиков
        /// </summary>
        public IReadOnlyCollection<Color> BoxColors { get; }

        public GameConfig(IEnumerable<Color> boxColors)
        {
            if (boxColors == null)
                throw new ArgumentNullException(nameof(boxColors));

            BoxColors = boxColors.ToList();
            BoxCount = BoxColors.Count;
        }
    }
}