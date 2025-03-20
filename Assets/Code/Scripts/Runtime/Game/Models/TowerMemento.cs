using System;
using System.Collections.Generic;

namespace Game.Models
{
    [Serializable]
    public class TowerMemento
    {
        public IList<BoxMemento> Boxes { get; }

        public TowerMemento(IList<BoxMemento> boxes)
        {
            Boxes = boxes;
        }
    }
}