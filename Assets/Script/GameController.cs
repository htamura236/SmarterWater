using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Global Values")]
    static public int levelsComplete;
    static public int[] highScores;



    [Header("Current Level Stats")]
    static public float secondsRemaining;
    static public int bottlesCollected;
    static public bool Trophypickedup;
    static public int levelNumber;
    static public int score;


    [Header("Score Equation Modifiers")]

    static public float SecondstoPointsRatio;
    static public float bottlestoPointsRatio;
    static public float tropyPointMultiplyer;

    [Header("Trophy Tracking")]
    static public bool TrophyL1;
    static public bool TrophyL2;
    static public bool TrophyL3;

    //able to be set in inspector
    [Header("Equation Variables")]
    [SerializeField]
    private float timeRatio;
    [SerializeField]
    private float bottleRatio;
    [SerializeField]
    private float trophyMultiplyer;

    // /* used for testing
    [Header("test display")]
    public int lvcompletetest;
    public float secondsRemainingTest;
    public int bottlesCollectedTest;
    public bool TrophypickedupTest;
    public int levelNumberTest;
    public int scoretest;
    // */




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

        //sets ratios and multiplyer used in equation from ones in inspector
        SecondstoPointsRatio = timeRatio;
        bottlestoPointsRatio = bottleRatio;
        tropyPointMultiplyer = trophyMultiplyer;
    }

    private void Start()
    {
        highScores = new int[3];
        print("game manager set up");
    }

    // Update is called once per frame
    void Update()
    {
        // /* used for testing
        lvcompletetest = levelsComplete;
        secondsRemainingTest = secondsRemaining;
        bottlesCollectedTest = bottlesCollected;
        TrophypickedupTest = Trophypickedup;
        levelNumberTest = levelNumber;

        scoretest = score; // */

        
}

    public int ScoreEquation(float seconds, int bottles, bool trophyGot)
    {
        int score = Mathf.RoundToInt((seconds * SecondstoPointsRatio) + (bottles * bottlestoPointsRatio));
        if (trophyGot) { score = Mathf.RoundToInt(score * tropyPointMultiplyer); }
        return score;
    }
}
