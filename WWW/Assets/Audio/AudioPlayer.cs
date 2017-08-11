using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {

    public static AudioPlayer Instance;

    ClipsManager clipManager;

    AudioManager audioManager;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        clipManager = new ClipsManager();
        audioManager = new AudioManager(gameObject );
    }

    public void Play(string tmpName)
    {
        AudioSource tmpSource = audioManager.GetFreeAudioSources();

        clipManager.PlayAudio(tmpName, tmpSource);
    }

    public void Stop(string tmpName)
    {
        clipManager.StopAudio(tmpName);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown (0))
        {
            Play("DaAo_2");
        }
        if(Input.GetMouseButtonDown (1))
        {
            Stop("DaAo_2");
        }
    }
}
