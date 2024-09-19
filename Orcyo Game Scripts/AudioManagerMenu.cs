using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioManagerMenu : MonoBehaviour
{
    public Suara[] suara;

    public static AudioManagerMenu Audio;
    public static audiomanager audiolevel;

    public void Start()
    {
        Play("theme");
    }

    private void Awake()
    {
        foreach(Suara s in suara)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Suara s = Array.Find(suara, Suara => Suara.nama == name);
        s.source.Play();
    }
}
