using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Global Values")]
    static public int levelsComplete;
    static public int[] highScores;



    [Header("Current Level Stats")]
    [SerializeField]
    static public float secondsRemaining;
    static public int bottlesCollected;
    static public bool Trophypickedup;
    static public int levelNumber;
    static public int score;


    [Header("Score Equation Modifiers")]

    [SerializeField]
    private float SecondstoPointsRatio;
    [SerializeField]
    private float bottlestoPointsRatio;
    [SerializeField]
    private float tropyPointMultiplyer;

    [Header("test display")]
    public int lvcompletetest;
    public float secondsRemainingTest;
    public int bottlesCollectedTest;
    public bool TrophypickedupTest;
    public int levelNumberTest;
    public int scoretest;



    private static GameObject instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this.gameObject;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        highScores = new int[3];
        print("game manager set up");
    }

    // Update is called once per frame
    void Update()
    {
        lvcompletetest = levelsComplete;
        secondsRemainingTest = secondsRemaining;
        bottlesCollectedTest = bottlesCollected;
        TrophypickedupTest = Trophypickedup;
        levelNumberTest = levelNumber;

        scoretest = score;

        
}

    public int ScoreEquation(float seconds, int bottles, bool trophyGot)
    {
        int score = Mathf.RoundToInt((seconds * SecondstoPointsRatio) + (bottles * bottlestoPointsRatio));
        if (trophyGot) { score = Mathf.RoundToInt(score * tropyPointMultiplyer); }
        return score;
    }
}
