using Game.Models;

namespace Game.Infrastructure.Interfaces
{
    /// <summary>
    /// Репозиторий для получения башни
    /// </summary>
    public interface ITowerRepository
    {
        TowerInstance GetTower();
    }
}