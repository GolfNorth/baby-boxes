using System;
using UnityEngine;

namespace Game.Models
{
    [Serializable]
    public class BoxMemento
    {
        public Vector2 Position { get; }

        public Color Color { get; }

        public BoxMemento(Vector2 position, Color color)
        {
            Position = position;
            Color = color;
        }
    }
}