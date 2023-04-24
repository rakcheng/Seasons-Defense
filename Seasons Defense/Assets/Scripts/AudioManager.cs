using UnityEngine.Audio;
using UnityEngine;
using System;
public class AudioManager : MonoBehaviour
{
    public Audio[] sounds;

    private void Awake()
    {
        foreach (Audio s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }
    }

    private void Start()
    {
        // Here you play the backround song of the scene or the theme that will loop
        // Play("Background Song");
    }

    public void Play(string name)
    {
        Audio s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            return;
        }

        s.source.Play();
    }

}
