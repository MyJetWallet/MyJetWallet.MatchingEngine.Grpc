using System.Threading;
using System.Threading.Tasks;
using ME.Contracts.Api.IncomingMessages;
using MyJetWallet.MatchingEngine.Grpc.Api;
// ReSharper disable CheckNamespace

namespace ME.Contracts.Api
{
    public partial class CashService
    {
        public partial class CashServiceClient : ICashServiceClient
        {
            CashInOutOperationResponse ICashServiceClient.CashInOut(CashInOutOperation request, CancellationToken cancellationToken)
            {
                return CashInOut(request, cancellationToken: cancellationToken);
            }

            async Task<CashInOutOperationResponse> ICashServiceClient.CashInOutAsync(CashInOutOperation request, CancellationToken cancellationToken)
            {
                return await CashInOutAsync(request, cancellationToken: cancellationToken);
            }

            CashTransferOperationResponse ICashServiceClient.CashTransfer(CashTransferOperation request, CancellationToken cancellationToken)
            {
                return CashTransfer(request, cancellationToken: cancellationToken);
            }

            async Task<CashTransferOperationResponse> ICashServiceClient.CashTransferAsync(CashTransferOperation request, CancellationToken cancellationToken)
            {
                return await CashTransferAsync(request, cancellationToken: cancellationToken);
            }

            CashSwapOperationResponse ICashServiceClient.CashSwap(CashSwapOperation request, CancellationToken cancellationToken)
            {
                return CashSwap(request, cancellationToken: cancellationToken);
            }

            async Task<CashSwapOperationResponse> ICashServiceClient.CashSwapAsync(CashSwapOperation request, CancellationToken cancellationToken)
            {
                return await CashSwapAsync(request, cancellationToken: cancellationToken);
            }

            ReservedCashInOutOperationResponse ICashServiceClient.ReservedCashInOut(ReservedCashInOutOperation request, CancellationToken cancellationToken)
            {
                return ReservedCashInOut(request, cancellationToken: cancellationToken);
            }

            async Task<ReservedCashInOutOperationResponse> ICashServiceClient.ReservedCashInOutAsync(ReservedCashInOutOperation request, CancellationToken cancellationToken)
            {
                return await ReservedCashInOutAsync(request, cancellationToken: cancellationToken);
            }
        }
    }
}