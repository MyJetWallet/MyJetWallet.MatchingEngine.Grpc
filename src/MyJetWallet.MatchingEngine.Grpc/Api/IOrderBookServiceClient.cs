using System.Collections.Generic;
using System.Threading;
using ME.Contracts.OrderBooksMessages;

namespace MyJetWallet.MatchingEngine.Grpc.Api
{
    public interface IOrderBookServiceClient
    {
        IAsyncEnumerable<OrderBookSnapshot> OrderBookSnapshotsAsync(CancellationToken cancellationToken = default);
        List<OrderBookSnapshot> OrderBookSnapshots();
    }
}