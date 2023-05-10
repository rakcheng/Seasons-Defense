using UnityEngine.Audio;
using UnityEngine;
using System;
public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;
    public Audio[] sounds;

    private void Awake()
    {
        Instance = this;
      
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
        Play("Background");
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
