using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point : MonoBehaviour
{
    public static int Points = 0;

    // gameObject
    public GameObject baloklevel2;
  

    // boolian
    bool Baloklevel2 = false;
    
    private void Update()
    {
        if(Points == 1)
        {
            Baloklevel2 = true;
            if (Baloklevel2)
            {
                baloklevel2.SetActive(true);
            }
            else
            {
                baloklevel2.SetActive(false);
            }
        }
    }

}
