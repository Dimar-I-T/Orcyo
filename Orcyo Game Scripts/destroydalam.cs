using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroydalam : MonoBehaviour
{
    public float waktu;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, waktu);        
    }
}
