using UnityEngine;

namespace Rules
{
    public class MultiColorRule 
    {
        private Color[] _colorRange = { Color.blue, Color.red, Color.yellow, Color.green, 
            new Color32(155, 0, 184, 255), //purple
            new Color32(255, 167, 56, 255), //orange
            new Color32(251, 181, 230, 255),//pink
            new Color32(0,255,255, 255)}; //Aqua

        private Color[] colorSet;
        
        public void SetColorRange(int range)
        {
            this.colorSet = new Color[range];
            for (int i = 0; i < range; i++)
            {
                this.colorSet[i] = this._colorRange[i];
            }
        }

        public Color[] GetColorSet()
        {
            return colorSet;
        }

        public int GetMaxColors()
        {
            return _colorRange.Length;
        }

        public Color[] GetFullColorRange()
        {
            return _colorRange;
        }

    }
}