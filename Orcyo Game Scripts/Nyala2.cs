using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nyala2 : MonoBehaviour
{

    public GameObject Panel;
    public static bool aktif = false;
    public float waktu;

    private void Update()
    {
        if (aktif)
        {
            Panel.SetActive(true);
        }
        else if (!aktif)
            Panel.SetActive(false);
    }

}
