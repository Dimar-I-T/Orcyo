using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isibalok : MonoBehaviour
{
    public GameObject balokHilangWT;
  
    public SpriteRenderer spriteBalok;

    public static int angka = 0;
    public static int angka3 = 0;
    private void Update()
    {
        switch (angka)
        {
            case 1:
                spriteBalok.color = Color.white;
                balokHilangWT.SetActive(true);
                break;
        }

        switch (angka3)
        {
            case 1:
                spriteBalok.color = Color.white;
                balokHilangWT.SetActive(true);
                break;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "voox" )
        {
            Color colorBaru = new Color(0.32f, 0.43f, 0.06f);
            spriteBalok.color = colorBaru;
            Invoke(nameof(hilang), 0.5f);
        }
    }

    private void hilang()
    {
        balokHilangWT.SetActive(false);
    }

}
