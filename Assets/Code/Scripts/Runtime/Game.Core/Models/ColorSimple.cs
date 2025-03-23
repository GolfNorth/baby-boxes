using System;
using Newtonsoft.Json;
using UnityEngine;

namespace Game.Models
{
    /// <summary>
    /// Упрощенный тип цвета
    /// </summary>
    [Serializable]
    public class ColorSimple
    {
        [JsonProperty]
        public float R { get; private set; }

        [JsonProperty]
        public float G { get; private set; }

        [JsonProperty]
        public float B { get; private set; }

        [JsonProperty]
        public float A { get; private set; }

        public ColorSimple()
        {
        }

        public ColorSimple(Color color)
        {
            R = color.r;
            G = color.g;
            B = color.b;
            A = color.a;
        }

        public static implicit operator Color(ColorSimple cs) => new Color(cs.R, cs.G, cs.B, cs.A);

        public static explicit operator ColorSimple(Color color) => new ColorSimple(color);
    }
}