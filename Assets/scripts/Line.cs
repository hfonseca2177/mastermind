using System;
using UnityEngine;

public class Line
{
    public int maxCols = 4;
    public int index = 0;
    public int currentCodeIndex = 0;
    public int currentClueIndex = 0;

    public Spot[] code;
    public Spot[] clue;

    public Line InitLine(int index, Vector3 position)
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
            line.code[i] = Spot.CreateCodeSpot(position);
            line.clue[i] = Spot.CreateClueSpot(position);
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

    public void Clean()
    {
        currentCodeIndex = 0;
        currentClueIndex = 0;
        Array.ForEach(code, c => c.Clear());
        Array.ForEach(clue, c => c.Clear());
    }

}
