using UnityEngine;

namespace Rules
{
    public class ColorRepeatRule : RuleSet
    {

        public bool repeatable = false;

        public override void ApplyRule(Player player, Line line, Line header)
        {
            //nothing to do
        }

        public override string GetDescription()
        {
            return "Can the code maker repeat color?";
        }

        public override string GetName()
        {
            return "Repeatable Color";
        }

        public override void OnCodeCreation(Line header, Color color)
        {
            foreach (Spot spot in header.code)
            {
                if (spot.HasPeg() && spot.pegColor == color)
                {
                    throw new System.ArgumentException("Can't repeat color");
                }
            }
        }

        public override void OnSetPeg(Line line, Color color)
        {
            foreach (Spot spot in line.code)
            {
                if (spot.HasPeg() && spot.pegColor == color)
                {
                    throw new System.ArgumentException("Can't repeat color");
                }
            }
        }
    }
}
