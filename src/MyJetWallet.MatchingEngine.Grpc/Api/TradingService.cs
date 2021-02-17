using ME.Contracts.Api.IncomingMessages;
using MyJetWallet.MatchingEngine.Grpc.Api;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable CheckNamespace

namespace ME.Contracts.Api
{
    public static partial class TradingService
    {
        public partial class TradingServiceClient : ITradingServiceClient
        {
            LimitOrderCancelResponse ITradingServiceClient.CancelLimitOrder(LimitOrderCancel request, CancellationToken cancellationToken)
            {
                return CancelLimitOrder(request, cancellationToken: cancellationToken);
            }

            async Task<LimitOrderCancelResponse> ITradingServiceClient.CancelLimitOrderAsync(LimitOrderCancel request, CancellationToken cancellationToken)
            {
                return await CancelLimitOrderAsync(request, cancellationToken: cancellationToken);
            }

            LimitOrderResponse ITradingServiceClient.LimitOrder(LimitOrder request, CancellationToken cancellationToken)
            {
                return LimitOrder(request, cancellationToken: cancellationToken);
            }

            async Task<LimitOrderResponse> ITradingServiceClient.LimitOrderAsync(LimitOrder request, CancellationToken cancellationToken)
            {
                return await LimitOrderAsync(request, cancellationToken: cancellationToken);
            }

            MarketOrderResponse ITradingServiceClient.MarketOrder(MarketOrder request, CancellationToken cancellationToken)
            {
                return MarketOrder(request, cancellationToken: cancellationToken);
            }

            async Task<MarketOrderResponse> ITradingServiceClient.MarketOrderAsync(MarketOrder request, CancellationToken cancellationToken)
            {
                return await MarketOrderAsync(request, cancellationToken: cancellationToken);
            }

            MultiLimitOrderResponse ITradingServiceClient.MultiLimitOrder(MultiLimitOrder request, CancellationToken cancellationToken)
            {
                return MultiLimitOrder(request, cancellationToken: cancellationToken);
            }

            async Task<MultiLimitOrderResponse> ITradingServiceClient.MultiLimitOrderAsync(MultiLimitOrder request, CancellationToken cancellationToken)
            {
                return await MultiLimitOrderAsync(request, cancellationToken: cancellationToken);
            }
        }
    }
}