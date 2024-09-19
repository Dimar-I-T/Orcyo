using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotasi2 : MonoBehaviour
{
    public float Vrotasi;

    private void Update()
    {
        transform.Rotate(0, 0, -Vrotasi * Time.deltaTime);
    }
}
