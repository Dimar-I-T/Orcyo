using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audiomanager : MonoBehaviour
{
    public Suara[] sounds;

    public static audiomanager audioLevel;
    public static AudioManagerMenu audioMenu;

    public void Start()
    {
        Play("theme");
    }

    public void Awake()
    {
        if (audioLevel == null)
            audioLevel = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        
        foreach (Suara s in sounds)
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
        Suara s = Array.Find(sounds, Sound => Sound.nama == name);
        s.source.Play();
    }

    public void Stop(string name)
    {
        Suara s = Array.Find(sounds, Sound => Sound.nama == name);

        s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volume / 2f, s.volume / 2f));
        s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitch / 2f, s.pitch / 2f));
        s.source.Stop();
    }

    public void Pause(string name)
    {
        Suara s = Array.Find(sounds, Suara => Suara.nama == name);

        s.source.Pause();
    }

    public void Resume(string name)
    {
        Suara s = Array.Find(sounds, Suara => Suara.nama == name);
        s.source.UnPause();
    }

    public void Kecilin(int volume)
    {
        foreach(Suara s in sounds)
        {
            s.source.volume = s.volume;
            s.volume -= volume;
        }
    }
    public void Besarin(int volume)
    {
        foreach(Suara s in sounds)
        {
            s.source.volume = s.volume;
            s.volume += volume;
        }
    }
}
