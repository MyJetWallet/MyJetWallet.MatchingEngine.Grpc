![Nuget version](https://img.shields.io/nuget/v/MyJetWallet.MatchingEngine.Grpc?label=MyJetWallet.MatchingEngine.Grpc&style=social)

# Using

Register

```csharp
	public class Startup()
	{
		public void ConfigureContainer(ContainerBuilder builder)
		{
			builder.RegisterMatchingEngineGrpcClient(cashServiceGrpcUrl, tradingServiceGrpcUrl, balancesServiceGrpcUrl);
		}
	}
```

Interfaces:

* `ICashServiceClient`
* `ITradingServiceClient`
* `IBalancesServiceClient`
