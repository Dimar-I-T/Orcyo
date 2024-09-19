using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cerita : MonoBehaviour
{
    public GameObject story;
    public GameObject objective;
    public static bool Story;
    private bool Objective = false;

    public static int angka2;

    public void cerita()
    {
        story.SetActive(true);
        nyalamati2.aktifStory = true;
        Time.timeScale = 1;
        Story = true;
    }

}
