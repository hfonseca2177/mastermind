
using System;
using UnityEngine;

public class RuleBook 
{
    private IRule[] _rules;
    

    public RuleBook(IRule[] rules)
    {
        _rules = rules;
    }

    public void ApplyRules(Player player, Line line, Line header)
    {
        foreach(IRule rule in this._rules){
            rule.ApplyRule(player, line, header);
        }
    }

    public void SetCodePeg(Line line, Color color)
    {
        Array.ForEach(_rules, rule => rule.OnSetPeg(line, color));        
    }

    public void OnCodeCreation(Line header, Color color)
    {
        Array.ForEach(_rules, rule => rule.OnCodeCreation(header, color));
    }

}