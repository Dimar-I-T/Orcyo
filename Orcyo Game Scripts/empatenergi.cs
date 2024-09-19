using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class empatenergi : MonoBehaviour
{
    public static double Energi = 4;
    private TextMeshProUGUI tmp;

    private void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    public void Update()
    {
        tmp.text = "Energy : " + Energi;
    }
    
}
