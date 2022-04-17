using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour
{
    [Header("High Scores")]
    [SerializeField]
    private Text highScoreL1;
    [SerializeField]
    private Text highScoreL2;
    [SerializeField]
    private Text highScoreL3;

    [Header("Trophy Icons")]
    [SerializeField]
    private Image[] trophyIcons;
    [SerializeField]
    private bool TrophyL1;
    [SerializeField]
    private bool TrophyL2;
    [SerializeField]
    private bool TrophyL3;

    private void Start()
    {
        //last level beat detection
        print(GameController.score);
        int levelScore = GameController.levelNumber - 1;
        if(levelScore < 0) { levelScore = 0; }

        //highscore updates
        if (GameController.score > GameController.highScores[levelScore])
        {
            GameController.highScores[levelScore] = GameController.score;
        }

        highScoreL1.text = "High Score: " + GameController.highScores[0].ToString();
        highScoreL2.text = "High Score: " + GameController.highScores[1].ToString();
        highScoreL3.text = "High Score: " + GameController.highScores[2].ToString();

        //trophy icon update

        if(levelScore == 0 && GameController.Trophypickedup)
        {
            GameController.TrophyL1 = true;
        }
        if (levelScore == 1 && GameController.Trophypickedup)
        {
            GameController.TrophyL2 = true;
        }
        if (levelScore == 2 && GameController.Trophypickedup)
        {
            GameController.TrophyL3 = true;
        }

        if(GameController.TrophyL1) { trophyIcons[0].gameObject.SetActive(true); }
        if(GameController.TrophyL2) { trophyIcons[1].gameObject.SetActive(true); }
        if(GameController.TrophyL3) { trophyIcons[2].gameObject.SetActive(true); }

    }
}
