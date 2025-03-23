using System.Collections.Generic;
using Game.ViewModels;

namespace Game.Infrastructure.Interfaces
{
    /// <summary>
    /// Репозиторий для получения башни
    /// </summary>
    public interface ITowerRepository
    {
        TowerViewModel GetTower(IEnumerable<int> boxIds = null);
    }
}