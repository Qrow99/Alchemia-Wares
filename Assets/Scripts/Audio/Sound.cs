using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    public bool playOnAwake;
    public bool loop;

    [Range(0f, 100f)]
    public float volume = 50f;


    [Range(0.1f, 3f)]
    public float pitch;

    [Range(0f, 1f)]
    public float spatialBlend;

    [HideInInspector]
    public AudioSource source;
    [HideInInspector]
    public float ogVolume;
}
