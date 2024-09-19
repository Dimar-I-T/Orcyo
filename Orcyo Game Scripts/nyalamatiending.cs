using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nyalamatiending : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;

    public GameObject tombol;
    public GameObject story;

    bool Text1;
    public static bool Story;

    private void Start()
    {
        Invoke("Ganti", 16f);
        Invoke("Tetap", 18f);
        Invoke("Tombol", 20f);
        Invoke("Keluar", 59f);
    }

    public void Ganti()
    {
        if (Text1)
        {
            Text1 = true;
            text1.SetActive(true);
            text2.SetActive(false);
        }
        else
        {
            Text1 = false;
            text1.SetActive(false);
            text2.SetActive(true);
        }
    }

    public void Tetap()
    {
        text1.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(true);

    }

    public void Tombol()
    {
        tombol.SetActive(true);
    }

    public void Lanjut()
    {
        story.SetActive(false);
        Time.timeScale = 1;
        Story = false;
    }

    public void Keluar()
    {
        SceneManager.LoadScene(1);
    }

}
