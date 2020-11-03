
using UnityEngine;

public interface IRule 
{
    void ApplyRule(Player player, Line line, Line header);

    void OnSetPeg(Line line, Color color);

    void OnCodeCreation(Line header, Color color);

    string GetDescription();

    string GetName();
}
