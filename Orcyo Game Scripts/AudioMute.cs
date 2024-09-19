using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMute : MonoBehaviour
{
    public void Mute()
    {
        // Mute
        AudioONorOFF.Mute = true;
        AudioONorOFF.angka = 2;
        AudioONorOFF.angkaSementara = 2;
    }
}
