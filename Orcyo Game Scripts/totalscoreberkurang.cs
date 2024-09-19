using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class totalscoreberkurang : MonoBehaviour
{
    private TextMeshProUGUI tmp;

    public Text totaltext;
    public static int angkaminus;
    public static int Total;
    public static int scoreSementara;

    public void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        scoreSementara = PlayerPrefs.GetInt("S");
        Total = scoreSementara;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            angkaminus--;
        }

        tmp.text = "sss : " + angkaminus;

        if(scoreSementara > angkaminus)
        {
            PlayerPrefs.SetInt("S", angkaminus);
        }
        Total = PlayerPrefs.GetInt("S");
        totaltext.text = "S : " + Total;
    }

    public static void kurang()
    {
        if(scoreSementara > angkaminus)
        {
            PlayerPrefs.SetInt("S", angkaminus);
        }
    }
}
