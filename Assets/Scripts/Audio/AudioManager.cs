using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    // Awake is called upon load
    void Awake()
    {
        if (instance == null){
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }

        foreach (Sound s in sounds)
        {
            // get source from the AudioManager
            s.source = gameObject.AddComponent<AudioSource>();

            // set the clip attributes in Sound s to equal the attributes stored in Sound s
            s.source.clip = s.clip;
            s.source.volume = s.volume / 100;
            s.ogVolume = s.source.volume;
            s.source.pitch = 1f;

            s.source.loop = s.loop;
            s.source.spatialBlend = s.spatialBlend;

        }
    }

    // public in case we need to call this from other gameObjects (ie: during a mini-game)
    public void Play(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        print("playing: " + name);
        if(s == null){
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void ChangeVolume(string name, float volume)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        print(name + " volume bumped down from " + s.volume + " to " + volume);
        s.source.volume = volume / 100f;
    }

    public void OriginalVolume(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        print(name + " volume returned to " + (s.ogVolume * 100) + " from " + s.volume);
        s.source.volume = s.ogVolume;
    }

}
