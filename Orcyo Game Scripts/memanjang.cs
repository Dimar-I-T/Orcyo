using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class memanjang : MonoBehaviour
{
    public static float kecepatan = 0;

    private void Update()
    {
        Vector3 panjang = transform.localScale;
        panjang.x += kecepatan * Time.deltaTime;
        transform.localScale = panjang;

        if(panjang.x > 1.9)
        {
            kecepatan = 0;
        }

    }
}
