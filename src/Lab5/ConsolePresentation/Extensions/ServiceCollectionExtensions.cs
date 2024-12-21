using ConsolePresentation.Scenarios.AdminLogin;
using ConsolePresentation.Scenarios.Amount;
using ConsolePresentation.Scenarios.AmountOf;
using ConsolePresentation.Scenarios.CreateAdmin;
using ConsolePresentation.Scenarios.CreateUser;
using ConsolePresentation.Scenarios.HistoryOf;
using ConsolePresentation.Scenarios.Logout;
using ConsolePresentation.Scenarios.Replenishment;
using ConsolePresentation.Scenarios.ReplenishmentTo;
using ConsolePresentation.Scenarios.Transactions;
using ConsolePresentation.Scenarios.UserLogin;
using ConsolePresentation.Scenarios.Withdrawal;
using ConsolePresentation.Scenarios.WithdrawalFrom;
using Microsoft.Extensions.DependencyInjection;

namespace ConsolePresentation.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, AdminLoginScenarioProvider>();

        collection.AddScoped<IScenarioProvider, AmountScenarioProvider>();

        collection.AddScoped<IScenarioProvider, AmountOfScenarioProvider>();

        collection.AddScoped<IScenarioProvider,  CreateAdminScenarioProvider>();

        collection.AddScoped<IScenarioProvider, CreateUserScenarioProvider>();

        collection.AddScoped<IScenarioProvider, HistoryOfScenarioProvider>();

        collection.AddScoped<IScenarioProvider, LogoutScenarioProvider>();

        collection.AddScoped<IScenarioProvider, ReplenishmentScenarioProvider>();

        collection.AddScoped<IScenarioProvider, ReplenishmentToScenarioProvider>();

        collection.AddScoped<IScenarioProvider, TransactionsScenarioProvider>();

        collection.AddScoped<IScenarioProvider, UserLoginScenarioProvider>();

        collection.AddScoped<IScenarioProvider, WithdrawalScenarioProvider>();

        collection.AddScoped<IScenarioProvider, WithdrawalFromScenarioProvider>();
        return collection;
    }
}