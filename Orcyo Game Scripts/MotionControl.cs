using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionControl : MonoBehaviour
{
    public static float motionNumber = 1f;
    public static bool PenguranganAktif = true;
    public static bool PenjumlahanAktif = false;

    public GameObject tombolPengurangan;
    public GameObject tombolPenjumlahan;
    public GameObject BlueVig;

    private void Update()
    {
        Time.timeScale = motionNumber;
        if(motionNumber > 0)
        {
            tombolPengurangan.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Q))
            {
                motionNumber = 0.3f;
                BlueVig.SetActive(true);
            }
        }
        else if(motionNumber == 0)
        {
            tombolPengurangan.SetActive(false);
        }
        

        if(motionNumber < 1)
        {
            tombolPenjumlahan.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                motionNumber = 1;
                BlueVig.SetActive(false); 
            }
        }
        else if(motionNumber == 1)
        {
            tombolPenjumlahan.SetActive(false);
        }
        
    }

    public void Pengurangan()
    {
        motionNumber--;
    }

    public void Penjumlahan()
    {
        motionNumber++;
    }

}
