using System.ComponentModel.DataAnnotations;

namespace TradeJournalManager.Domain
{
    public class BaseModel
    {
        [Required]
        public int Id { get; set; }
    }
}
