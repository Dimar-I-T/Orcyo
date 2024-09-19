using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    TextMeshProUGUI tmp;

    public static int Energi = 2;

    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    
    void Update()
    {
        tmp.text = "Energy : " + Energi;
    }
}
