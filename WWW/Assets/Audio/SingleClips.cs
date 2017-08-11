using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleClips {

    AudioClip clip;

    AudioSource source;

    public SingleClips (AudioClip tmpClip)
    {
        clip = tmpClip;
    }

    public void Play(AudioSource tmpSource)
    {
        source = tmpSource;

        source.clip = clip;

        source.Play();
    }

    public void Stop()
    {
        if(source !=null)
        {
            source.Stop();
        }
    }
}
