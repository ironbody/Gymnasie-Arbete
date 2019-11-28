using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    //Namnet på sounds instansen
    public string name;

    // Själva ljudfilen som ska spelas
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;

    [Range(0f, 4f)]
    public float pitch;

    // AudioSource komponenten i unity som används när man ska spela ett ljud
    [HideInInspector]
    public AudioSource source;

}