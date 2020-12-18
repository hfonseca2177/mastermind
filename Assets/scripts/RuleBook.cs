
using System;
using UnityEngine;
using Rules;
public class RuleBook : MonoBehaviour
{

    public MultiColorRule multiColorRule;
    public ColorRepeatRule colorRepeatRule;
    private int _colorRangeSize = 4;

    //Singleton instantiation
    private static RuleBook _instance;
    private const string _instanceName = "RuleBook Ref";

    public static RuleBook Instance
    {
        get
        {
            if (_instance == null) _instance = FindObjectOfType<RuleBook>();
            return _instance;
        }
    }

    public RuleBook()
    {
        colorRepeatRule = new ColorRepeatRule();
        colorRepeatRule.repeatable = false;
        multiColorRule = new MultiColorRule();
        multiColorRule.SetColorRange(_colorRangeSize);
    }

    private void Awake()
    {
        if (GameObject.Find(_instanceName)) Destroy(gameObject);
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        gameObject.name = _instanceName;
    }

}