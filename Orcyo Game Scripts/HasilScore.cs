using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HasilScore : MonoBehaviour
{

   

    
    
    public static int scorehasil;

    TextMeshProUGUI tmp;


    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

   
    void Update()
    {

        tmp.text = "Score : " + scorehasil;
    }
}
