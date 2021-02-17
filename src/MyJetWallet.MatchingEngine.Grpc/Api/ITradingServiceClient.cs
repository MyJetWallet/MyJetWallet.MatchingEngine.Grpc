using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using ME.Contracts.Api.IncomingMessages;

namespace MyJetWallet.MatchingEngine.Grpc.Api
{
    public interface ITradingServiceClient
    {
        MarketOrderResponse MarketOrder(MarketOrder request, CancellationToken cancellationToken = default);

        Task<MarketOrderResponse> MarketOrderAsync(MarketOrder request, CancellationToken cancellationToken = default);

        LimitOrderResponse LimitOrder(LimitOrder request, CancellationToken cancellationToken = default);

        Task<LimitOrderResponse> LimitOrderAsync(LimitOrder request, CancellationToken cancellationToken = default);
        
        LimitOrderCancelResponse CancelLimitOrder(LimitOrderCancel request, CancellationToken cancellationToken = default);
        
        Task<LimitOrderCancelResponse> CancelLimitOrderAsync(LimitOrderCancel request, CancellationToken cancellationToken = default);
        
        MultiLimitOrderResponse MultiLimitOrder(MultiLimitOrder request, CancellationToken cancellationToken = default);
        
        Task<MultiLimitOrderResponse> MultiLimitOrderAsync(MultiLimitOrder request, CancellationToken cancellationToken = default);
    }
}