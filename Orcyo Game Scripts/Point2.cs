using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point2 : MonoBehaviour
{
    public static int Points = 0;
    public GameObject baloklevel3;
    bool Baloklevel3 = false;

    void Update()
    {
        if(Points == 1)
        {
            Baloklevel3 = true;
            if (Baloklevel3)
            {
                baloklevel3.SetActive(true);
            }
            else
            {
                baloklevel3.SetActive(false);
            }
        }
    }
}
