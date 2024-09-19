using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerBalok : MonoBehaviour
{
    public GameObject Balok;

    private void Update()
    {
        if(gerakan.Angkajatuh == 1)
        {
            spawner();
        }
    }

    private void spawner()
    {
        Instantiate(Balok, transform.position, transform.rotation);
    }
}
