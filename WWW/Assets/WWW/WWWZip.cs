using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WWWZip : WWWItem {

	public WWWZip (string tmpUrl)
    {
        this.URL = tmpUrl;
    }

    public override void DownloadFinish(WWW tmpWWW)
    {
        string tmpMiddlePath = Application.temporaryCachePath +"tmpZip.zip";

        //把所有下载回来的zip包 重新写入一个文件
        File.WriteAllBytes(tmpMiddlePath, tmpWWW.bytes);

        string persitPath = Application.persistentDataPath;

        
    }

    public override void DownloadError(WWWItem tmpItem)
    {
        WWWHelper.Instance.AddTarget(tmpItem);
    }
}
