using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class rotating : MonoBehaviour
{
    public float Vrotasi;
    public static float VrotasiTambah;

    private void Start()
    {
    
    }

    private void Update()
    {
        transform.Rotate(0, 0, Vrotasi * Time.deltaTime);
    }
}
