using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiomanagerending : MonoBehaviour
{
    public Suara[] sound;

    public void Start()
    {
        Play("theme");
    }

    private void Awake()
    {
        foreach(Suara s in sound)
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
        Suara s = Array.Find(sound, Suara => Suara.nama == name);
        s.source.Play();
    }
}
