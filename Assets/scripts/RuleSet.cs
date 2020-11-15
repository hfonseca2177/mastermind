

using UnityEngine;

public abstract class RuleSet : IRule
{
    public abstract void ApplyRule(Line line, CodeLine codeLine);
    public abstract string GetDescription();
    public abstract string GetName();
    public abstract void OnCodeCreation(CodeLine codeLine, Color color); 
    public abstract void OnSetPeg(Line line, Color color);
}
