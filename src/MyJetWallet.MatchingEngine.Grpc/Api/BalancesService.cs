using ME.Contracts.Api.BalancesMessages;
using MyJetWallet.MatchingEngine.Grpc.Api;
using System.Threading;
using System.Threading.Tasks;
// ReSharper disable CheckNamespace

namespace ME.Contracts.Api
{
    public static partial class BalancesService
    {
        public partial class BalancesServiceClient : IBalancesServiceClient
        {
            BalancesGetAllResponse IBalancesServiceClient.GetAll(string brokerId, string walletId, CancellationToken cancellationToken)
            {
                return GetAll(new BalancesGetAllRequest()
                {
                    BrokerId = brokerId, WalletId = walletId
                }, cancellationToken: cancellationToken);
            }

            async Task<BalancesGetAllResponse> IBalancesServiceClient.GetAllAsync(string brokerId, string walletId, CancellationToken cancellationToken)
            {
                return await GetAllAsync(new BalancesGetAllRequest(){BrokerId = brokerId, WalletId = walletId}, cancellationToken: cancellationToken);
            }

            BalancesGetByAssetIdResponse IBalancesServiceClient.GetByAssetId(string brokerId, string walletId, string assetId, CancellationToken cancellationToken)
            {
                return GetByAssetId(new BalancesGetByAssetIdRequest(){BrokerId = brokerId, WalletId = walletId, AssetId = assetId}, cancellationToken: cancellationToken);
            }

            async Task<BalancesGetByAssetIdResponse> IBalancesServiceClient.GetByAssetIdAsync(string brokerId, string walletId, string assetId, CancellationToken cancellationToken)
            {
                return await GetByAssetIdAsync(new BalancesGetByAssetIdRequest() { BrokerId = brokerId, WalletId = walletId, AssetId = assetId }, cancellationToken: cancellationToken);
            }
        }
    }
}