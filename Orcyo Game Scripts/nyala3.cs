using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nyala3 : MonoBehaviour
{
    public GameObject Panel;
    public static bool aktif = false;
   
    private void Start()
    {
        Invoke(nameof(Nyala), 11f);
    }

    private void Update()
    {
        if (aktif)
        {
            Panel.SetActive(true);
        }
        else if (!aktif)
            Panel.SetActive(false);
    }

    void Nyala()
    {
        aktif = true;
    }
}
