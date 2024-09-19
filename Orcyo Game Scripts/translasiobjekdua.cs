using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translasiobjekdua : MonoBehaviour
{
    private float kurang;
    private float tambah;
    public float kecepatanTranslasi;
    public double panjangTranslasixy;
    public double currentpanjangTranslasixy;

    private void Start()
    {
        tambah = kecepatanTranslasi / 2;
        kurang = kecepatanTranslasi / -2;
    }

    private void Update()
    {
        transform.Translate(kurang * Time.deltaTime,0 , 0);
        if (transform.position.y < panjangTranslasixy)
        {
            kurang = kecepatanTranslasi / 2;
        }
        else if (transform.position.y > currentpanjangTranslasixy)
        {
            kurang = kecepatanTranslasi / -2;
        }
    }
}
