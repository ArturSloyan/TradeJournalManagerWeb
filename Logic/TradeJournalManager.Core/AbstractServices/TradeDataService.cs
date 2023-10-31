using TradeJournalManager.Domain.Extensions;
using TradeJournalManager.Domain.Models;

namespace TradeJournalManager.Core.AbstractServices
{
    public abstract class TradeDataService : IDataService<Trade>
    {
        public virtual void Add(Trade item)
        {
            item
                .IsNotNull()
                .Validate();
        }

        public virtual void Edit(Trade item, int id)
        {
            item
                .IsNotNull()
                .Validate();

            id.IsNotNull();
        }

        public virtual void Delete(int id)
        {
            id.IsNotNull();
        }

        public abstract Task<List<Trade>> GetAll();
    }
}
