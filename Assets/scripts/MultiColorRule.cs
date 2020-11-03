using UnityEngine;

namespace Rules
{
    public class MultiColorRule : RuleSet
    {
        private Color[] _colorRange = { Color.blue, Color.red, Color.yellow, Color.green, new Color32(155, 0, 184, 255),
        new Color32(255, 167, 56, 255), new Color32(251, 181, 230, 255), new Color32(180,227,255, 255)};

        public Color[] colorSet;

        public int[] colorOptions = { 4, 6, 8 };

        public override void ApplyRule(Player player, Line line, Line header)
        {
            //nothing to do
        }

        public override string GetDescription()
        {
            return "How many colors can players choose from?";
        }

        public override string GetName()
        {
            return "Color Range Option";
        }

        public override void OnCodeCreation(Line header, Color color)
        {
            //nothing to do
        }

        public override void OnSetPeg(Line line, Color color)
        {
            //nothing to do
        }

        public void SetColorRange(int range)
        {
            this.colorSet = new Color[range];
            for (int i = 0; i < range; i++)
            {
                this.colorSet[i] = this._colorRange[i];
            }
        }

        public Color[] GetColorRange()
        {
            return colorSet;
        }

    }
}