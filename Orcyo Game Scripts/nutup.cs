using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nutup : MonoBehaviour
{
    public static float kecepatan = 0;

    private void Update()
    {
        transform.Translate(0, kecepatan * Time.deltaTime, 0);
        if(gameObject.transform.position.y < 9)
        {
            kecepatan = 0;
        }
    }
   
}
