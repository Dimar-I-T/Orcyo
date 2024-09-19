using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class effectJatuh : MonoBehaviour
{
    public GameObject particle;
    public Transform spawner;
    public static bool aktif = false;
    private bool vignetteAktif;

    //public Animator animVig;

    private void Start()
    {
        ///animVig.SetBool("Aktif", false);
    }

    private void Update()
    {
        if(vignetteAktif == true)
        {
            //vignette.localScale = new Vector3(1, 1, 1);
            //animVig.SetBool("Aktif", true);
        }else if(vignetteAktif == false)
        {
            //vignette.localScale = new Vector3(0, 0, 0);
            //animVig.SetBool("Aktif", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("balok"))
        {
            Spawn();
           // VignetteAktif();
           // Invoke(nameof(VignetteTidakAktif), 0.4f);
            if(aktif == false)
            {
                FindObjectOfType<audiomanager>().Play("collision");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("balokrotate"))
        {
            Spawn();
          //  VignetteAktif();
          //  Invoke(nameof(VignetteTidakAktif), 0.4f);
            if (aktif == false)
            {
                FindObjectOfType<audiomanager>().Play("collision");
            }
        }
    }

    public void Spawn()
    {
        Instantiate(particle, spawner.position, spawner.rotation);
    }

    public void VignetteAktif()
    {
        vignetteAktif = true;
    }

    public void VignetteTidakAktif()
    {
        vignetteAktif = false;
    }
}
