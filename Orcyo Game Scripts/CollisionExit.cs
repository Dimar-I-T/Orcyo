using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CollisionExit : MonoBehaviour
{
    public Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(CrossPlatformInputManager.GetButton("Jump") && rigid.velocity.y == 0)
        {
            rigid.velocity = Vector2.up * gerakan.lompatVelo;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "balok")
        {
            FindObjectOfType<audiomanager>().Play("lompat");
        }
    }
}
