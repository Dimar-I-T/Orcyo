using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matidalam7 : MonoBehaviour
{
    private void Start()
    {
        Invoke(nameof(mati), 7f);
    }

    void mati()
    {
        gameObject.SetActive(false);
    }
}
