using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;
    
    // Awake is called on load
    void Awake()
    {
        if(instance == null) { 
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }

        foreach(Sound s in sounds){
            // get source from AudioManager
            s.source = gameObject.AddComponent<AudioSource>();

            // set the sound of the AudioSource to the settings in Unity
            s.source.clip = s.clip;
            s.source.volume = s.volume / 100;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.spatialBlend = s.spatialBlend;
        }
    }

    // public in case we need to call this from other gameObjects (ie: during a mini-game)
    public void Play(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null){
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

}
