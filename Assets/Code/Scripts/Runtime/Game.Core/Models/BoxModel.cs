using System;
using Game.Enums;
using UnityEngine;

namespace Game.Models
{
    /// <summary>
    /// Модель куба
    /// </summary>
    [Serializable]
    public class BoxModel
    {
        /// <summary>
        /// Уникальный идентификатор куба
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Цвет куба
        /// </summary>
        public Color Color { get; }

        /// <summary>
        /// Позиция в башне
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Текущее состояние куба
        /// </summary>
        public BoxState State { get; set; }

        public BoxModel(int id, Color color)
        {
            Id = id;
            Color = color;
        }
    }
}