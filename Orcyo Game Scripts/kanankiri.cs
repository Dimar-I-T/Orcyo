using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslasiObjek : MonoBehaviour
{
    private float kurang;
    public float kecepatanTranslasi;
    public double panjangTranslasixy;
    public double currentpanjangTranslasixy;
    
    private void Start()
    {
        kurang = kecepatanTranslasi / -2;
    }

    private void Update()
    {
        transform.Translate(kurang * Time.deltaTime, 0,0);
        if(transform.position.x < panjangTranslasixy)
        {
            kurang = kecepatanTranslasi / 2;
        }
        else if(transform.position.x > currentpanjangTranslasixy)
        {
            kurang = kecepatanTranslasi / -2;
        }
    }

}
