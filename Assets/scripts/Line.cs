using System;
using System.Collections.Generic;
using UnityEngine;

public class Line
{
    public static int maxCols = 4;
    public int index = 0;
    public int currentCodeIndex = -1;
    public int currentClueIndex = -1;

    public Spot[] code;
    public Spot[] clue;

    public static Line InitLine(int index)
    {
        Line line = new Line
        {
            code = new Spot[maxCols],
            clue = new Spot[maxCols],
            index = index
        };

        //Array.ForEach(line.code, code => code = Spot.CreateCodeSpot(position));

        for (int i = 0; i < maxCols; i++)
        {
            line.code[i] = Spot.CreateCodeSpot(index, i);
            line.clue[i] = Spot.CreateClueSpot(index, i);
        }
        return line;
    }

    public static Line InitHeadLine()
    {
        Line line = new Line
        {
            code = new Spot[maxCols]
        };
        for (int i = 0; i < maxCols; i++)
        {
            line.code[i] = Spot.CreateHeadCodeSpot(i);
        }
        return line;
    }
    

    public Spot GetNextCodeSpot()
    {        
        if (currentCodeIndex < maxCols)
        {
            currentCodeIndex++;
        }
        return this.code[currentCodeIndex];
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

    public void CleanHeadLine()
    {
        CleanCodeSlots();
        CleanClueSlots();
    }

    private void CleanCodeSlots()
    {
        currentCodeIndex = -1;
        Array.ForEach(code, c => c.Clear());
    }
    private void CleanClueSlots()
    {
        currentClueIndex = -1;
        Array.ForEach(clue, c => c.Clear());
    }

}
