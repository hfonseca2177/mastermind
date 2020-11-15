using UnityEngine;

namespace Rules
{
    public class ColorRepeatRule : RuleSet
    {

        public bool repeatable = false;

        public override void ApplyRule(Line line, CodeLine codeLine)
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

        public override void OnCodeCreation(CodeLine codeLine, Color color)
        {
            ValidateRepeatedColor(codeLine, color);
        }

        public override void OnSetPeg(Line line, Color color)
        {
            ValidateRepeatedColor(line, color);
        }

        private void ValidateRepeatedColor(BaseLine line, Color color)
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
