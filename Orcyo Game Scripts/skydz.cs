using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skydz : MonoBehaviour
{
    
    void Update()
    {
        Invoke("scenelanjut", 4f);
    }

    public void scenelanjut()
    {
        SceneManager.LoadScene(1);
    }
}
