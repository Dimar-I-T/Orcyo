using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Lompatan : MonoBehaviour
{
    public static float lompatan = 900f;

    private Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(CrossPlatformInputManager.GetButtonDown("Jump") && rigid.velocity.y == 0)
        {
            rigid.AddForce(Vector2.up * lompatan);
        }
    }
}

