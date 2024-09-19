using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class DataSaveBaru : MonoBehaviour
{
    public static int wins, deaths;
    public static int totalScore;
    public static string skill;
    public Text[] teksWin, teksDeath, teksTotalScore, teksSkill, levelLanjut;
    public GameObject[] playBiasa, tombolContinue;

    public void Update()
    {
        int scoreSek = PlayerPrefs.GetInt("score"), deathSek = PlayerPrefs.GetInt("deaths"), sceneSek = PlayerPrefs.GetInt("scene");

        foreach (Text s in teksDeath)
        {
            s.text = "Deaths : " + deathSek;
        }

        foreach (Text s in teksTotalScore)
        {
            s.text = "Total score : " + scoreSek;
        }

        foreach (Text s in teksSkill)
        {
            if (scoreSek > deathSek)
            {
                s.text = "Skill : Pro";
            }
            else
            {
                s.text = "Skill : Noob";
            }
        }

        foreach (GameObject g in playBiasa)
        {
            if (sceneSek <= 1)
            {
                g.SetActive(true);
            }
            else
            {
                g.SetActive(false);
            }
        }

        foreach (GameObject g in tombolContinue)
        {
            if (sceneSek >= 2)
            {
                g.SetActive(true);
            }
            else
            {
                g.SetActive(false);
            }
        }

        foreach (Text s in levelLanjut)
        {
            s.text = "Level : " + (sceneSek - 1);
        }
    }

    public void Lanjut()
    {
        int sceneSek = PlayerPrefs.GetInt("scene");
        if (sceneSek < 2)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            SceneManager.LoadScene(sceneSek);
        }
    }
}
