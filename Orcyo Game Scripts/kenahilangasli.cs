using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kenahilangasli : MonoBehaviour
{
    
    public GameObject balokHilang;

    public static int angka = 0;
    public static int angka3 = 0;
    private void Update()
    {
        switch (angka)
        {
            case 1:
                balokHilang.SetActive(true);
                break;
        }
        switch (angka3)
        {
            case 1:
                balokHilang.SetActive(true);
                break;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "voox")
        {
            balokHilang.SetActive(false);
        }
    }

}


