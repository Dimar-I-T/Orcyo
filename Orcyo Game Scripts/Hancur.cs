﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hancur : MonoBehaviour
{
    public void Start()
    {
        Destroy(gameObject, 1f);
    }
}
