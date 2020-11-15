
using System;
using UnityEngine;

public class RuleBook 
{
    private IRule[] _rules;
    

    public RuleBook(IRule[] rules)
    {
        _rules = rules;
    }

    public void ApplyRules(Line line, CodeLine codeLine)
    {
        foreach(IRule rule in this._rules){
            rule.ApplyRule(line, codeLine);
        }
    }

    public void SetCodePeg(Line line, Color color)
    {
        Array.ForEach(_rules, rule => rule.OnSetPeg(line, color));
    }

    public void OnCodeCreation(CodeLine codeLine, Color color)
    {
        Array.ForEach(_rules, rule => rule.OnCodeCreation(codeLine, color));
    }

}