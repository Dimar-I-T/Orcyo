using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SFX : MonoBehaviour
{
    public void tombol()
    {
        FindObjectOfType<audiomanager>().Play("tombol");
    }
    
    public void tombol2()
    {
        FindObjectOfType<audiomanager>().Play("tombol2");
    }

    public void lompat()
    {
        FindObjectOfType<audiomanager>().Play("lompat");
    }

    public void death()
    {
        FindObjectOfType<audiomanager>().Play("mati");
    }
}

