using Rules;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.UIElements;

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
    public int colorRangeSize = 4;


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
        

        //int color = Random.Range(1, 4);

    }

    public void InitRuleBook()
    {
        ColorRepeatRule colorRepeatRule = new ColorRepeatRule();
        colorRepeatRule.repeatable = false;

        MultiColorRule multiColorRule = new MultiColorRule();
        multiColorRule.SetColorRange(colorRangeSize);
        
        _ruleBook = new RuleBook(new RuleSet[]{ colorRepeatRule, multiColorRule });
    }



    public void InitBoard()
    {
        _headLine = new Line();
        _headLine.InitLine(0, new Vector3());
    }
}
