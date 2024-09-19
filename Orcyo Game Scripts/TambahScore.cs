using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TambahScore : MonoBehaviour
{
    public void scoreNambah()
    {
        tambahscore();
    }

    public void tambahscore()
    {
        totalscore.angka++;
        Destroy(gameObject, 1f);
    }
}
  