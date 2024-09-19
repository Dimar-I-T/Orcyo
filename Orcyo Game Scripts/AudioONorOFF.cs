using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioONorOFF : MonoBehaviour
{
    public static bool Mute = false;
    public static int angka;
    public static int totalAngka;
    public static int angkaSementara;

    // UnMuted
    public GameObject On;

    // Muted
    public GameObject Off;

    private string key = "AUDIO";

    private void Start()
    {
        angkaSementara = PlayerPrefs.GetInt(key);
        angkaSementara = totalAngka;
    }

    private void Update()
    {
        // Mute or not
        if (Mute)
            FindObjectOfType<audiomanager>().Pause("theme");
        else if (!Mute)
        {
            FindObjectOfType<audiomanager>().Resume("theme");
        }

        PlayerPrefs.SetInt(key, angkaSementara);
        if(angka > totalAngka)
        {
            PlayerPrefs.SetInt(key, angka);
        }

        switch (angka)
        {
            case 1:
                On.SetActive(true);
                Off.SetActive(false);
                break;
            case 2:
                On.SetActive(false);
                Off.SetActive(true);
                break;
            default:
                On.SetActive(true);
                Off.SetActive(false);
                break;
        }
    }
}
