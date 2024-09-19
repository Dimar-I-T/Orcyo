using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class scoreasli : MonoBehaviour
{
    public Text HighScore;

    public static int Score = 1;
    int scoreSementara;
    int highscore;

    TextMeshProUGUI tmp;

    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        /*scoreSementara = PlayerPrefs.GetInt("HS");
        highscore = scoreSementara;*/
    }

    
    void Update()
    {
        tmp.text = "Score : " + Score;
        
        /*if (scoreSementara <= Score)
        {
            PlayerPrefs.SetInt("HS", Score);
        }
        highscore = PlayerPrefs.GetInt("HS");
        HighScore.text = "HighScore : " + highscore;*/
    }
}
