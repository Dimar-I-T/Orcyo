using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pintu : MonoBehaviour
{
    public static float kecepatan;
    public Transform target;
    public static int angka;
    public static int angka3;

    Vector3 Respawn;

    private void Start()
    {
        Respawn = transform.position;    
    }

    private void Update()
    {
        switch (angka)
        {
            case 1:
                transform.position = Respawn;
                kecepatan = 0;
                Invoke("angkaBalik", 0.1f);
                break;
        }

        switch (angka3)
        {
            case 1:
                transform.position = Respawn;
                kecepatan = 0;
                Invoke("angkaBalik", 0.1f);
                break;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            kecepatan = -2f;
        }

        transform.Translate(0, kecepatan * Time.deltaTime, 0);
        if (transform.position.y <= target.position.y)
        {
            kecepatan = 0f;
        }
    }

    void angkaBalik()
    {
        angka = 0;
        angka3 = 0;
    }
}
