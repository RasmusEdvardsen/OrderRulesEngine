using Microsoft.Extensions.DependencyInjection;
using OrderRulesEngine.DataAccess.Membership;
using OrderRulesEngine.Rules;
using System;

Console.WriteLine("Testing OrderRulesEngine...");
ServiceCollection serviceCollection = new();

serviceCollection.AddScoped<IMembershipRepository, MembershipRepository>();
serviceCollection.AddScoped<IOrderRule, AgentCommission>();
serviceCollection.AddScoped<IOrderRule, LearningToSki>();
serviceCollection.AddScoped<IOrderRule, MembershipEmail>();
serviceCollection.AddScoped<IOrderRule, MembershipNew>();
serviceCollection.AddScoped<IOrderRule, MembershipUpgrade>();
serviceCollection.AddScoped<IOrderRule, PackingSlipRoyalties>();
serviceCollection.AddScoped<IOrderRule, PackingSlipShipping>();
serviceCollection.AddSingleton<Runner>();

serviceCollection
    .BuildServiceProvider()
    .GetRequiredService<Runner>()
    .Run();

Console.ReadLine();