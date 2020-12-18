using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameMenu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject toggleColorRepeate;
    [SerializeField] private GameObject dropdownColorRange;
    [SerializeField] private AudioSource sfxAudioSource;
    [SerializeField] private AudioClip choiceMadeClip;


    private void Start()
    {

        Toggle toggle = toggleColorRepeate.GetComponent<Toggle>();
        if (toggle != null)
        {
            toggle.SetIsOnWithoutNotify(RuleBook.Instance.colorRepeatRule.repeatable);
        }

        TMP_Dropdown dropddown = dropdownColorRange.GetComponent<TMP_Dropdown>();
        if (dropddown != null)
        {
            dropddown.value = ConvertColorRangeToIndex(RuleBook.Instance.multiColorRule.GetColorSet().Length);
            dropddown.onValueChanged.AddListener(delegate
            {
                ColorRangeOptionChange(dropddown);
            });
        }
    }

    public void PlayGame()
    {
        PlayOptionSelected();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        PlayOptionSelected();
        Application.Quit();
    }

    public void ColorRangeOptionChange(TMP_Dropdown dropddown)
    {

        int colorRange = 0;
        switch (dropddown.value)
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
        PlayOptionSelected();
    }

    public void RepeatableOptionChange(bool repeatable)
    {
        RuleBook.Instance.colorRepeatRule.repeatable = repeatable;
        PlayOptionSelected();
    }

    private int ConvertColorRangeToIndex(int length)
    {
        int dropdownIndex = 0;
        switch (length)
        {
            case 4:
                {
                    dropdownIndex = 0;
                    break;
                }
            case 6:
                {
                    dropdownIndex = 1;
                    break;
                }
            case 8:
                {
                    dropdownIndex = 2;
                    break;
                }
        }
        return dropdownIndex;
    }

    private void PlayOptionSelected()
    {
        sfxAudioSource.PlayOneShot(choiceMadeClip);
    }

}
