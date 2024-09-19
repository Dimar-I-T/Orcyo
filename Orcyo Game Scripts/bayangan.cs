using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bayangan : MonoBehaviour
{

    public SpriteRenderer bayangan1;
    public SpriteRenderer bayangan2;
    public SpriteRenderer bayangan3;
    public SpriteRenderer bayangan4;
    private bool gantiWarna = false;

    private void Update()
    {
        if (gantiWarna)
        {
            bayangan1.color = Color.blue;
            bayangan1.color.a.Equals(40f);
        }
        else if (!gantiWarna)
        {
            bayangan1.color = Color.black;
            _ = bayangan1.color.a;
            return;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bayangan"))
        {
            gantiWarna = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bayangan"))
        {
            gantiWarna = false;
        }
    }
}
