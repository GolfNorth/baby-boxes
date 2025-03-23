using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Models
{
    /// <summary>
    /// Модель башни
    /// </summary>
    public class TowerModel
    {
        public List<int> BoxIds { get; }

        public Vector2 Size { get; set; }

        public TowerModel(IEnumerable<int> boxIds = null)
        {
            BoxIds = boxIds != null ? BoxIds = new List<int>(boxIds) : new List<int>();
        }
    }
}