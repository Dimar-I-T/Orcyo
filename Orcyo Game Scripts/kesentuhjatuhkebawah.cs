using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kesentuhjatuhkebawah : MonoBehaviour
{

    public float kecepatanJ;
    [HideInInspector]public float kecepatanstatic = 1;
    public float kecepatanSetelahJ;
    public static int kecepatanShadow;
    public static int angkaJ = 0;
    public static int angka3J = 0;
        
    public Vector3 posisi;

    private void Start()
    {
        posisi = transform.position;
    }

    private void Update()
    {
        transform.Translate(0, -kecepatanJ * Time.deltaTime, 0);
        switch (angkaJ)
        {
            case 1:
                transform.position = posisi;
                kecepatanJ = 0;
                break;
        }
        switch (angka3J)
        {
            case 1:
                transform.position = posisi;
                kecepatanJ = 0;
                break;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "voox")
        {
            kecepatanJ = kecepatanSetelahJ;
            duaenergi.Energi = 0;
            empatenergi.Energi = 0;
            satuenergi.Energi = 0;
        }
    }

}
