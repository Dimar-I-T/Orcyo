using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneloader : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(2);
        FindObjectOfType<audiomanager>().Resume("theme");
    }

    public void Quit()
    {
        Application.Quit();
        //SaveSystem.SavePlayer(totalscore.dataPemain);
    }
   
    public void tombolSFX()
    {
        FindObjectOfType<AudioManagerMenu>().Play("tombol");
    }
}
