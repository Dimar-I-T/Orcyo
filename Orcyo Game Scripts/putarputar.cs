using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class putarputar : MonoBehaviour
{
    public Transform pusatRotasi;

    public float rotasiDiameter;
    private float kecepatanSudut = 0;

    [Range(0f, 10f)]
    public float tambahKecepatan;

    [Range(0f, 10f)]
    public float waktu;

    public float posisiX, posisiY, sudut;

    private void Start()
    {
        Invoke("kecepatansudut", waktu);
    }

    private void Update()
    {
        posisiX = pusatRotasi.position.x + Mathf.Cos(sudut) * rotasiDiameter;
        posisiY = pusatRotasi.position.y + Mathf.Sin(sudut) * rotasiDiameter;

        transform.position = new Vector2(posisiX, posisiY);

        sudut = sudut + Time.deltaTime * kecepatanSudut;

        if(sudut >= Mathf.PI * 2)
        {
            sudut = 0f;
        }
    }

    public void kecepatansudut()
    {
        kecepatanSudut = tambahKecepatan;
    }
}