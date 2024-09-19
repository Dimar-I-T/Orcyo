using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Suara
{
    public string nama;

    public AudioClip clip;

    [Range(0f, 2f)]
    public float volume;
    [Range(1f, 3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
