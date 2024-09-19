using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool PauseObject;

    private void Update()
    {
        if (PauseObject)
        {
            Pause();
        }
        else
        {
            Lanjut();
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        PauseObject = true;
    }

    public void Lanjut()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseObject = false;
    }
}
