using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipsManager {

    private string[] clipsName;

    SingleClips[] clips;

    public ClipsManager ()
    {
        Initial();
    }

	public void Initial()
    {
        clipsName = new string[]
        {
            "DaAo",
            "DaAo_2",//一般从配置文件里或者数据库里读取
            "DaAo_3"
        };

        clips = new SingleClips[clipsName.Length];

        for (int i = 0; i < clipsName.Length ; i++)
        {
            AudioClip tmpClip = Resources.Load<AudioClip>("Audio/" + clipsName[i]);

            clips[i] = new SingleClips(tmpClip);
        }
    }

    public int FindClips(string audioName)
    {
        for (int i = 0; i < clipsName.Length; i++)
        {
            if(clipsName [i]==audioName )
            {
                return i;
            }
        }
        return -1;
    }

    public void StopAudio(string audioName)
    {
        int tmpIndex = FindClips(audioName);

        if(tmpIndex!=-1)
        {
            clips[tmpIndex].Stop();
        }
    }

    public void PlayAudio(string audioName,AudioSource tmpSource)
    {
        int tmpIndex = FindClips(audioName);

        if(tmpIndex !=-1)
        {
            clips[tmpIndex].Play(tmpSource);
        }
    }
}
