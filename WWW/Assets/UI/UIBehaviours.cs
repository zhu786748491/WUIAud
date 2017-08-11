using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIBehaviours : MonoBehaviour {

    UIBase tmpBase;

    // Use this for initialization
    void Awake () {
        tmpBase = gameObject.GetComponentInChildren<UIBase>();

        UIManager.Instance.RegistGameObject(tmpBase.name, transform.name, gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddButtonListener(UnityAction action )
    {
        Button tmpButton = GetComponent<Button>();

        if(tmpButton != null)
        {
            tmpButton.onClick.AddListener(action);
        }
    }

    public void AddInputEditorEndListener(UnityAction<string> action)
    {
        InputField tmpInputField = GetComponent<InputField >();

        if(tmpInputField != null)
        {
            tmpInputField.onEndEdit.AddListener(action);
        }
    }

    public void AddSliderListener(UnityAction <float> action)
    {
        Slider tmpSlider = GetComponent<Slider >();

        if (tmpSlider != null)
        {
            tmpSlider.onValueChanged.AddListener(action);
        }
    }

    public void AddToggleListener(UnityAction <bool > action)
    {
        Toggle tmpToggle = GetComponent<Toggle >();

        if (tmpToggle != null)
        {
            tmpToggle.onValueChanged.AddListener(action);
        }
    }

    public void OnDestroy()
    {
        UIManager.Instance.UnRegistGameObject(tmpBase.name, transform.name);
    }

    /// <summary>
    /// 动态添加接口事件回掉
    /// </summary>
    /// <param name="action"></param>
    public void AddButtonDownListener(UnityAction <BaseEventData > action)
    {
        EventTrigger trigger = gameObject.GetComponent<EventTrigger>();

        if(trigger ==null)
        {
            trigger = gameObject.AddComponent<EventTrigger>();
        }
        EventTrigger.Entry entry = new EventTrigger.Entry();

        entry.eventID = EventTriggerType.PointerClick;

        entry.callback = new EventTrigger.TriggerEvent();

        entry.callback.AddListener(action);

        trigger.triggers.Add(entry);
    }
}
