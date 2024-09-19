using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keteken : MonoBehaviour
{
    public static bool aktif = false;
    public static float targetbawah;
    public static int angka;
    public static int angka3;
    public static bool warna = false;

    private SpriteRenderer sprite;

    Vector3 respawn;

    public void Start()
    {
        respawn = transform.position;
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        switch (angka)
        {
            case 1:
                transform.position = respawn;
                Invoke("angkaBalik", 0.1f);
                break;
        }

        switch (angka3)
        {
            case 1:
                transform.position = respawn;
                Invoke("angkaBalik", 0.1f);
                break;
        }

        if(aktif == true)
        {
            Vector3 posisi = transform.position;
            posisi.y = targetbawah;
            transform.position = posisi;
        }

        if(aktif == false)
        {
            transform.position = respawn;
        }

        if (warna)
        {
            sprite.color = Color.red;
            Invoke("hancur", 2f);
        }else if (!warna)
        {
            sprite.color = Color.green;
        }
       
    }

    void angkaBalik()
    {
        angka = 0;
    }

    public void hancur()
    {
        Destroy(gameObject);
    }
}
