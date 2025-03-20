using System.Collections.Generic;

namespace Game.Models
{
    /// <summary>
    /// Модель башни
    /// </summary>
    public class TowerModel
    {
        public Stack<BoxModel> Boxes { get; set; } = new Stack<BoxModel>();
    }
}