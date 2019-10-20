﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.RateLimiter;
using Kraken.Net.Converters;
using Kraken.Net.Objects;

namespace Kraken.Net.Interfaces
{
    /// <summary>
    /// Interface for Kraken client
    /// </summary>
    public interface IKrakenClient: IRestClient
    {
        /// <summary>
        /// Set the API key and secret
        /// </summary>
        /// <param name="apiKey">The api key</param>
        /// <param name="apiSecret">The api secret</param>
        void SetApiCredentials(string apiKey, string apiSecret);

        /// <summary>
        /// Get the server time
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Server time</returns>
        CallResult<DateTime> GetServerTime(CancellationToken ct = default);

        /// <summary>
        /// Get the server time
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Server time</returns>
        Task<CallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default);

        /// <summary>
        /// Get a list of assets and info about them
        /// </summary>
        /// <param name="assets">Filter list for specific assets</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Dictionary of asset info</returns>
        WebCallResult<Dictionary<string, KrakenAssetInfo>> GetAssets(CancellationToken ct = default, params string[] assets);

        /// <summary>
        /// Get a list of assets and info about them
        /// </summary>
        /// <param name="assets">Filter list for specific assets</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Dictionary of asset info</returns>
        Task<WebCallResult<Dictionary<string, KrakenAssetInfo>>> GetAssetsAsync(CancellationToken ct = default, params string[] assets);

        /// <summary>
        /// Get a list of markets and info about them
        /// </summary>
        /// <param name="markets">Filter list for specific markets</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Dictionary of market info</returns>
        WebCallResult<Dictionary<string, KrakenMarket>> GetMarkets(CancellationToken ct = default, params string[] markets);

        /// <summary>
        /// Get a list of markets and info about them
        /// </summary>
        /// <param name="markets">Filter list for specific markets</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Dictionary of market info</returns>
        Task<WebCallResult<Dictionary<string, KrakenMarket>>> GetMarketsAsync(CancellationToken ct = default, params string[] markets);

        /// <summary>
        /// Get tickers for markets
        /// </summary>
        /// <param name="markets">Markets to get tickers for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Dictionary with ticker info</returns>
        WebCallResult<Dictionary<string, KrakenRestTick>> GetTickers(CancellationToken ct = default, params string[] markets);

        /// <summary>
        /// Get tickers for markets
        /// </summary>
        /// <param name="markets">Markets to get tickers for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Dictionary with ticker info</returns>
        Task<WebCallResult<Dictionary<string, KrakenRestTick>>> GetTickersAsync(CancellationToken ct = default, params string[] markets);

        /// <summary>
        /// Gets kline data for a market
        /// </summary>
        /// <param name="market">The market to get data for</param>
        /// <param name="interval">The interval of the klines</param>
        /// <param name="since">Return klines since a specific time</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Kline data</returns>
        WebCallResult<KrakenKlinesResult> GetKlines(string market, KlineInterval interval, DateTime? since = null, CancellationToken ct = default);

        /// <summary>
        /// Gets kline data for a market
        /// </summary>
        /// <param name="market">The market to get data for</param>
        /// <param name="interval">The interval of the klines</param>
        /// <param name="since">Return klines since a specific time</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Kline data</returns>
        Task<WebCallResult<KrakenKlinesResult>> GetKlinesAsync(string market, KlineInterval interval, DateTime? since = null, CancellationToken ct = default);

