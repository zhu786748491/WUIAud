using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLoadingCtr
{

    UIBase owerMono;

    public TestLoadingCtr (UIBase tmpMono)
    {
        owerMono = tmpMono;
    }

    public void SliderValue(float tmpValue)
    {

    }

    public void RegistButtonClick()
    {
        //owerMono.ShowOrHiddenPanelChild(false);

        owerMono.gameObject.SetActive(false);

        Object tmpObj = Resources.Load("UI/Regist");

        GameObject tmpGameObj = GameObject.Instantiate(tmpObj) as GameObject;

        tmpGameObj.name = tmpGameObj.name.Replace("(Clone)", "");

        GameObject canvas = GameObject.FindGameObjectWithTag("MainCanvas");

        tmpGameObj.transform.SetParent(canvas.transform ,false);

        tmpGameObj.AddComponent<TestRegist>();

    }
}

public class TestLoading : UIBase {

    TestLoadingCtr loadCtr;

    void Awake()
    {
        AddComponentToChild();
    }
	void Start () {


        loadCtr = new TestLoadingCtr(this);
        

        AddButtonListener("Regist",loadCtr.RegistButtonClick);

        AddSliderListener("Slider", loadCtr.SliderValue);
	}

    
	
	// Update is called once per frame
	void Update () {
		
	}
}
