using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleMovement : MonoBehaviour
{
    public Transform pusatRotasi;

    public float rotasiDiameter = 2f;
    public float kecepatanSudut = 2f;

    public float posX, posY, sudut = 0f;

    private void Update()
    {
        posX = pusatRotasi.position.x + Mathf.Cos(sudut) * rotasiDiameter;
        posY = pusatRotasi.position.y + Mathf.Sin(sudut) * rotasiDiameter;
        transform.position = new Vector2(posX, posY);
        sudut = sudut + Time.fixedDeltaTime * kecepatanSudut;

        if(sudut >= Mathf.PI*2)
        {
            sudut = 0;
        }
    }
}
