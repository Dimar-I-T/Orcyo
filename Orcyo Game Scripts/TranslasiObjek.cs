using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translasi : MonoBehaviour
{
    private float kurang;
    private float tambah;
    public float kecepatanTranslasiHorizontal;
    public float kecepatanTranslasiVertical;
    public double panjangTranslasi;
    public double currentpanjangTranslasi;
   
    private void Start()
    {
        tambah = kecepatanTranslasiVertical / 2;
        kurang = kecepatanTranslasiHorizontal / -2;
    }

    private void Update()
    {
        transform.Translate(kurang * Time.deltaTime, tambah * Time.deltaTime,0);
        // Horizontal
        if(transform.position.x < panjangTranslasi)
        {
            kurang = kecepatanTranslasiHorizontal / 2;
        }
        else if(transform.position.x > currentpanjangTranslasi)
        {
            kurang = kecepatanTranslasiHorizontal / -2;
        }

        // Vertical
        if(transform.position.y < panjangTranslasi)
        {
            tambah = kecepatanTranslasiVertical / -2;
        }
        else if(transform.position.y > currentpanjangTranslasi)
        {
            tambah = kecepatanTranslasiVertical / 2;
        }
    }

}
