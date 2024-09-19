using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.IO;
using TMPro;

public class highscore : MonoBehaviour
{
    private TextMeshProUGUI tmp;

    int HS;

    // Start is called before the first frame update
    void Start()
    {
        HS = scoreasli.Score;
        tmp = GetComponent<TextMeshProUGUI>();    
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = "HS :" + HS;
    }
}
