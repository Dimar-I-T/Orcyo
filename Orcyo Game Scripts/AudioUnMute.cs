using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioUnMute : MonoBehaviour
{
    public void UnMute()
    {
        // UnMute
        AudioONorOFF.Mute = false;
        AudioONorOFF.angka = 1;
        AudioONorOFF.angkaSementara = 1;
    }
}
