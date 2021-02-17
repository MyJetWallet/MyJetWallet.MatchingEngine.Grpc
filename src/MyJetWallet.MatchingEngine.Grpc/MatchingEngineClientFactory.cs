using System;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Grpc.Net.Client;
using ME.Contracts.Api;
using MyJetWallet.MatchingEngine.Grpc.Api;
using MyJetWallet.Sdk.GrpcMetrics;
// ReSharper disable UnusedMember.Global

namespace MyJetWallet.MatchingEngine.Grpc
{
    public class MatchingEngineClientFactory
    {
        private readonly CallInvoker _invokerCashService;
        private readonly CallInvoker _invokerTradingService;
        private readonly CallInvoker _invokerBalancesService;

        public MatchingEngineClientFactory(string cashServiceGrpcUrl, string tradingServiceGrpcUrl, string balancesServiceGrpcUrl)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            var channelCashService = GrpcChannel.ForAddress(cashServiceGrpcUrl);
            _invokerCashService = channelCashService.Intercept(new PrometheusMetricsInterceptor());

            var channelTradingService = GrpcChannel.ForAddress(tradingServiceGrpcUrl);
            _invokerTradingService = channelTradingService.Intercept(new PrometheusMetricsInterceptor());

            var channelBalancesService = GrpcChannel.ForAddress(balancesServiceGrpcUrl);
            _invokerBalancesService = channelBalancesService.Intercept(new PrometheusMetricsInterceptor());
        }

        public ICashServiceClient GetCashService()
        {
            return new CashService.CashServiceClient(_invokerCashService);
        }

        public ITradingServiceClient GetTradingService()
        {
            return new TradingService.TradingServiceClient(_invokerTradingService);
        }

        public IBalancesServiceClient GetBalancesService()
        {
            return new BalancesService.BalancesServiceClient(_invokerBalancesService);
        }
    }
}
