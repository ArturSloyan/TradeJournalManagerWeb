using System.ComponentModel.DataAnnotations;

namespace TradeJournalManager.Domain.Models
{
    public class Quote : BaseModel
    {
        [Required]
        public string Text { get; set; } = string.Empty;
    }
}
