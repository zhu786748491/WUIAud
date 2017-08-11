using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WWWHelper : MonoBehaviour {

    public static WWWHelper Instance;

    Queue<WWWItem> download;

    bool isDownloadFinish;

    public void AddTarget(WWWItem tmpItem)
    {
        download.Enqueue(tmpItem);

        if(isDownloadFinish )
        {
            StartCoroutine(DownloadQueue());
        }

    }
    
    public IEnumerator DownloadQueue()
    {
        isDownloadFinish = false;

        while (download .Count >0)
        {
            WWWItem tmpItem = download.Dequeue();

            yield return tmpItem.Download();
        }

        isDownloadFinish = true;
    }

    void Start()
    {
        Instance = this;
        download = new Queue<WWWItem>();
        isDownloadFinish = true;
    }
}
