using System;
using Newtonsoft.Json;
using UnityEngine;

namespace Game.Models
{
    [Serializable]
    public class BoxMemento
    {
        [JsonProperty]
        public ColorSimple Color { get; private set; }

        [JsonProperty]
        public float X { get; private set; }

        [JsonProperty]
        public float Y { get; private set; }

        public BoxMemento(Color color, Vector2 position)
        {
            Color = (ColorSimple)color;
            X = position.x;
            Y = position.y;
        }
    }
}