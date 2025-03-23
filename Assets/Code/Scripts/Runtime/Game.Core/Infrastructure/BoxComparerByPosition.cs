using System.Collections.Generic;
using Game.ViewModels;

namespace Game.Infrastructure
{
    public class BoxComparerByPosition : IComparer<BoxViewModel>
    {
        public int Compare(BoxViewModel x, BoxViewModel y)
        {
            return x.Position.Value.y.CompareTo(y.Position.Value.y);
        }
    }
}