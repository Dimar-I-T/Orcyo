using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VooxControl : MonoBehaviour
{
    //Variabel Kecepatan
    [Tooltip("Kecepatan")]
    public static float kecepatan = 10f;
    float kanankiri = 0f;
    [SerializeField] private static float lompatan = 900f;

    //RigidBody2D
    [Tooltip("Rigidbody2D")]
    public Rigidbody2D rigid;

    //boolian
    bool flipp = true;

    //SmoothJump
    [Range(0f, 2.5f)]
    public float lompatTinggi;
    public float[] lompatRendah = { 0f, 1.5f, 2f, 3f };


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
      
    }

    
    void Update()
    {
        kanankiri = CrossPlatformInputManager.GetAxis("Horizontal") * kecepatan;

        /**if(rigid.velocity.y < 0)
        {
            rigid.velocity += Vector2.up * Physics2D.gravity.y * (lompatTinggi - 1) * Time.deltaTime;
        }
        else if(rigid.velocity.y > 0 && !CrossPlatformInputManager.GetButton("Jump"))
        {
            rigid.velocity += Vector2.up * Physics2D.gravity.y * (lompatRendah[2] - 1) * Time.deltaTime;
        }
        */
        
        //kanankiriflip
        if(kanankiri < 0 && !flipp)
        {
            flipping();
        }
        if(kanankiri > 0 && !flipp)
        {
            flipping();
        }

    }

    private void FixedUpdate()
    {
        
        transform.Translate(kanankiri * Time.fixedDeltaTime, 0, 0);

        if (CrossPlatformInputManager.GetButtonDown("Jump") && rigid.velocity.y == 0)
        {
            rigid.AddForce(Vector2.up * lompatan);
        }

    }

    private void flipping()
    {
        flipp = !flipp;

        Vector3 flip = transform.localScale;
        flip.x *= -1f;
        transform.localScale = flip;
    }
    

}



