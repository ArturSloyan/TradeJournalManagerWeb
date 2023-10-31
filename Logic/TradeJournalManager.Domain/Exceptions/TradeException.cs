namespace TradeJournalManager.Domain.Exceptions
{
    public class TradeException : Exception
    {
        public TradeException(string accessor, string message) : base(message) { Accessor = accessor; }

        public string Accessor { get; set; }

        public override string ToString() => $"{Accessor}: {base.Message}";
    }
}
