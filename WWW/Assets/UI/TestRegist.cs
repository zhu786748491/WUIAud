using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRegist : UIBase {

    void Awake()
    {
        AddComponentToChild();
    }

	void Start()
    {
        AddButtonListener("Done", BtnClick);
    }



    void BtnClick()
    {
        GameObject tmpGameObj = GetGameObject("Loading","Loading");

        tmpGameObj.SetActive(true);
        //ShowOrHiddenPanelChild(tmpGameObj,true);
    }
}
