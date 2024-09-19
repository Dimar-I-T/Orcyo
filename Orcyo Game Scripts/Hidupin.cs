using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hidupin : MonoBehaviour
{
    public GameObject YougotBadge;
    
    private void Update()
    {
        if (nyalamati2.aktifStory == false)
        {
            YougotBadge.SetActive(true);
            Invoke(nameof(mati), 7f);
        }
        else if (nyalamati2.aktifStory == true)
            YougotBadge.SetActive(false);

        return;
    }

    void mati()
    {
        gameObject.SetActive(false);
    }

}
