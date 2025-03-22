using System;
using System.Collections.Generic;

namespace Game.Models
{
    /// <summary>
    /// Модель башни
    /// </summary>
    [Serializable]
    public class TowerModel
    {
        public List<int> BoxIds { get; }

        public TowerModel(IEnumerable<int> boxIds = null)
        {
            BoxIds = boxIds != null ? BoxIds = new List<int>(boxIds) : new List<int>();
        }
    }
}