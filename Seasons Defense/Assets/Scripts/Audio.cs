using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Audio
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float pitch;
    [Range(0.1f, 3f)]
    public float volume;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
