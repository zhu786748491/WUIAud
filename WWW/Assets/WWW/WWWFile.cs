using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WWWFile : WWWItem{

    public WWWFile(string path)
    {
        InitialURL(path);
    }

	public void InitialURL(string tmpPath)
    {
        if(Application.platform ==RuntimePlatform.WindowsEditor ||Application .platform==RuntimePlatform.OSXEditor )
        {
            URL = "file:///" + Application.dataPath + "/" + tmpPath;
        }
        else if(Application.platform==RuntimePlatform.Android )
        {
            URL = "jar:file://" + Application.dataPath + "/" + tmpPath;
        }
        else if(Application.platform==RuntimePlatform.IPhonePlayer )
        {
            URL = "file://" + Application.dataPath + "/" + tmpPath;
        }
    }

    public override void DownloadError(WWWItem tmpItem)
    {
        WWWHelper.Instance.AddTarget(tmpItem);
    }

    public override void DownloadFinish(WWW tmpWWW)
    {
        Debug.Log(tmpWWW.text);
    }
}
