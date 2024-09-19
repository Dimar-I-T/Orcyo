using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GantiWarna : MonoBehaviour
{
    SpriteRenderer sprite;
    public Animator animasi;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        switch (duaenergi.Energi)
        {
            case 0:
                sprite.color = Color.red;
                animasi.SetBool("nyala", false);
                break;
            default:
                sprite.color = Color.black;
                animasi.SetBool("nyala", true);
                break;
        } 
        
        switch (empatenergi.Energi)
        {
            case 0:
                sprite.color = Color.red;
                animasi.SetBool("nyala", false);
                break;
            default:
                sprite.color = Color.black;
                animasi.SetBool("nyala", true);
                break;
        }
    }
}
