using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class duaenergi : MonoBehaviour
{
    public static double Energi = 2;

    public static string energi = "Energy : ";

    TextMeshProUGUI tmp;
    
    private void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        tmp.text = energi + Energi;
    }

}
