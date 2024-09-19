using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class badge : MonoBehaviour
{

    public static string Badge = "Nice!!";

    TextMeshProUGUI tmp;

    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    
    void Update()
    {
        tmp.text = Badge;
    }
}
