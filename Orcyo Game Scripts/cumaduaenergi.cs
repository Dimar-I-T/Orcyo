using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cumaduaenergi : MonoBehaviour
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
    public static bool SFXAktif = false;
    public static bool panel = false;
    public static bool panelHancur;

    int banyaknyaSFX;
    public static int angkaP;

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
        if (duaenergi.Energi > 0)
        {
            gerakan.lompatVelo = 19;
            gerakan.lompatan = 900f;
            gerakan.kecepatan = 10f;
            trail.aktif = true;
        }
    }

    private void LateUpdate()
    {
        // Jika si Energi kurang sama dengan 0, maka voox tidak akan bisa bergerak
        if (duaenergi.Energi <= 0)
        {
            Invoke("lompathabis", 0.9f * Time.deltaTime);
            Invoke("horizontalhabis", 0.9f * Time.deltaTime);
            energihabis();
            sprite.sprite = HabisEnergiFace;
            //RewardedVideo.tombolAktif = false;
            if (SFXAktif == false && gerakan.Gakhabis == false)
            {
                Instantiate(sfxEnergiHabis, transform.position, transform.rotation);
                SFXAktif = true;
            }
            if (panel == false && gerakan.Gakhabis == false)
            {
                Instantiate(HabisVig, canvasTrans.parent);
                panel = true;
            }
            trail.aktif = false;
            panelHancur = false;
        }
        else
        {
            panelHancur = true;
            energigkhabis();
            sprite.sprite = AdaEnergiFace;
            SFXAktif = false;
            panel = false;
            trail.aktif = true;
        }

        // Jika duaenergi, empatenergi, satu energi sudah lebih dari tambah dua maka tidak akan ada iklan

    }

    public void energihabis()
    {
        if (duaenergi.Energi <= 0)
        {
            AdaEnergi = false;
            if (AdaEnergi)
            {
                adaEnergi.SetActive(true);
                adaGEnergi.SetActive(true);
            }
            else
            {
                adaEnergi.SetActive(false);
                adaGEnergi.SetActive(false);

            }
            HabisEnergi = true;
            if (HabisEnergi)
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

    }

    public void energigkhabis()
    {
        if (duaenergi.Energi > 0)
        {
            AdaEnergi = true;
            if (AdaEnergi)
            {
                adaEnergi.SetActive(true);
                adaGEnergi.SetActive(true);
            }
            else
            {
                adaEnergi.SetActive(false);
                adaGEnergi.SetActive(false);
            }
            HabisEnergi = false;
            if (HabisEnergi)
            {
                habisEnergi.SetActive(true);
                habisGEnergi.SetActive(true);
            }
            else
            {
                habisGEnergi.SetActive(false);
                habisEnergi.SetActive(false);
            }
        }
    }

    private void lompathabis()
    {
        gerakan.lompatVelo = 0;
        gerakan.lompatan = 0f;
    }

    private void horizontalhabis()
    {
        gerakan.kecepatan = 0f;
    }
}
