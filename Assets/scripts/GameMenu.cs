using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ColorRangeOptionChange(int optionIndex)
    {
        int colorRange = 0;
        switch (optionIndex)
        {
            case 0:
                {
                    colorRange = 4;
                    break;
                }
            case 1:
                {
                    colorRange = 6;
                    break;
                }
            case 2:
                {
                    colorRange = 8;
                    break;
                }

        }
        RuleBook.Instance.multiColorRule.SetColorRange(colorRange);
    }

    public void RepeatableOptionChange(bool repeatable)
    {
        RuleBook.Instance.colorRepeatRule.repeatable = repeatable;
    }
}
