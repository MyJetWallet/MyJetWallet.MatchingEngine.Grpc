using System.Globalization;
using Autofac;
using Microsoft.Extensions.DependencyInjection;
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
        ///
        /// if url is empty then registration is skipped
        /// </summary>
        public static void RegisterMatchingEngineGrpcClient(this ContainerBuilder builder, string cashServiceGrpcUrl = default,
            string tradingServiceGrpcUrl=default, string balancesServiceGrpcUrl=default, string orderBookServiceGrpcUrl = default)
        {
            var factory = new MatchingEngineClientFactory(cashServiceGrpcUrl, tradingServiceGrpcUrl, balancesServiceGrpcUrl, orderBookServiceGrpcUrl);

            builder.RegisterInstance(factory).AsSelf().SingleInstance();

            if (!string.IsNullOrEmpty(cashServiceGrpcUrl))
                builder.RegisterInstance(factory.GetCashService()).As<ICashServiceClient>().SingleInstance();

            if (!string.IsNullOrEmpty(tradingServiceGrpcUrl))
                builder.RegisterInstance(factory.GetTradingService()).As<ITradingServiceClient>().SingleInstance();

            if (!string.IsNullOrEmpty(balancesServiceGrpcUrl))
                builder.RegisterInstance(factory.GetBalancesService()).As<IBalancesServiceClient>().SingleInstance();
        }


    }
}