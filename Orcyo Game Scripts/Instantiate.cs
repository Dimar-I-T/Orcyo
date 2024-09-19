using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public GameObject BA;
    public GameObject BK;

    public Transform BATrans;
    public Transform BKTrans;

    public void BayanganAtas()
    {
        /*var BAt = Instantiate(BA);
        BAt.transform.parent = GameObject.Find("ba").transform;*/
        if (satuenergi.Energi > 0 || duaenergi.Energi > 0 || empatenergi.Energi > 0)
        {
            Instantiate(BA, BATrans.parent);
        }
    }

    public void BayanganKanan()
    {
        /*var BKt = Instantiate(BK);
        BKt.transform.parent = GameObject.Find("bk").transform;*/
        if (satuenergi.Energi > 0 || duaenergi.Energi > 0 || empatenergi.Energi > 0)
        {
            Instantiate(BK, BKTrans.parent);
        }
    }
}
