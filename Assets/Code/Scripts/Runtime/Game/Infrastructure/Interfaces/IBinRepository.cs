using Game.Models;

namespace Game.Systems.Interfaces
{
    /// <summary>
    /// Репозиторий для доступа к утилизатору кубов
    /// </summary>
    public interface IBinRepository
    {
        BinInstance GetBin();
    }
}