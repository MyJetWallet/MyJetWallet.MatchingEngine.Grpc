using Autofac;
using MyJetWallet.MatchingEngine.Grpc.Api;
// ReSharper disable UnusedMember.Global

namespace MyJetWallet.MatchingEngine.Grpc
{
    public static class MatchingEngineGrpcClientAutofacHelper
    {
        /// <summary>
        /// Register interfaces
        /// * ICashServiceClient
        /// * ITradingServiceClient
        /// * IBalancesServiceClient
        /// </summary>
        public static void RegisterMatchingEngineGrpcClient(this ContainerBuilder builder, string cashServiceGrpcUrl,
            string tradingServiceGrpcUrl, string balancesServiceGrpcUrl)
        {
            var factory = new MatchingEngineClientFactory(cashServiceGrpcUrl, tradingServiceGrpcUrl, balancesServiceGrpcUrl);

            builder.RegisterInstance(factory).AsSelf().SingleInstance();

            builder.RegisterInstance(factory.GetCashService()).As<ICashServiceClient>().SingleInstance();
            builder.RegisterInstance(factory.GetTradingService()).As<ITradingServiceClient>().SingleInstance();
            builder.RegisterInstance(factory.GetBalancesService()).As<IBalancesServiceClient>().SingleInstance();
        }
    }
}