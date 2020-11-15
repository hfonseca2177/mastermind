
using UnityEngine;

public interface IRule 
{
    void ApplyRule(Line line, CodeLine codeLine);

    void OnSetPeg(Line line, Color color);

    void OnCodeCreation(CodeLine codeLine, Color color);

    string GetDescription();

    string GetName();
}
