using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundtrigger : MonoBehaviour
{

    public GameObject colider;
    private bool Collider;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Collider == true)
        {
            colider.SetActive(true);
        }
        else
        {
            colider.SetActive(false);
        }

        if (Collider == false)
        {
            colider.SetActive(false);
        }
        else
        {
            colider.SetActive(true);
        }
    }

    //// Collision Region
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "balok2")
        {
            Collider = true;
        }
        else
        {
            Collider = false;
        }
    }

    public void coliderfalse()
    {
        Collider = false;
        if (Collider == false)
        {
            colider.SetActive(false);
        }
        else
        {
            colider.SetActive(true);
        }
    }

    //// Trigger Region

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "balok")
        {
            FindObjectOfType<audiomanager>().Play("lompat");
        }
    }
   
}
