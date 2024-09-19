using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cumasatuenergi : MonoBehaviour
{
    public GameObject adaEnergi;
    public GameObject adaGEnergi;
    public GameObject habisEnergi; 
    public GameObject habisGEnergi;
    public GameObject sfxEnergiHabis;
    public GameObject HabisVig;

    public Sprite HabisEnergiFace;
    public Sprite AdaEnergiFace;

    SpriteRenderer sprite;

    public Transform canvasTrans;

    bool AdaEnergi = true;
    bool HabisEnergi = false;
    public static bool sfxAktif = false;
    public static bool panel = false;
    public static bool panelHancur = false;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (panelHancur == true)
        {
            GameObject habisE = GameObject.FindGameObjectWithTag("habis");
            Destroy(habisE);
            panelHancur = false;
        }
        if (satuenergi.Energi > 0)
        {
            gerakan.lompatVelo = 19;
            gerakan.lompatan = 900f;
            gerakan.kecepatan = 10;
            trail.aktif = true;
        }
    
        if(AdaEnergi == true)
        {
            adaEnergi.SetActive(true);
            adaGEnergi.SetActive(true);
        }
        else
        {
            adaEnergi.SetActive(false);
            adaGEnergi.SetActive(false);
        }
        if (HabisEnergi == true)
        {
            habisEnergi.SetActive(true);
            habisGEnergi.SetActive(true);
        }
        else
        {
            habisEnergi.SetActive(false);
            habisGEnergi.SetActive(false);
        }

    }

    void FixedUpdate()
    {
        if(satuenergi.Energi <= 0)
        {
            Invoke("lompat", 0.1f * Time.deltaTime);
            Invoke("Horizontal", 0.1f * Time.deltaTime);
            habisenergi();
            sprite.sprite = HabisEnergiFace;
            //RewardedVideo.tombolAktif = false;
            if (sfxAktif == false && gerakan.Gakhabis == false)
            {
                Instantiate(sfxEnergiHabis, transform.position, transform.rotation);
                sfxAktif = true;
            }
            if (panel == false && gerakan.Gakhabis == false)
            {
                Instantiate(HabisVig, canvasTrans.parent);
                panel = true;
            }
            trail.aktif = false;
            panelHancur = false;
        }
        else if (satuenergi.Energi > 0)
        {
            panelHancur = true;
            gkhabisenergi();
            sprite.sprite = AdaEnergiFace;
            sfxAktif = false;
            panel = false;
            trail.aktif = true;
        }
    }

    public void habiss()
    {
        FindObjectOfType<audiomanager>().Play("energihabis");

    }

    public void habisenergi()
    {
        if (satuenergi.Energi <= 0)
        { 
            HabisEnergi = true;
            AdaEnergi = false;
        }
    }

    public void gkhabisenergi()
    {
        if(satuenergi.Energi > 0)
        {
            AdaEnergi = true;
            HabisEnergi = false;
        }
    }

    public void lompat()
    {
        gerakan.lompatVelo = 0;
        gerakan.lompatan = 0f;
    }

    public void Horizontal()
    {
        gerakan.kecepatan = 0;
    }

}
