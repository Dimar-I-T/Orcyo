using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kalokenahancur : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("voox"))
        {
            Destroy(gameObject, 5f);
        }
    }
}
