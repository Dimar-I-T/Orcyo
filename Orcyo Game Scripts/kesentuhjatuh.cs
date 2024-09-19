using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kesentuhjatuh : MonoBehaviour
{
    public float kecepatan;
    [HideInInspector]public float kecepatanstatic = 1;
    public float kecepatanSetelah;
    public static int kecepatanShadow;
    public static int angka = 0;
    public static int angka3 = 0;

    public Vector3 posisi;

    private void Start()
    {
        posisi = transform.position;
    }

    private void Update()
    {
        transform.Translate(0, -kecepatan * Time.deltaTime, 0);
        switch (angka)
        {
            case 1:
                transform.position = posisi;
                kecepatan = 0;
                break;
        }
        switch (angka3)
        {
            case 1:
                transform.position = posisi;
                kecepatan = 0;
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "voox")
        {
            kecepatan = kecepatanSetelah;
             
        }
    }
}
