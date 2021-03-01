using System;
using System.Linq;
using System.Threading.Tasks;
using ME.Contracts.Api.BalancesMessages;
using ME.Contracts.Api.IncomingMessages;
using MyJetWallet.MatchingEngine.Grpc;
using Newtonsoft.Json;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new MatchingEngineClientFactory(
                "http://192.168.10.80:5001",
                "http://192.168.10.80:5002",
                "http://192.168.10.80:5003",
                "http://192.168.10.80:5004");

            var orderBookClient = factory.GetOrderBookService();

            var cashClient = factory.GetCashService();

            var cashInResp = cashClient.CashInOut(new CashInOutOperation()
            {
                Id = Guid.NewGuid().ToString("N"),
                MessageId = Guid.NewGuid().ToString("N"),

                AccountId = "manual-test-003",
                WalletId = "manual-test-w-003",
                BrokerId = "jetwallet",
                
                AssetId = "BTC",
                Volume = "0.001",
                Description = "test deposit"

            });

            Console.WriteLine("CASH IN");
            Console.WriteLine(JsonConvert.SerializeObject(cashInResp, Formatting.Indented));

            var tradingClient = factory.GetTradingService();

            var limitOrder = new LimitOrder()
            {
                Id = Guid.NewGuid().ToString("N"),
                MessageId = Guid.NewGuid().ToString("N"),
                
                AccountId = "manual-test-003",
                WalletId = "manual-test-w-003",
                BrokerId = "jetwallet",

                AssetPairId = "BTCEUR",
                Price = "90000",
                Volume = "-0.001",
                Type = LimitOrder.Types.LimitOrderType.Limit,
                WalletVersion = -1
            };
            var limitOrderResp = tradingClient.LimitOrder(limitOrder);

            Console.WriteLine();
            Console.WriteLine("LIMIT ORDER");
            Console.WriteLine(JsonConvert.SerializeObject(limitOrderResp, Formatting.Indented));


            var orderBookSnapshots = orderBookClient.OrderBookSnapshots().ToList();
            foreach (var snapshot in orderBookSnapshots)
            {
                Console.WriteLine($"{snapshot.Asset} | IsBuy={snapshot.IsBuy}");
                foreach (var level in snapshot.Levels)
                {
                    Console.WriteLine($"    {level.Price} | {level.Volume} | {level.WalletId}");
                }
            }

            var cancelResp = tradingClient.CancelLimitOrder(new LimitOrderCancel()
            {
                AccountId = "manual-test-003",
                WalletId = "manual-test-w-003",
                BrokerId = "jetwallet",

                Id = Guid.NewGuid().ToString("N"),
                MessageId = Guid.NewGuid().ToString("N"),

                LimitOrderId = { limitOrder.Id }
            });

            Console.WriteLine();
            Console.WriteLine("CANCEL ORDER");
            Console.WriteLine(JsonConvert.SerializeObject(cancelResp, Formatting.Indented));

            var balanceClient = factory.GetBalancesService();
            var balances = balanceClient.GetAll("jetwallet", "manual-test-w-003");

            Console.WriteLine();
            Console.WriteLine("BALANCE");
            Console.WriteLine(JsonConvert.SerializeObject(balances, Formatting.Indented));

            
            Console.ReadLine();
        }
    }
}
