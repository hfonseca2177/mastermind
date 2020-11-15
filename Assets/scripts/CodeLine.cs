
public class CodeLine : BaseLine
{

    public static CodeLine InitCodeLine()
    {
        CodeLine codeLine = new CodeLine
        {
            code = new Spot[maxCols]
        };
        for (int i = 0; i < maxCols; i++)
        {
            codeLine.code[i] = Spot.CreateHeadCodeSpot(i);
        }
        return codeLine;
    }

    public void CleanLine()
    {
        CleanCodeSlots();
    }
}
