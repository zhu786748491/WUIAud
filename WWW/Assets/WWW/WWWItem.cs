using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WWWItem{

    private string url;

    public string URL
    {
        get
        {
            return url;
        }
        set
        {
            url = value;
        }
    }

    public void StartDownload()
    {
        WWWHelper.Instance.AddTarget(this);
    }

    public virtual void BeginDownload()
    {

    }

    public virtual void DownloadFinish(WWW tmpWWW)
    {

    }

    public virtual void DownloadError(WWWItem tmpItem)
    {

    }

    public IEnumerator Download()
    {
        BeginDownload();

        WWW tmpWWW = new WWW(url);

        yield return tmpWWW;

        if(string.IsNullOrEmpty(tmpWWW.error))
        {
            DownloadFinish(tmpWWW);
        }
        else
        {
            DownloadError(this);
        }
    }
}
