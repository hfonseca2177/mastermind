using UnityEngine;

public class GameControl : MonoBehaviour
{
    public BoardControl boardControl;
    private bool _codeCracked = false;
    private float _score = 0;

    void StartGame()
    {
        boardControl.GenerateCodePegs();
    }

    void RestartGame()
    {
        boardControl.CleanPegs();
    }

    void SetCodePeg(Color color)
    {
        try
        {
            boardControl.SetCodePeg(color);
        }
        catch(System.ArgumentException e)
        {
            //show message
            Debug.Log(e.Message);
        }
    }

    void ConfirmCode()
    {
        _codeCracked  = boardControl.IsCurrentLineCodeBreaker();
        if (_codeCracked || boardControl.IsLastLine())
        {
            EndGame();
        }
        else
        {
            boardControl.EvaluateClues();
            boardControl.MoveNextLine();
        }
    }

    void CleanLine()
    {
        boardControl.CleanCurrentLine();
    }
    void EndGame()
    {
        if (_codeCracked)
        {
            WinGame();
        }else
        {
            LoseGame();
        }        
    }

    void WinGame()
    {
        //calc score
        _score = 100;
        Debug.Log(_score);
        //hide lid
        //ShowMessage
        //ShowScore
    }

    void LoseGame()
    {
        //ShowMessage
        //ShowOptionRestart
    }

    void OpenGameOptions()
    {
        //Show game options based on RuleBook
    }

    void SaveGameOptions()
    {
        //Update Rules
        //Option Restart Current Game
    }
}
