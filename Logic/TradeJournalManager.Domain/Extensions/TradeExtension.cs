using System.ComponentModel.DataAnnotations;
using TradeJournalManager.Domain.Exceptions;
using TradeJournalManager.Domain.Models;

namespace TradeJournalManager.Domain.Extensions
{
    public static class TradeExtension
    {
        public static Trade Validate(this Trade trade)
        {
            ValidationContext context = new(trade);
            List<ValidationResult> results = new();

            if (!Validator.TryValidateObject(trade, context, results, true))
            {
                foreach (ValidationResult result in results)
                {
                    throw new TradeException(result.MemberNames?.FirstOrDefault(), result.ErrorMessage);
                }
            }
            return trade;
        }
        public static Trade IsNotNull(this Trade trade)
        {
            _ = trade ?? throw new NullReferenceException(nameof(Trade));

            return trade;
        }
        public static int IsNotNull(this int id)
        {
            if (id == 0)
                throw new NullReferenceException(nameof(id));

            return id;
        }

        public static bool IsWinningTrade(this Trade trade)
        {
            return trade.Buy < trade.Sell && trade.Sell != 0;
        }
        public static bool IsLosingTrade(this Trade trade)
        {
            return trade.Buy > trade.Sell && trade.Sell != 0;
        }

        public static double LongCalculation(this Trade trade)
        {
            return trade.Sell - trade.Buy;
        }
        public static double ShortCalculation(this Trade trade)
        {
            return trade.Buy - trade.Sell;
        }
        public static bool IsSellTextboxEmpty(this Trade trade)
        {
            return trade.Sell == 0;
        }
    }
}
