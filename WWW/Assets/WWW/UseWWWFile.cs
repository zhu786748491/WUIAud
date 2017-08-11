using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseWWWFile : MonoBehaviour {

	void Start()
    {
        WWWFile tmpFile = new WWWFile("test.txt");

        tmpFile.StartDownload();
    }
}
