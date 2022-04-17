using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour
{
    [SerializeField]
    private Text highScoreL1;
    [SerializeField]
    private Text highScoreL2;
    [SerializeField]
    private Text highScoreL3;

    private void Start()
    {
        print(GameController.score);
        int levelScore = GameController.levelNumber - 1;
        if(levelScore < 0) { levelScore = 0; }
        if(GameController.score > GameController.highScores[levelScore])
        {
            GameController.highScores[levelScore] = GameController.score;
        }

        highScoreL1.text = "High Score: " + GameController.highScores[0].ToString();
        highScoreL2.text = "High Score: " + GameController.highScores[1].ToString();
        highScoreL3.text = "High Score: " + GameController.highScores[2].ToString();
    }
}
