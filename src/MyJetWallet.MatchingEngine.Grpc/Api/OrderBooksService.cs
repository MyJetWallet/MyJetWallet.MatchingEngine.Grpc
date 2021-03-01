using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using ME.Contracts.OrderBooksMessages;
using MyJetWallet.MatchingEngine.Grpc.Api;

// ReSharper disable once CheckNamespace
namespace ME.Contracts.Api
{
    public static partial class OrderBooksService
    {
        public partial class OrderBooksServiceClient : IOrderBookServiceClient
        {
            List<OrderBookSnapshot> IOrderBookServiceClient.OrderBookSnapshots()
            {
                var data = ((IOrderBookServiceClient)this).OrderBookSnapshotsAsync();

                var list = data.ToListAsync().GetAwaiter().GetResult();

                return list;
            }

            async IAsyncEnumerable<OrderBookSnapshot> IOrderBookServiceClient.OrderBookSnapshotsAsync([EnumeratorCancellation] CancellationToken cancellationToken)
            {
                using var resp = OrderBookSnapshots(new Empty(), cancellationToken: cancellationToken);

                await foreach (var item in resp.ResponseStream.ReadAllAsync(cancellationToken: cancellationToken))
                {
                    yield return item;
                }
            }
        }

        
    }
}