using UnityEngine;

namespace Rules
{
    public class ColorRepeatRule
    {

        public bool repeatable = false;
        
        public void OnCodeCreation(CodeLine codeLine, Color color)
        {
            ValidateRepeatedColor(codeLine, color);
        }

        public void OnSetPeg(Line line, Color color)
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
