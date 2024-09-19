using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kalokitajatuhdiabakanspawnlagi : MonoBehaviour
{
    public Vector3 respawnBalok;
    public static int angka = 0;
    public static int angka2 = 0;
    
    private SpriteRenderer sprite;
   
    public Rigidbody2D rigid;

    private bool matinyala = true;

    private void Start()
    {

        sprite = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        respawnBalok = transform.position;
        
    }

    private void Update()
    {
        if(matinyala == true)
        {
            gameObject.SetActive(true);
        }
        if(matinyala == false)
        {
            gameObject.SetActive(false);
        }

        if (angka2 == 1)
        {
            sprite.color = Color.white;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("voox"))
        {
            sprite.color = Color.red;
        }
    }

}
