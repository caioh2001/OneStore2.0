using OneStore.Models;

namespace OneStore.Repositories.Interfaces
{
    public interface IRoupaRepository
    {
        IEnumerable<Roupa> GetRoupas { get; }

        IEnumerable<Roupa> RoupasPreferidas { get; }

        Roupa GetRoupaByID(int id);
    }
}
