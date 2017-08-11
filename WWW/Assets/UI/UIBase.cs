using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIBase : MonoBehaviour {

    public void AddComponentToChild()
    {
        Transform[] childTrans = transform.GetComponentsInChildren<Transform>();

        for (int i = 0; i < childTrans.Length; i++)
        {
            childTrans[i].gameObject.AddComponent<UIBehaviours>();
        }
    }

    

    /// <summary>
    /// 针对 自身的
    /// </summary>
    /// <param name="isShow"></param>
    public void ShowOrHiddenPanelChild(bool isShow)
    {
        ShowOrHiddenPanelChild(gameObject, isShow);
    }
    /// <summary>
    /// 针对任意的
    /// </summary>
    /// <param name="tmpObj"></param>
    /// <param name="isShow"></param>
    public void ShowOrHiddenPanelChild(GameObject tmpObj, bool isShow)
    {
        Transform[] childTrans = tmpObj.transform.GetComponentsInChildren<Transform>();

        for (int i = 0; i < childTrans.Length; i++)
        {
            childTrans[i].gameObject.SetActive(isShow);
        }
    }

    public GameObject GetGameObject(string panelName,string childName)
    {
        GameObject tmpObj = UIManager.Instance.GetGameObject(panelName, childName);
        return tmpObj;
    }

    public GameObject GetGameObject(string childName)
    {
        GameObject tmpObj = GetGameObject(transform.name, childName);
        return tmpObj;
    }

    public UIBehaviours GetBehaviours(string childName)
    {
        GameObject tmpObj = GetGameObject(childName);

        UIBehaviours uiBeaviours = tmpObj.GetComponent<UIBehaviours>();

        return uiBeaviours;
    }

    public void AddButtonListener(string childName,UnityAction action)
    {
        UIBehaviours tmpBehaviours = GetBehaviours(childName);

        if(tmpBehaviours !=null)
        {
            tmpBehaviours.AddButtonListener(action);
        }
    }

    public void AddSliderListener(string childName,UnityAction<float> action)
    {
        UIBehaviours tmpBehaviours = GetBehaviours(childName);

        if (tmpBehaviours != null)
        {
            tmpBehaviours.AddSliderListener(action);
        }
    }

    void OnDestory()
    {
        UIManager.Instance.UnRegistPanel(transform.name);

        //UIManager.Instance.UnRegistGameObject(tmpBase.name, transform.name);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
