using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cerita2 : MonoBehaviour
{

    public GameObject story;
    
    public void Cerita()
    {
        story.SetActive(true);
        Time.timeScale = 1;
    }

    public void Lanjut(bool lanjut)
    {
        if (lanjut)
            story.SetActive(false);
        else { story.SetActive(true); return; }
        Time.timeScale = 1;
    }

}
