using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class BaseLine 
{
    public static int maxCols = 4;
    public int index = 0;
    public int currentCodeIndex = -1;
    public Spot[] code;

    public Spot GetNextCodeSpot()
    {
        if (currentCodeIndex < maxCols)
        {
            currentCodeIndex++;
        }
        return this.code[currentCodeIndex];
    }

    public bool IsSameCode(BaseLine line)
    {
        bool sameColor = false;

        for (int i = 0; i < maxCols; i++)
        {
            sameColor = this.code[i].pegColor.Equals(line.code[i].pegColor);
            if (!sameColor)
            {
                break;
            }
        }
        return sameColor;
    }

    public bool HasColor(Color color)
    {
        bool hasIt = false;
        foreach (Spot spot in code)
        {
            hasIt = spot.pegColor.Equals(color);
            if (hasIt)
            {
                break;
            }
        }
        return hasIt;
    }

    public bool MatchColorPosition(Color color, int position)
    {
        return code[position].pegColor.Equals(color);
    }

    protected void CleanCodeSlots()
    {
        currentCodeIndex = -1;
        Array.ForEach(code, c => c.Clear());
    }
}
