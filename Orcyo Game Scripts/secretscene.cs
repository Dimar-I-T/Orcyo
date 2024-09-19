using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class secretscene : MonoBehaviour
{
    public static int angka;

    public void nambah()
    {
        angka++;
    }

    public void nambah2()
    {
        Cerita.angka2++;
    }

    private void Update()
    {
        if(angka == 10)
        {
            SceneManager.LoadScene(52);
            angka -= 10;
        }
        if (Cerita.angka2 == 11)
        {
            SceneManager.LoadScene(53);
            Cerita.angka2 -= 11;
        }
    }
}
