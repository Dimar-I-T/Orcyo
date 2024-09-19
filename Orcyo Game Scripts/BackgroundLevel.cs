using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundLevel : MonoBehaviour
{
    public static string HexaDecimalBackground;
    private float h = 227f;
    private float s;
    private float v = 100f;
    private SpriteRenderer penampilan;

    public void Start()
    {
        penampilan = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
    }
}
