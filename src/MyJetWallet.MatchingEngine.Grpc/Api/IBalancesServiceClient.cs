using System.Threading;
using System.Threading.Tasks;
using ME.Contracts.Api.BalancesMessages;
// ReSharper disable UnusedMember.Global

namespace MyJetWallet.MatchingEngine.Grpc.Api
{
    public interface IBalancesServiceClient
    {
        BalancesGetAllResponse GetAll(string brokerId, string walletId, CancellationToken cancellationToken = default);

        Task<BalancesGetAllResponse> GetAllAsync(string brokerId, string walletId, CancellationToken cancellationToken = default);
        
        BalancesGetByAssetIdResponse GetByAssetId(string brokerId, string walletId, string assetId, CancellationToken cancellationToken = default);
        
        Task<BalancesGetByAssetIdResponse> GetByAssetIdAsync(string brokerId, string walletId, string assetId, CancellationToken cancellationToken = default);
    }
}