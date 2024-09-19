using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeSelection : MonoBehaviour
{
    public Image image1;
    public Image image2;
    public Image image3;
    public Image image4;
    public Sprite spriteHitam1;
    public Sprite spriteHitamPolos1;
    public Sprite spriteHitam2;
    public Sprite spriteHitam4;
    public Sprite spriteHitamPolos2;
    public Sprite spriteHitamPolos3;
    public Sprite spriteHitamPolos4;
    public Sprite spritePutih3;
    public Sprite spritePutih1;
    public Sprite spritePutihPolos1;
    public Sprite spritePutih2;
    public Sprite spritePutihPolos2;
    public Sprite spritePutihPolos3;
    public Sprite spritePutihPolos4;

    public Color color;

    // gameObject
    public GameObject dark;
    public GameObject dark4;
    public GameObject white;
    public GameObject white3;

   
    // text
    public Text angkaOddOrEven;

    //integers
    int CaseNotSave = 2;
    private int angkaPutih = 1;
    private int angkaHitam = 2;
    private int angkaPutih3 = 3;
    private int angkaHitam4 = 4;
    private int save;
    public static int totalsave;
    int temaBerapa = 1;
    
    ///string
    public static string themeSaveHitam;
    public static string themeSavePutih;
    public static string theme;
    public static string themePutih;
    public static string themeHitam;
    public static string Hitam = "Hitam";
    public static string Putih = "Putih";
    public static string Hitam4 = "Hitam4";
    public static string Putih3 = "Putih3";
    public static string keyHitam = "H";
    public static string KeyPutih = "P";
   

    [HideInInspector] public bool tombolSFX;

    private void Start()
    {
        save = PlayerPrefs.GetInt("E");
        switch (PlayerPrefs.GetInt("tema"))
        {
            case 1:
                gantiWarnaPutih();
                break;
            case 2:
                gantiWarnaHitam();
                break;
            case 3:
                GantiWarnaPutih3();
                break;
            case 4:
                GantiWarnaHitam4();
                break;
        }
        totalsave = save;
        CaseNotSave = angkaPutih;
        CaseNotSave = angkaHitam;
        CaseNotSave = angkaPutih3;
        CaseNotSave = angkaHitam4;
    }
    
    private void Update()
    {
        
        if(save == angkaHitam)
        {
            PlayerPrefs.SetInt("E", angkaHitam);

            totalsave = PlayerPrefs.GetInt("E");
            angkaOddOrEven.text = "angka = " + totalsave;
        }

        if(totalsave == 2)
        {
            dark.SetActive(true);
            image2.sprite = spriteHitam2;
            image1.sprite = spriteHitamPolos1;
            image3.sprite = spriteHitamPolos3;
            image4.sprite = spriteHitamPolos4;
            tombolSFX = false;
        }
        else
        {
            dark.SetActive(false);
        }

        switch (totalsave) {
            case 2:
                //ss
                break;
            case 1:
                //ss
                break;
            case 3:
                //ss
                break;
            case 4:
                //ss
                break;

            default:
                save = angkaPutih;
                break;
        }

        if(save == angkaPutih) 
        {
            PlayerPrefs.SetInt("E", angkaPutih);
            totalsave = PlayerPrefs.GetInt("E");
            angkaOddOrEven.text = "angka = " + totalsave;
        }   

        if(totalsave == 1)
        {
            white.SetActive(true);
            image2.sprite = spritePutihPolos2;
            image1.sprite = spritePutih1;
            image3.sprite = spritePutihPolos3;
            image4.sprite = spritePutihPolos4;
            tombolSFX = true;
        }
        else
        {
            white.SetActive(false);
        }

        if(save == angkaHitam4)
        {
            PlayerPrefs.SetInt("E", angkaHitam4);
            totalsave = PlayerPrefs.GetInt("E");
            angkaOddOrEven.text = "angka = " + totalsave;
        }

        if(totalsave == 4)
        {
            dark4.SetActive(true);
            image1.sprite = spriteHitamPolos1;
            image2.sprite = spriteHitamPolos2;
            image3.sprite = spriteHitamPolos3;
            image4.sprite = spriteHitam4;
            tombolSFX = true;
        }
        else
        {
            dark4.SetActive(false);
        }

        if(save == angkaPutih3)
        {
            PlayerPrefs.SetInt("E", angkaPutih3);
            totalsave = PlayerPrefs.GetInt("E");
            angkaOddOrEven.text = "angka = " + totalsave;
        }

        if(totalsave == 3)
        {
            white3.SetActive(true);
            image1.sprite = spritePutihPolos1;
            image2.sprite = spritePutihPolos2;
            image3.sprite = spritePutih3;
            image4.sprite = spritePutihPolos4;
            tombolSFX = true;
        }
        else
        {
            white3.SetActive(false);
        }

    }

    public void gantiWarnaHitam()
    {
        theme = Hitam;
        temaBerapa = 2;
        PlayerPrefs.SetInt("tema", temaBerapa);
        save = angkaHitam;
    }
   
    public void gantiWarnaPutih()
    {
        theme = Putih;
        temaBerapa = 1;
        PlayerPrefs.SetInt("tema", temaBerapa);
        save = angkaPutih;
    }

    public void GantiWarnaPutih3()
    {
        theme = Putih3;
        temaBerapa = 3;
        PlayerPrefs.SetInt("tema", temaBerapa);
        save = angkaPutih3;
    }

    public void GantiWarnaHitam4()
    {
        theme = Hitam4;
        temaBerapa = 4;
        PlayerPrefs.SetInt("tema", temaBerapa);
        save = angkaHitam4;
    }
}
