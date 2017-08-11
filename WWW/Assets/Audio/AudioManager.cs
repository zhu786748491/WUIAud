using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager {

    List<AudioSource> sourceList;

    GameObject ower;

    public AudioManager (GameObject tmpOwer)
    {
        ower = tmpOwer;
        Initial();
    }

    public void Initial()
    {
        sourceList = new List<AudioSource>();

        for (int i = 0; i < 3; i++)
        {
            AudioSource tmpSources = ower.AddComponent<AudioSource>();

            sourceList.Add(tmpSources);
        }
    }

    public AudioSource GetFreeAudioSources()
    {
        for (int i = 0; i < sourceList .Count; i++)
        {
            AudioSource tmpSource = sourceList[i];

            if(!tmpSource.isPlaying )
            {
                return tmpSource;
            }
        }

        AudioSource tmpSources = ower.AddComponent<AudioSource>();

        sourceList.Add(tmpSources);

        return tmpSources;
    }


    public void ClearFree()
    {
        int tmpCount = 0;

        for (int i = 0; i < sourceList.Count; i++)
        {
            AudioSource tmpSource = sourceList[i];

            if(!tmpSource.isPlaying )
            {
                tmpCount++;

                if (tmpCount > 2)
                {
                    sourceList.Remove(tmpSource);
                }
            }

            
        }


    }
}
