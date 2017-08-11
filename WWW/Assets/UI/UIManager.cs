using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public static UIManager Instance;

    //哪一个panel                //每一个panel里的子控件
    Dictionary<string, Dictionary<string, GameObject>> sonNumbers;

    public void RegistGameObject(string panelName,string objName,GameObject tmpObj)
    {
        if(sonNumbers.ContainsKey (panelName ))
        {
            sonNumbers[panelName].Add(objName, tmpObj);
        }
        else
        {
            Dictionary<string, GameObject> tmpDict = new Dictionary<string, GameObject>();

            tmpDict.Add(objName, tmpObj);

            sonNumbers.Add(panelName, tmpDict);
        }
    }

    public void UnRegistGameObject(string panelName, string objName)
    {
        if (sonNumbers.ContainsKey(panelName))
        {
            sonNumbers[panelName].Remove(objName);
        }
        
    }

    public void UnRegistPanel(string panelName)
    {
        if (sonNumbers.ContainsKey(panelName))
        {
            sonNumbers[panelName].Clear();
        }
    }

    public GameObject GetGameObject(string panelName,string objName)
    {
        if (sonNumbers[panelName].ContainsKey(objName))
        {
            return sonNumbers[panelName][objName];
        }
        return null;
    }

    void Awake()
    {
        Instance = this;
        sonNumbers = new Dictionary<string, Dictionary<string, GameObject>>();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
