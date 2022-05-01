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

    [Header("Level 1 Medals")]
    [SerializeField]
    private Image[] MedalIconsLv1;
    [SerializeField]
    private int[] ThreshHoldsLv1;
    [Header("Level 2 Medals")]
    [SerializeField]
    private Image[] MedalIconsLv2;
    [SerializeField]
    private int[] ThreshHoldsLv2;
    [Header("Level 3 Medals")]
    [SerializeField]
    private Image[] MedalIconsLv3;
    [SerializeField]
    private int[] ThreshHoldsLv3;

    [Header("Medal Point Display")]
    [SerializeField]
    private Text[] Level1;
    [SerializeField]
    private Text[] Level2;
    [SerializeField]
    private Text[] Level3;

    [Header("Button")]
    [SerializeField]
    private GameObject level2Button;
    [SerializeField]
    private GameObject level3Button;
    //0 bronze, 1 silver 2 gold
    [SerializeField]
    private int lv2Requirment;
    [SerializeField]
    private int lv3Requirment;


    private void Start()
    {
        //last level beat detection
        print(GameController.score);
        int levelScore = GameController.levelNumber - 1;
        if(levelScore < 0) { levelScore = 0; }
        if(levelScore > 3) { levelScore = 0; }

        //highscore updates
        if (GameController.score > GameController.highScores[levelScore])
        {
            GameController.highScores[levelScore] = GameController.score;
        }

        highScoreL1.text = "High Score: " + GameController.highScores[0].ToString();
        highScoreL2.text = "High Score: " + GameController.highScores[1].ToString();
        highScoreL3.text = "High Score: " + GameController.highScores[2].ToString();

        //trophy icon update

        if(GameController.levelNumber - 1 == 0 && GameController.Trophypickedup)
        {
            GameController.TrophyL1 = true;
        }
        if (GameController.levelNumber - 1 == 1 && GameController.Trophypickedup)
        {
            GameController.TrophyL2 = true;
        }
        if (GameController.levelNumber - 1 == 2 && GameController.Trophypickedup)
        {
            GameController.TrophyL3 = true;
        }

        if(GameController.TrophyL1) { trophyIcons[0].gameObject.SetActive(true); }
        if(GameController.TrophyL2) { trophyIcons[1].gameObject.SetActive(true); }
        if(GameController.TrophyL3) { trophyIcons[2].gameObject.SetActive(true); }

        //medals check
        //level 1
        if(GameController.highScores[0] >= ThreshHoldsLv1[0])
        {
            MedalIconsLv1[0].gameObject.SetActive(true);
        }
        if (GameController.highScores[0] >= ThreshHoldsLv1[1])
        {
            MedalIconsLv1[1].gameObject.SetActive(true);
        }
        if (GameController.highScores[0] >= ThreshHoldsLv1[2])
        {
            MedalIconsLv1[2].gameObject.SetActive(true);
        }

        //level 2
        if (GameController.highScores[1] >= ThreshHoldsLv2[0])
        {
            MedalIconsLv2[0].gameObject.SetActive(true);
        }
        if (GameController.highScores[1] >= ThreshHoldsLv2[1])
        {
            MedalIconsLv2[1].gameObject.SetActive(true);
        }
        if (GameController.highScores[1] >= ThreshHoldsLv2[2])
        {
            MedalIconsLv2[2].gameObject.SetActive(true);
        }

        //level 3
        if (GameController.highScores[2] >= ThreshHoldsLv3[0])
        {
            MedalIconsLv3[0].gameObject.SetActive(true);
        }
        if (GameController.highScores[2] >= ThreshHoldsLv3[1])
        {
            MedalIconsLv3[1].gameObject.SetActive(true);
        }
        if (GameController.highScores[2] >= ThreshHoldsLv3[2])
        {
            MedalIconsLv3[2].gameObject.SetActive(true);
        }

        //display of points required for diffrent medals
        Level1[0].text = ThreshHoldsLv1[0] + " Pts";
        Level1[1].text = ThreshHoldsLv1[1] + " Pts";
        Level1[2].text = ThreshHoldsLv1[2] + " Pts";
        Level2[0].text = ThreshHoldsLv2[0] + " Pts";
        Level2[1].text = ThreshHoldsLv2[1] + " Pts";
        Level2[2].text = ThreshHoldsLv2[2] + " Pts";
        Level3[0].text = ThreshHoldsLv3[0] + " Pts";
        Level3[1].text = ThreshHoldsLv3[1] + " Pts";
        Level3[2].text = ThreshHoldsLv3[2] + " Pts";
        
        //lv 2 check
        if(GameController.highScores[0] < ThreshHoldsLv1[lv2Requirment])
        {
            level2Button.GetComponent<Button>().enabled = false;
        }

        //lv 3 check
        if (GameController.highScores[1] < ThreshHoldsLv2[lv3Requirment])
        {
            level3Button.GetComponent<Button>().enabled = false;
        }
    }


}
