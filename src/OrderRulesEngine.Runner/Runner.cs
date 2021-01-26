using OrderRulesEngine.Models;
using OrderRulesEngine.Rules;
using System;
using System.Collections.Generic;
using System.Linq;

public class Runner
{
    private readonly IEnumerable<IOrderRule> _rules;
        
    public Runner(IEnumerable<IOrderRule> rules)
    {
        _rules = rules;
    }

    public void Run()
    {
        Console.WriteLine($"Rules in engine: {_rules.Count()}");
        Order order = new(new PhysicalProduct(PhysicalProductType.Book), new(""));

        var timesOrderProcessed = 0;
        foreach (var rule in _rules.Where(r => r.ShouldProcess(order)))
            if (rule.Process(order))
                timesOrderProcessed++;

        if (timesOrderProcessed > 0)
            Console.WriteLine($"Order has been processed by {timesOrderProcessed} rules now."
                + "\nEither run in debug, or check unit tests to see changes.");
    }
}
