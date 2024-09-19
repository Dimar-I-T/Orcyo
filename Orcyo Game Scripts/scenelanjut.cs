using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenelanjut : MonoBehaviour
{
    private void Start()
    {
        Invoke("lanjut", 1f);
    }

    public void lanjut()
    {
        SceneManager.LoadScene(2);
    }
}

