

using UnityEngine;

public abstract class RuleSet : IRule
{
    public abstract void ApplyRule(Player player, Line line, Line header);
    public abstract string GetDescription();
    public abstract string GetName();
    public abstract void OnCodeCreation(Line header, Color color);
    public void OnRightColorClue(Player player)
    {
        player.currentScore += 1;
    }
    public void OnRightPositionClue(Player player)
    {
        player.currentScore += 3;
    }

    public abstract void OnSetPeg(Line line, Color color);
}
