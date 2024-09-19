using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translasiobjek4 : MonoBehaviour
{
    private float kurang;
    public float kecepatanTranslasi;
    private double panjangTranslasixy;
    public Transform tujuan;

    private void Start()
    {
        panjangTranslasixy = transform.position.x;
        kurang = kecepatanTranslasi / -2;
    }

    private void Update()
    {
        transform.Translate(kurang * Time.deltaTime, 0, 0);
        if (transform.position.x < tujuan.position.x)
        {
            kurang = kecepatanTranslasi / 2;
        }
        else if (transform.position.x > panjangTranslasixy)
        {
            kurang = kecepatanTranslasi / -2;
        }
    }
}
