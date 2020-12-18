using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class GameControl : MonoBehaviour
{
    
    private bool _codeCracked = false;

    [Header("References")]
    public BoardControl boardControl;
    [SerializeField] private GameObject gameLogObj;
    [SerializeField] private GameObject[] colorButtons;
    private TextMeshProUGUI log;
    [SerializeField] private GameObject winGamePanel;
    [SerializeField] private GameObject lossGamePanel;
    [SerializeField] private GameObject confirmButton;
    [SerializeField] private GameObject cleanButton;


    [Header("Audio SFX")]
    [SerializeField] private AudioSource sfxAudioSource;
    [SerializeField] private AudioClip colorSelectedClip;
    [SerializeField] private AudioClip winClip;
    [SerializeField] private AudioClip lossClip;

    private void Start()
    {
        log = gameLogObj.GetComponent<TextMeshProUGUI>();
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
        ToggleLineCommands(true);
        boardControl.CleanPegs();
        boardControl.ShowLid();
        boardControl.GenerateCodePegs();
        EnabledColorButtons();
    }

    public void SetCodePeg(int colorIndex)
    {
        try
        {
            sfxAudioSource.PlayOneShot(colorSelectedClip);
            Color color = RuleBook.Instance.multiColorRule.GetFullColorRange()[colorIndex];
            boardControl.SetCodePeg(color);
        }
        catch(System.ArgumentException e)
        {
            LogMessage(e.Message);
        }
    }

    public void ConfirmCode()
    {
        boardControl.EvaluateClues();
        _codeCracked  = boardControl.IsCurrentLineCodeBreaker();
        if (_codeCracked || boardControl.IsLastLine())
        {
            EndGame();
        }
        else
        {            
            boardControl.MoveNextLine();
            EnabledColorButtons();
        }
    }
      
    public void CleanLine()
    {
        boardControl.CleanCurrentLine();
        EnabledColorButtons();
    }
    void EndGame()
    {
        ToggleLineCommands(false);
        boardControl.HideLid();
        if (_codeCracked)
        {
            sfxAudioSource.PlayOneShot(winClip);
            WinGame();
        }else
        {
            sfxAudioSource.PlayOneShot(lossClip);
            LoseGame();
        }        
    }

    void WinGame()
    {
        StartCoroutine(ShowEndPanel(winGamePanel, "You Won!"));
    }

    void LoseGame()
    {
        StartCoroutine(ShowEndPanel(lossGamePanel, "You Lose!"));
    }

    public void OpenGameMenu()
    {
        SceneManager.LoadScene(0);
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

    private void LogMessage(string message)
    {
        log.text += "<br>" + message;
    }

    private IEnumerator ShowEndPanel(GameObject panel, string message)
    {
        panel.SetActive(true);
        yield return new WaitForSeconds(4f);
        panel.SetActive(false);
    }

    private void ToggleLineCommands(bool toggle)
    {
        confirmButton.SetActive(toggle);
        cleanButton.SetActive(toggle);
    }
}
