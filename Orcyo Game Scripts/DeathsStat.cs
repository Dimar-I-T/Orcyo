using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathsStat : MonoBehaviour
{
    // Banyak kematian dalam setiap level
    public static int deaths = 0;
    TextMeshProUGUI tmp;

    public void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        // Text untuk ditaruh di FinishPanel
        tmp.text = "Deaths : " + deaths;
    }
}
