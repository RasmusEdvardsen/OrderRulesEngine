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
        Console.WriteLine(_rules.Count());
    }
}