        /// <summary>
        /// Get the order book for a market
        /// </summary>
        /// <param name="market">Market to get the book for</param>
        /// <param name="limit">Limit to book to the best x bids/asks</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Order book for the market</returns>
        WebCallResult<KrakenOrderBook> GetOrderBook(string market, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get the order book for a market
        /// </summary>
        /// <param name="market">Market to get the book for</param>
        /// <param name="limit">Limit to book to the best x bids/asks</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Order book for the market</returns>
        Task<WebCallResult<KrakenOrderBook>> GetOrderBookAsync(string market, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get a list of recent trades for a market
        /// </summary>
        /// <param name="market">Market to get trades for</param>
        /// <param name="since">Return trades since a specific time</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Recent trades</returns>
        WebCallResult<KrakenTradesResult> GetRecentTrades(string market, DateTime? since = null, CancellationToken ct = default);

        /// <summary>
        /// Get a list of recent trades for a market
        /// </summary>
        /// <param name="market">Market to get trades for</param>
        /// <param name="since">Return trades since a specific time</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Recent trades</returns>
        Task<WebCallResult<KrakenTradesResult>> GetRecentTradesAsync(string market, DateTime? since = null, CancellationToken ct = default);

        /// <summary>
        /// Get spread data for a market
        /// </summary>
        /// <param name="market">Market to get spread data for</param>
        /// <param name="since">Return spread data since a specific time</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Spread data</returns>
        WebCallResult<KrakenSpreadsResult> GetRecentSpread(string market, DateTime? since = null, CancellationToken ct = default);

        /// <summary>
        /// Get spread data for a market
        /// </summary>
        /// <param name="market">Market to get spread data for</param>
        /// <param name="since">Return spread data since a specific time</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Spread data</returns>
        Task<WebCallResult<KrakenSpreadsResult>> GetRecentSpreadAsync(string market, DateTime? since = null, CancellationToken ct = default);

        /// <summary>
        /// Get balances
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Dictionary with balances for assets</returns>
        WebCallResult<Dictionary<string, decimal>> GetAccountBalance(CancellationToken ct = default);

        /// <summary>
        /// Get balances
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Dictionary with balances for assets</returns>
        Task<WebCallResult<Dictionary<string, decimal>>> GetAccountBalanceAsync(CancellationToken ct = default);

        /// <summary>
        /// Get trade balance
        /// </summary>
        /// <param name="baseAsset">Base asset to get trade balance for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Trade balance data</returns>
        WebCallResult<KrakenTradeBalance> GetTradeBalance(string? baseAsset = null, CancellationToken ct = default);

        /// <summary>
        /// Get trade balance
        /// </summary>
        /// <param name="baseAsset">Base asset to get trade balance for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Trade balance data</returns>
        Task<WebCallResult<KrakenTradeBalance>> GetTradeBalanceAsync(string? baseAsset = null, CancellationToken ct = default);

        /// <summary>
        /// Get a list of open orders
        /// </summary>
        /// <param name="clientOrderId">Filter by client order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of open orders</returns>
        WebCallResult<OpenOrdersPage> GetOpenOrders(string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// Get a list of open orders
        /// </summary>
        /// <param name="clientOrderId">Filter by client order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of open orders</returns>
        Task<WebCallResult<OpenOrdersPage>> GetOpenOrdersAsync(string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// Get a list of closed orders
        /// </summary>
        /// <param name="clientOrderId">Filter by client order id</param>
        /// <param name="startTime">Return data after this time</param>
        /// <param name="endTime">Return data before this time</param>
        /// <param name="resultOffset">Offset the results by</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Closed orders page</returns>
        WebCallResult<KrakenClosedOrdersPage> GetClosedOrders(string? clientOrderId = null, DateTime? startTime = null, DateTime? endTime = null, int? resultOffset = null, CancellationToken ct = default);

        /// <summary>
        /// Get a list of closed orders
        /// </summary>
        /// <param name="clientOrderId">Filter by client order id</param>
        /// <param name="startTime">Return data after this time</param>
        /// <param name="endTime">Return data before this time</param>
        /// <param name="resultOffset">Offset the results by</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Closed orders page</returns>
        Task<WebCallResult<KrakenClosedOrdersPage>> GetClosedOrdersAsync(string? clientOrderId = null, DateTime? startTime = null, DateTime? endTime = null, int? resultOffset = null, CancellationToken ct = default);

        /// <summary>
        /// Get info on specific orders
        /// </summary>
        /// <param name="clientOrderId">Get orders by clientOrderId</param>
        /// <param name="orderIds">Get orders by their order ids</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Dictionary with order info</returns>
        WebCallResult<Dictionary<string, KrakenOrder>> GetOrders(string? clientOrderId = null, CancellationToken ct = default, params string[] orderIds);

        /// <summary>
        /// Get info on specific orders
        /// </summary>
        /// <param name="clientOrderId">Get orders by clientOrderId</param>
        /// <param name="orderIds">Get orders by their order ids</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Dictionary with order info</returns>
        Task<WebCallResult<Dictionary<string, KrakenOrder>>> GetOrdersAsync(string? clientOrderId = null, CancellationToken ct = default, params string[] orderIds);

        /// <summary>
        /// Get trade history
        /// </summary>
        /// <param name="startTime">Return data after this time</param>
        /// <param name="endTime">Return data before this time</param>
        /// <param name="resultOffset">Offset the results by</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Trade history page</returns>
        WebCallResult<KrakenUserTradesPage> GetTradeHistory(DateTime? startTime = null, DateTime? endTime = null, int? resultOffset = null, CancellationToken ct = default);

        /// <summary>
        /// Get trade history
        /// </summary>
        /// <param name="startTime">Return data after this time</param>
        /// <param name="endTime">Return data before this time</param>
        /// <param name="resultOffset">Offset the results by</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Trade history page</returns>
        Task<WebCallResult<KrakenUserTradesPage>> GetTradeHistoryAsync(DateTime? startTime = null, DateTime? endTime = null, int? resultOffset = null, CancellationToken ct = default);

        /// <summary>
        /// Get info on specific trades
        /// </summary>
        /// <param name="tradeIds">The trades to get info on</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Dictionary with trade info</returns>
        WebCallResult<Dictionary<string, KrakenUserTrade>> GetTrades(CancellationToken ct = default, params string[] tradeIds);

        /// <summary>
        /// Get info on specific trades
        /// </summary>
        /// <param name="tradeIds">The trades to get info on</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Dictionary with trade info</returns>
        Task<WebCallResult<Dictionary<string, KrakenUserTrade>>> GetTradesAsync(CancellationToken ct = default, params string[] tradeIds);

        /// <summary>
        /// Get a list of open positions
        /// </summary>
        /// <param name="transactionIds">Filter by transaction ids</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Dictionary with position info</returns>
        WebCallResult<Dictionary<string, KrakenPosition>> GetOpenPositions(CancellationToken ct = default, params string[] transactionIds);

        /// <summary>
        /// Get a list of open positions
        /// </summary>
        /// <param name="transactionIds">Filter by transaction ids</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Dictionary with position info</returns>
        Task<WebCallResult<Dictionary<string, KrakenPosition>>> GetOpenPositionsAsync(CancellationToken ct = default, params string[] transactionIds);

        /// <summary>
        /// Get ledger entries info
        /// </summary>
        /// <param name="assets">Filter list by asset names</param>
        /// <param name="entryTypes">Filter list by entry types</param>
        /// <param name="startTime">Return data after this time</param>
        /// <param name="endTime">Return data before this time</param>
        /// <param name="resultOffset">Offset the results by</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Ledger entries page</returns>
        WebCallResult<KrakenLedgerPage> GetLedgerInfo(string[]? assets = null, LedgerEntryType[]? entryTypes = null, DateTime? startTime = null, DateTime? endTime = null, int? resultOffset = null, CancellationToken ct = default);

        /// <summary>
        /// Get ledger entries info
        /// </summary>
        /// <param name="assets">Filter list by asset names</param>
        /// <param name="entryTypes">Filter list by entry types</param>
        /// <param name="startTime">Return data after this time</param>
        /// <param name="endTime">Return data before this time</param>
        /// <param name="resultOffset">Offset the results by</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Ledger entries page</returns>
        Task<WebCallResult<KrakenLedgerPage>> GetLedgerInfoAsync(string[]? assets = null, LedgerEntryType[]? entryTypes = null, DateTime? startTime = null, DateTime? endTime = null, int? resultOffset = null, CancellationToken ct = default);

        /// <summary>
        /// Get info on specific ledger entries
        /// </summary>
        /// <param name="ledgerIds">The ids to get info for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Dictionary with ledger entry info</returns>
        WebCallResult<Dictionary<string, KrakenLedgerEntry>> GetLedgersEntry(CancellationToken ct = default, params string[] ledgerIds);

        /// <summary>
        /// Get info on specific ledger entries
        /// </summary>
        /// <param name="ledgerIds">The ids to get info for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Dictionary with ledger entry info</returns>
        Task<WebCallResult<Dictionary<string, KrakenLedgerEntry>>> GetLedgersEntryAsync(CancellationToken ct = default, params string[] ledgerIds);

        /// <summary>
        /// Get trade volume
        /// </summary>
        /// <param name="markets">Markets to get data for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Trade fee info</returns>
        WebCallResult<KrakenTradeVolume> GetTradeVolume(CancellationToken ct = default, params string[] markets);

        /// <summary>
        /// Get trade volume
        /// </summary>
        /// <param name="markets">Markets to get data for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Trade fee info</returns>
        Task<WebCallResult<KrakenTradeVolume>> GetTradeVolumeAsync(CancellationToken ct = default, params string[] markets);

        /// <summary>
        /// Get deposit methods
        /// </summary>
        /// <param name="asset">Asset to get methods for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Array with methods for deposit</returns>
        WebCallResult<IEnumerable<KrakenDepositMethod>> GetDepositMethods(string asset, CancellationToken ct = default);

        /// <summary>
        /// Get deposit methods
        /// </summary>
        /// <param name="asset">Asset to get methods for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Array with methods for deposit</returns>
        Task<WebCallResult<IEnumerable<KrakenDepositMethod>>> GetDepositMethodsAsync(string asset, CancellationToken ct = default);

        /// <summary>
        /// Get deposit addresses for an asset
        /// </summary>
        /// <param name="asset">The asset to get the deposit address for</param>
        /// <param name="depositMethod">The method of deposit</param>
        /// <param name="generateNew">Whether to generate a new address</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        WebCallResult<IEnumerable<KrakenDepositAddress>> GetDepositAddresses(string asset, string depositMethod, bool generateNew = false, CancellationToken ct = default);

        /// <summary>
        /// Get deposit addresses for an asset
        /// </summary>
        /// <param name="asset">The asset to get the deposit address for</param>
        /// <param name="depositMethod">The method of deposit</param>
        /// <param name="generateNew">Whether to generate a new address</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<KrakenDepositAddress>>> GetDepositAddressesAsync(string asset, string depositMethod, bool generateNew = false, CancellationToken ct = default);

        /// <summary>
        /// Get status deposits for an asset
        /// </summary>
        /// <param name="asset">Asset to get deposit info for</param>
        /// <param name="depositMethod">The deposit method</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Deposit status list</returns>
        WebCallResult<IEnumerable<KrakenDepositStatus>> GetDepositStatus(string asset, string depositMethod, CancellationToken ct = default);

        /// <summary>
        /// Get status deposits for an asset
        /// </summary>
        /// <param name="asset">Asset to get deposit info for</param>
        /// <param name="depositMethod">The deposit method</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Deposit status list</returns>
        Task<WebCallResult<IEnumerable<KrakenDepositStatus>>> GetDepositStatusAsync(string asset, string depositMethod, CancellationToken ct = default);

        /// <summary>
        /// Place a new order
        /// </summary>
        /// <param name="market">The market the order is on</param>
        /// <param name="side">The side of the order</param>
        /// <param name="type">The type of the order</param>
        /// <param name="quantity">The quantity of the order</param>
        /// <param name="clientOrderId">A client id to reference the order by</param>
        /// <param name="price">Price of the order:
        /// Limit=limit price,
        /// StopLoss=stop loss price,
        /// TakeProfit=take profit price,
        /// StopLossProfit=stop loss price,
        /// StopLossProfitLimit=stop loss price,
        /// StopLossLimit=stop loss trigger price,
        /// TakeProfitLimit=take profit trigger price,
        /// TrailingStop=trailing stop offset,
        /// TrailingStopLimit=trailing stop offset,
        /// StopLossAndLimit=stop loss price,
        /// </param>
        /// <param name="secondaryPrice">Secondary price of an order:
        /// StopLossProfit/StopLossProfitLimit=take profit price,
        /// StopLossLimit/TakeProfitLimit=triggered limit price,
        /// TrailingStopLimit=triggered limit offset,
        /// StopLossAndLimit=limit price</param>
        /// <param name="leverage">Desired leverage</param>
        /// <param name="startTime">Scheduled start time</param>
        /// <param name="expireTime">Expiration time</param>
        /// <param name="validateOnly">Only validate inputs, don't actually place the order</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Placed order info</returns>
        WebCallResult<KrakenPlacedOrder> PlaceOrder(
            string market, 
            OrderSide side, 
            OrderType type, 
            decimal quantity, 
            uint? clientOrderId = null,
            decimal? price = null, 
            decimal? secondaryPrice = null,
            decimal? leverage = null,
            DateTime? startTime = null,
            DateTime? expireTime = null,
            bool? validateOnly = null, 
            CancellationToken ct = default);

        /// <summary>
        /// Place a new order
        /// </summary>
        /// <param name="market">The market the order is on</param>
        /// <param name="side">The side of the order</param>
        /// <param name="type">The type of the order</param>
        /// <param name="quantity">The quantity of the order</param>
        /// <param name="clientOrderId">A client id to reference the order by</param>
        /// <param name="price">Price of the order:
        /// Limit=limit price,
        /// StopLoss=stop loss price,
        /// TakeProfit=take profit price,
        /// StopLossProfit=stop loss price,
        /// StopLossProfitLimit=stop loss price,
        /// StopLossLimit=stop loss trigger price,
        /// TakeProfitLimit=take profit trigger price,
        /// TrailingStop=trailing stop offset,
        /// TrailingStopLimit=trailing stop offset,
        /// StopLossAndLimit=stop loss price,
        /// </param>
        /// <param name="secondaryPrice">Secondary price of an order:
        /// StopLossProfit/StopLossProfitLimit=take profit price,
        /// StopLossLimit/TakeProfitLimit=triggered limit price,
        /// TrailingStopLimit=triggered limit offset,
        /// StopLossAndLimit=limit price</param>
        /// <param name="leverage">Desired leverage</param>
        /// <param name="startTime">Scheduled start time</param>
        /// <param name="expireTime">Expiration time</param>
        /// <param name="validateOnly">Only validate inputs, don't actually place the order</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Placed order info</returns>
        Task<WebCallResult<KrakenPlacedOrder>> PlaceOrderAsync(
            string market,
            OrderSide side,
            OrderType type,
            decimal quantity,
            uint? clientOrderId = null,
            decimal? price = null,
            decimal? secondaryPrice = null,
            decimal? leverage = null,
            DateTime? startTime = null,
            DateTime? expireTime = null,
            bool? validateOnly = null,
            CancellationToken ct = default);

        /// <summary>
        /// Cancel an order
        /// </summary>
        /// <param name="orderId">The id of the order to cancel</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Cancel result</returns>
        WebCallResult<KrakenCancelResult> CancelOrder(string orderId, CancellationToken ct = default);

        /// <summary>
        /// Cancel an order
        /// </summary>
        /// <param name="orderId">The id of the order to cancel</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Cancel result</returns>
        Task<WebCallResult<KrakenCancelResult>> CancelOrderAsync(string orderId, CancellationToken ct = default);
    }
}