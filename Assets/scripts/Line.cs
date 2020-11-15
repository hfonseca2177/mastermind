using System;
using System.Collections.Generic;
using UnityEngine;

public class Line : BaseLine
{
    
    public int currentClueIndex = -1;
    public Spot[] clue;

    public static Line InitLine(int index)
    {
        Line line = new Line
        {
            code = new Spot[maxCols],
            clue = new Spot[maxCols],
            index = index
        };

        for (int i = 0; i < maxCols; i++)
        {
            line.code[i] = Spot.CreateCodeSpot(index, i);
            line.clue[i] = Spot.CreateClueSpot(index, i);
        }
        return line;
    }
   
    public Spot GetNextClueSpot()
    {
        if (currentClueIndex < maxCols)
        {
            currentClueIndex++;
        }
        return this.clue[currentClueIndex];
    }
   

    public void CleanCodeLines()
    {
        CleanCodeSlots();
        CleanClueSlots();
    }
   
    private void CleanClueSlots()
    {
        currentClueIndex = -1;
        Array.ForEach(clue, c => c.Clear());
    }

}
