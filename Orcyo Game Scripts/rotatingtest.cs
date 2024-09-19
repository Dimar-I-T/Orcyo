using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatingtest : MonoBehaviour
{
    private float rotating;
    private float kecepatan = 10f;

    public void Start()
    {
        
    }

    public void Update()
    {
        if(rotating == 360f)
        {
            rotating = 0;
        }
        rotating = 150 * Time.deltaTime;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, rotating);
        gameObject.transform.Translate(0, kecepatan * Time.deltaTime, 0);
    }

}
