using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TambahEnergiAktif : MonoBehaviour
{
    public GameObject tombol;

    private void Start()
    {
        Invoke(nameof(Aktif), 2f);
    }

    private void Aktif()
    {
        tombol.SetActive(false);
    }
}
