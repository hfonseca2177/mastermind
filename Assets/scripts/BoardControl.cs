using Rules;
using System;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BoardControl : MonoBehaviour
{
    
    private CodeLine _codeLine;
    private Line[] _lines;

    public CluePeg cluePeg;
    public CodePeg codePeg;
    public GameObject lid;

    private RuleBook _ruleBook;
    private MultiColorRule _multiColorRule;

    public int colorRangeSize;
    private const int maxLines = 10;
    private int _currentLineIndex = 0;


    void Start()
    {
        InstantiateBoardGame();
    }


    void InstantiateBoardGame()
    {        
        InitRuleBook();
        _codeLine = CodeLine.InitCodeLine();
        _lines = new Line[maxLines];
        for (int i = 0; i < maxLines; i++)
        {
            _lines[i] = Line.InitLine(i);
        }
        colorRangeSize = _multiColorRule.GetMaxColors();
    }

    public void InitRuleBook()
    {
        ColorRepeatRule colorRepeatRule = new ColorRepeatRule();
        colorRepeatRule.repeatable = false;

        _multiColorRule = new MultiColorRule();

        _multiColorRule.SetColorRange(colorRangeSize);

        _ruleBook = new RuleBook(new RuleSet[] { colorRepeatRule, _multiColorRule });
    }

    public void GenerateCodePegs()
    {
        Color[] colorPallete = ShuffleColors();
        Array.ForEach(colorPallete, color => codePeg.CreateCodePeg(_codeLine, color));
    }

    public void CleanPegs()
    {
        _codeLine.CleanLine();
        Array.ForEach(_lines, line => line.CleanCodeLines());
        _currentLineIndex = 0;
    }

    public void SetCodePeg(Color color)
    {
        _ruleBook.ApplyRules(_lines[_currentLineIndex], _codeLine);
        codePeg.CreateCodePeg(_lines[_currentLineIndex], color);
    }

    public bool IsCurrentLineCodeBreaker() => _lines[_currentLineIndex].IsSameCode(_codeLine);
    

    public void EvaluateClues() {
        List<ClueResult> result = new List<ClueResult>();
        for(int i=0; i< Line.maxCols; i++)
        {
            Spot spot = _lines[_currentLineIndex].code[i];
            if (_codeLine.MatchColorPosition(spot.pegColor, i))
            {
                result.Add(ClueResult.POSITION);
            }
            else if (_codeLine.HasColor(spot.pegColor))
            {
                result.Add(ClueResult.COLOR);
            }
            else
            {
                result.Add(ClueResult.EMPTY);
            }
        }

        var shuffledResult = result.OrderBy(x => Guid.NewGuid()).ToList();

        foreach(ClueResult clueResult in shuffledResult)
        {
            if (ClueResult.COLOR.Equals(clueResult))
            {
                cluePeg.CreateRightColorCluePeg(_lines[_currentLineIndex]);
            }else if (ClueResult.POSITION.Equals(clueResult))
            {
                cluePeg.CreateRightColorAndPositionCluePeg(_lines[_currentLineIndex]);
            }
        }
    }

    public bool IsLastLine()
    {
        return _currentLineIndex == (maxLines - 1);
    }

    public void CleanCurrentLine()
    {
        _lines[_currentLineIndex].CleanCodeLines();
    }

    public void MoveNextLine()
    {
        _currentLineIndex++;
    }

    public void ShowLid()
    {
        lid.SetActive(true);
    }

    public void HideLid()
    {
        lid.SetActive(false);
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
