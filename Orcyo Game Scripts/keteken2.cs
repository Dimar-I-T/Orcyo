using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keteken2 : MonoBehaviour
{
    public static float targetBawah;
    public static bool aktif = false;
    public static bool hancur = false;
    public static int angka;
    public static int angka3;
    Vector3 Respawn;

    private BoxCollider2D coll;
    private SpriteRenderer sprite;

    private void Start()
    {
        Respawn = transform.position;
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        switch (angka)
        {
            case 1:
                transform.position = Respawn;
                Invoke("angkabalik", 0.1f);
                break;
        }

        switch (angka3)
        {
            case 1:
                transform.position = Respawn;
                Invoke("angkabalik", 0.1f);
                break;
        }

        if(aktif == true)
        {
            Vector3 posisi = transform.position;
            posisi.y = targetBawah;
            transform.position = posisi;
        }

        if (aktif == false)
        {
            transform.position = Respawn;
        }

        if (hancur)
        {
            coll.isTrigger = false;
            sprite.color = Color.black;
            Destroy(gameObject, 2f);
        }
    }

    void angkabalik()
    {
        angka = 0;
        angka3 = 0;
    }
}
