using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameControl : MonoBehaviour
{
    public BoardControl boardControl;
    private bool _codeCracked = false;
    private float _score = 0;
    [SerializeField] private GameObject gameLogObj;
    [SerializeField] private GameObject[] colorButtons;

    private void Start()
    {
        TextMeshProUGUI log = gameLogObj.GetComponent<TextMeshProUGUI>();
        log.text += "<br> Game Started";
        boardControl.InstantiateBoardGame();
        StartGame();
    }

    void StartGame()
    {
        boardControl.GenerateCodePegs();
        EnabledColorButtons();
    }

    public void RestartGame()
    {
        boardControl.CleanPegs();
        boardControl.ShowLid();
        boardControl.GenerateCodePegs();
        EnabledColorButtons();
    }

    public void SetCodePeg(int colorIndex)
    {
        try
        {
            Color color = RuleBook.Instance.multiColorRule.GetFullColorRange()[colorIndex];
            boardControl.SetCodePeg(color);
        }
        catch(System.ArgumentException e)
        {
            //show message
            Debug.Log(e.Message);
        }
    }

    public void ConfirmCode()
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

    public void CleanLine()
    {
        boardControl.CleanCurrentLine();
        EnabledColorButtons();
    }
    void EndGame()
    {
        boardControl.HideLid();
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
        //ShowMessage
        //ShowScore
    }

    void LoseGame()
    {
        
        //ShowMessage
        //ShowOptionRestart
    }

    public void OpenGameMenu()
    {
        SceneManager.LoadScene(0);
    }

    void SaveGameOptions()
    {
        //Update Rules
        //Option Restart Current Game
    }

    private void EnabledColorButtons()
    {
        int usedColorCount = RuleBook.Instance.multiColorRule.GetColorSet().Length;
        for (int i=0; i< RuleBook.Instance.multiColorRule.GetMaxColors(); i++)
        {
            colorButtons[i].SetActive(i < usedColorCount);
        }
    }

    public void DisableColorButton(GameObject colorButton)
    {
        colorButton.SetActive(RuleBook.Instance.colorRepeatRule.repeatable);
    }
}
