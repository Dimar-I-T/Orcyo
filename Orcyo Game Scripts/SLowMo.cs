using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SLowMo : MonoBehaviour
{

    bool slow = true;

    private void Start()
    {
        Invoke(nameof(Normal), 11f);
    }

    private void Update()
    {
        if (slow) { Time.timeScale = 0.5f; }
        else if (!slow) { Time.timeScale = 1f; }
    }

    void Normal()
    {
        slow = false;
    }
}
