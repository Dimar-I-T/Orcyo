using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trail : MonoBehaviour
{
    private float waktuAntaraMuncul;
    public float waktuMulaiMuncul;

    public GameObject[] objekTrail;
    public static bool aktif = true;

    public TrailRenderer trail2;

    private void Update()
    {
        if (aktif == true)
            //trail2.startColor = Color.blue;
            //trail2.endColor = Color.black;
            if(MotionControl.motionNumber < 1)
            {
                trail2.time = 5;
            }else if(MotionControl.motionNumber == 1)
            {
                trail2.time = 0.5f;
            }
            if (waktuAntaraMuncul <= 0)
            {
                // Muncul
                int Acak = Random.Range(0, objekTrail.Length);
                GameObject spawn = (GameObject)Instantiate(objekTrail[Acak], transform.position, Quaternion.identity);
                Destroy(spawn, 0.26f);
                waktuAntaraMuncul = waktuMulaiMuncul;
            }
            else
            {
                waktuAntaraMuncul -= Time.deltaTime;
            }

        if(aktif == false)
        {
            //trail2.startColor = Color.red;
            //trail2.endColor = Color.black;
        }
    }
}
