using Dapper;
using Microsoft.Data.Sqlite;
using TradeJournalManager.Core.AbstractServices;
using TradeJournalManager.Domain.Models;

namespace TradeJournalManager.Core.TradeServices
{
    public class TradeSqLiteDataService : TradeDataService
    {
        private readonly SqliteConnection _connection;
        public TradeSqLiteDataService(string dbPath)
        {
            _connection = new SqliteConnection($"Data Source = {dbPath}");
        }

        public override async void Add(Trade item)
        {
            base.Add(item);

            _connection.Open();
            await _connection.ExecuteAsync($"""
                INSERT INTO {nameof(Trade)}(
                {nameof(Trade.Strategy)},
                {nameof(Trade.NameOfIndicator)},
                {nameof(Trade.NameOfCertificate)},
                {nameof(Trade.Buy)},
                {nameof(Trade.Sell)},
                {nameof(Trade.ThinkProcess)},
                {nameof(Trade.EntryDate)},
                {nameof(Trade.ExitDate)},
                {nameof(Trade.IsClosed)}) VALUES(
                @{nameof(Trade.Strategy)},
                @{nameof(Trade.NameOfIndicator)},
                @{nameof(Trade.NameOfCertificate)},
                @{nameof(Trade.Buy)},
                @{nameof(Trade.Sell)},
                @{nameof(Trade.ThinkProcess)},
                @{nameof(Trade.EntryDate)}, 
                @{nameof(Trade.ExitDate)},
                @{nameof(Trade.IsClosed)})
                """, new { item.Strategy, item.NameOfIndicator, item.NameOfCertificate, item.Buy, item.Sell, item.ThinkProcess, item.EntryDate, item.ExitDate, item.IsClosed });
            _connection.Close();
        }

        public override async void Edit(Trade item, int id)
        {
            base.Edit(item, id);

            _connection.Open();
            await _connection.ExecuteAsync($"""
                UPDATE {nameof(Trade)} SET
                {nameof(Trade.Strategy)} = @{nameof(Trade.Strategy)},
                {nameof(Trade.NameOfIndicator)} = @{nameof(Trade.NameOfIndicator)},
                {nameof(Trade.NameOfCertificate)} = @{nameof(Trade.NameOfCertificate)},
                {nameof(Trade.Buy)} = @{nameof(Trade.Buy)},
                {nameof(Trade.Sell)} = @{nameof(Trade.Sell)},
                {nameof(Trade.ThinkProcess)} = @{nameof(Trade.ThinkProcess)},
                {nameof(Trade.EntryDate)} = @{nameof(Trade.EntryDate)},
                {nameof(Trade.ExitDate)} = @{nameof(Trade.ExitDate)},
                {nameof(Trade.IsClosed)} = @{nameof(Trade.IsClosed)} 
                WHERE {nameof(Trade.Id)} = @{nameof(Trade.Id)}
                """, new { item.Strategy, item.NameOfIndicator, item.NameOfCertificate, item.Buy, item.Sell, item.ThinkProcess, item.EntryDate, item.ExitDate, item.IsClosed, item.Id });
            _connection.Close();
        }

        public override async void Delete(int id)
        {
            base.Delete(id);

            _connection.Open();
            await _connection.ExecuteAsync($"""
                DELETE FROM {nameof(Trade)}
                WHERE {nameof(Trade.Id)} = @{nameof(Trade.Id)}
                """, new { Id = id });
            _connection.Close();
        }

        public override async Task<List<Trade>> GetAll()
        {
            _connection.Open();
            var trades = await _connection.QueryAsync<Trade>($"""
                SELECT * FROM {nameof(Trade)}
                """);
            _connection.Close();

            return trades.ToList();
        }
    }
}