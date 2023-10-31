using TradeJournalManager.Domain.Models;

namespace TradeJournalManager.Core
{
    public interface IDataService<T>
    {
        void Add(T item);
        void Edit(T item, int id);
        void Delete(int id);
        Task<List<T>> GetAll();
    }
}