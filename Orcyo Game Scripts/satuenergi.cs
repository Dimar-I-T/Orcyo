using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class satuenergi : MonoBehaviour
{

    private TextMeshProUGUI tmp;
    public static int Energi = 1;

    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        tmp.text = "Energy : " + Energi;
    }
}
