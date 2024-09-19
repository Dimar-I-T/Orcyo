using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXEnergiHabis : MonoBehaviour
{
    SFXEnergiHabis sfxE;

    private void Awake()
    {
        if (sfxE == null)
            sfxE = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
}
