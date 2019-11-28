using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    // Lista med Sound typer
    public List<Sound> sounds;

    //Awake så att allting initieras innan spelet bärjar
    private void Awake()
    {

        // För varje sound i sounds: 
        // lägg till en AudioSource component och gör AudioSourcens clip, volume, pitch 
        // lika med Sound instansens (det som man sätter in i editorn)
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
        }
    }

    // Hitta ett sound i sounds som har namnet man skriver in och om det finns, spela det
    public void Play(string name)
    {
        Sound s = sounds.Find(sound => sound.name.Contains(name));

        if (s != null)
        {
            s.source.Play();
        }
    }
}