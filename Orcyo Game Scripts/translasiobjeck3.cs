using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translasiobjeck3 : MonoBehaviour
{
    private float kurang;
    public float kecepatanTranslasi;
    private double panjangTranslasixy;
    public Transform tujuan;

    private void Start()
    {
        panjangTranslasixy = transform.position.y;
        kurang = kecepatanTranslasi / -2;
    }

    private void Update()
    {
        transform.Translate(kurang * Time.deltaTime, 0, 0);
        if (transform.position.y > tujuan.position.y)
        {
            kurang = kecepatanTranslasi / 2;
        }
        else if (transform.position.y < panjangTranslasixy)
        {
            kurang = kecepatanTranslasi / -2;
        }
    }
}
