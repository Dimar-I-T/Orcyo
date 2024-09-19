using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObject : MonoBehaviour
{
    public GameObject petunjukH;
    public GameObject petunjukMaju;
    public GameObject petunjukTM;
    public GameObject petunjukTL;
    bool Tombol1;
    bool Tombol2;

    private void Update()
    {
        Invoke(nameof(PetunjukTombolLompat), 0f);
        Invoke(nameof(PetunjukTombolMaju), 0f);
        Invoke(nameof(Petunjuk1), 1.5f);
        Invoke(nameof(PetunjukMaju), 2.5f);
        //if(cumaduaenergi.angkaP == 1) { petunjukH.SetActive(false); }
        switch (Tombol1) {
            case true:
                petunjukTM.SetActive(true);
                break;
            case false:
                petunjukTM.SetActive(false);
                break;
        }switch (Tombol2) {
            case true:
                petunjukTL.SetActive(true);
                break;
            case false:
                petunjukTL.SetActive(false);
                break;
        }
    }

    public void Petunjuk1()
    {
        petunjukH.SetActive(true);
    }public void PetunjukMaju()
    {
        petunjukMaju.SetActive(true);
    }public void PetunjukTombolMaju()
    {
        Tombol1 = true;
    }public void PetunjukTombolLompat()
    {
        Tombol2 = true;
    }

    public void TombolMaju()
    {
        petunjukTM.SetActive(false);
    }public void TombolLompat()
    {
        //petunjukTL.SetActive(false);
    }
}
