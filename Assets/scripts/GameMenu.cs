using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameMenu : MonoBehaviour
{

    [SerializeField] private GameObject toggleColorRepeate;
    [SerializeField] private GameObject dropdownColorRange;

    private void Start()
    {
        Toggle toggle = toggleColorRepeate.GetComponent<Toggle>();
        if (toggle != null)
        {
            Debug.Log("Toggle Found!");
            toggle.SetIsOnWithoutNotify(RuleBook.Instance.colorRepeatRule.repeatable);
        }

        TMP_Dropdown dropddown = dropdownColorRange.GetComponent<TMP_Dropdown>();
        if (dropddown != null)
        {
            Debug.Log("DropDown Found!");
            dropddown.value = RuleBook.Instance.multiColorRule.GetColorSet().Length;
        }
    }

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
