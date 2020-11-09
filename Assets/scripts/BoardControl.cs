using Rules;
using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardControl : MonoBehaviour
{
    private Player _decoder;
    private Player _cypher;

    private Line _headLine;
    private Line[] _lines;

    public CluePeg cluePeg;
    public CodePeg codePeg;
    public GameObject lid;

    private RuleBook _ruleBook;
    private MultiColorRule _multiColorRule;
    public int colorRangeSize = 8;


    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void StartGame()
    {
        CreateAIPlayerMatch();
        InitRuleBook();
        InitBoard();
    }

    public void CreateRemotePlayersMatch()
    {
        _decoder = Player.CreateDecoder("john", "1-john");
        _cypher = Player.CreateCypher("Mary", "2-mary");
    }

    public void CreateAIPlayerMatch()
    {
        _decoder = Player.CreateDecoder("john", "1-john");
        _cypher = Player.CreateCypher("HALL9000", "ai");
    }

    private void CreateRandomCypher()
    {
        Color[] colorPallete = ShuffleColors();
        _headLine = Line.InitHeadLine();
        Array.ForEach(colorPallete, color => codePeg.CreateCodePeg(_headLine, color));

        _lines = new Line[10];
        
        for(int i = 0; i < 10; i++)
        {
            _lines[i] = Line.InitLine(i);
            Array.ForEach(colorPallete, color => codePeg.CreateCodePeg(_lines[i], color));
        }
        
    }

    public void InitRuleBook()
    {
        ColorRepeatRule colorRepeatRule = new ColorRepeatRule();
        colorRepeatRule.repeatable = false;

        _multiColorRule = new MultiColorRule();

        _multiColorRule.SetColorRange(colorRangeSize);

        _ruleBook = new RuleBook(new RuleSet[] { colorRepeatRule, _multiColorRule });
    }



    public void InitBoard()
    {
        _headLine = Line.InitHeadLine();
        CreateRandomCypher();
        
    }

    private Color[] ShuffleColors()
    {
        Color[] colorPallete = _multiColorRule.GetColorRange();
        
        int n = colorPallete.Length;

        while (n > 1)
        {
            int k = Random.Range(0, n--);
            Color temp = colorPallete[n];
            colorPallete[n] = colorPallete[k];
            colorPallete[k] = temp;
        }
        
        return colorPallete.Take(Line.maxCols).ToArray(); 
    }
}
