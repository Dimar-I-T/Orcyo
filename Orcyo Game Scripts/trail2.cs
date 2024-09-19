using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trail2 : MonoBehaviour
{
    private float waktuAntaraMuncul;
    public float waktuMuncul;

    public GameObject[] trails;

    public static bool aktif = true;

    public TrailRenderer trails2;
    
    private void Update()
    {
        if(aktif == true)
        {
            trails2.startColor = Color.white;
            trails2.endColor = Color.black;
            if (waktuAntaraMuncul <= 0)
            {
                int acak = Random.Range(0, trails.Length);
                GameObject objek = (GameObject)Instantiate(trails[acak], transform.position, Quaternion.identity);
                Destroy(objek, 0.26f);
                waktuAntaraMuncul = waktuMuncul;
            }
            else
            {
                waktuAntaraMuncul -= Time.deltaTime;
            }
        }else if(aktif == false)
        {
            // () \\
            return;
        }
    }
}
