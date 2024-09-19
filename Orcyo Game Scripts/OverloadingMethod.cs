using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverloadingMethod : MonoBehaviour
{

    // digunakan untuk menjumlahkan dua angka diluar script maupun didalam script
    public int Penjumlahan(int nomor1, int nomor2)
    {
        return nomor1 + nomor2;
    }
}
