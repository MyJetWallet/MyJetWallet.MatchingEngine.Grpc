using System.Threading;
using System.Threading.Tasks;
using ME.Contracts.Api.IncomingMessages;

namespace MyJetWallet.MatchingEngine.Grpc.Api
{
    public interface ICashServiceClient
    {
        CashInOutOperationResponse CashInOut(CashInOutOperation request, CancellationToken cancellationToken = default);

        Task<CashInOutOperationResponse> CashInOutAsync(CashInOutOperation request, CancellationToken cancellationToken = default);

        CashTransferOperationResponse CashTransfer(CashTransferOperation request, CancellationToken cancellationToken = default);
        
        Task<CashTransferOperationResponse> CashTransferAsync(CashTransferOperation request, CancellationToken cancellationToken = default);
        
        ReservedCashInOutOperationResponse ReservedCashInOut(ReservedCashInOutOperation request, CancellationToken cancellationToken = default);

        Task<ReservedCashInOutOperationResponse> ReservedCashInOutAsync(ReservedCashInOutOperation request, CancellationToken cancellationToken = default);
    }
}