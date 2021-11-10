using UnityEngine.Audio;
using UnityEngine;

public class Sound
{
    public string name;
    public AudioClip clip;

    public bool playOnAwake;
    public bool loop;

    [Range(0f, 100f)]
    public float volume;
    [Range(0f, 3f)]
    public float pitch;

    [Range(0f, 1f)]
    public float spatialBlend;

    [HideInInspector]
    public AudioSource source;
}
