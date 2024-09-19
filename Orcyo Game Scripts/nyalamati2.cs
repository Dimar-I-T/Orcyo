using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nyalamati2 : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text3tetap;
    public GameObject tombol;
    public GameObject story;

    private bool Text1;
    private bool Text2;
    private bool Text3;

    public static bool aktifStory = true;

    private void Start()
    {
        summonText1();
        Invoke("summonText2", 5f);
        Invoke("summonText3", 10f);
        Invoke("Tetap", 11f);
        Invoke("Tombol", 13f);
        Invoke("lanjut", 60f);
    }

    private void Update()
    {
        if (Text1 == true)
        {
            text1.SetActive(true);
            text2.SetActive(false);
            text3.SetActive(false);
        }
        else
        {
            text1.SetActive(false);
        }

        if(Text2 == true)
        {
            text2.SetActive(true);
            text1.SetActive(false);
            text3.SetActive(false);
        }
        else
        {
            text2.SetActive(false);
        }

        if (Text3)
        {
            text3.SetActive(true);
            text2.SetActive(false);
            text1.SetActive(false);
        }
        else
        {
            text3.SetActive(false);
        }

        if (aktifStory)
        {
            story.SetActive(true);
        }else if (!aktifStory)
        {
            story.SetActive(false);
        }
    }

    void summonText1()
    {
        Text1 = true;
    }

    void summonText2()
    {
        Text2 = true;
        Text1 = false;
        Text3 = false;
    }

    void summonText3()
    {
        Text3 = true;
        Text2 = false;
        Text1 = false;
    }
     
    void Tetap()
    {
        text3tetap.SetActive(true);
        Text1 = false;
        Text2 = false;
        Text3 = false;
    }

    void Tombol()
    {
        tombol.SetActive(true);
    }

    public void lanjut()
    {
        FindObjectOfType<Cerita2>().Lanjut(true);
    }

    public void Lanjut()
    {
        aktifStory = false;
    }

}
