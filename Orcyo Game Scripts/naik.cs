using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class naik : MonoBehaviour
{
    public static float kecepatan;
    public double posisi;
    public Transform tujuan;

    private void Start()
    {
        posisi = transform.position.y;
    }

    private void Update()
    {
        transform.Translate(0, -kecepatan * Time.deltaTime,0);
        
        if(transform.position.y > tujuan.position.y)
        {
            kecepatan = 0;
        }
    }

}
