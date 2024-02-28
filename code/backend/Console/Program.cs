using DTL;
using Microsoft.Extensions.DependencyInjection;
using SL;

Console.WriteLine("Post-Trade Console started...");
var serviceCollection=new ServiceCollection();
serviceCollection.AddSingleton<TradeConfirmationService>();
serviceCollection.AddSingleton<TradeCaptureService>();
serviceCollection.AddSingleton<ReportingComplianceService>();
serviceCollection.AddSingleton<ClearingMatchingService>();
serviceCollection.AddSingleton<NettingService>();
serviceCollection.AddSingleton<SettlementService>();
var serviceProvider=serviceCollection.BuildServiceProvider();

var tradeConfirmationService=serviceProvider.GetService<TradeConfirmationService>();
var tradeCaptureService=serviceProvider.GetService<TradeCaptureService>();
var reportingComplianceService=serviceProvider.GetService<ReportingComplianceService>();
var clearingMatchingService=serviceProvider.GetService<ClearingMatchingService>();
var nettingService=serviceProvider.GetService<NettingService>();
var settlementService=serviceProvider.GetService<SettlementService>();

tradeCaptureService.CaptureTradeDetails(new Trade{});
tradeConfirmationService.SendTradeConfirmation(null);
new ReportingComplianceService().PerformComplianceCheck(null);
new ClearingMatchingService().MatchTrades(new TradeConfirmation{}, new TradeConfirmation{});
new NettingService().NetTradesLazy(new List<Trade>());
new SettlementService().PerformSettlement(new TradeConfirmation{});
Console.WriteLine("Post-Trade Console ended.");