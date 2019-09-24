<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Model;
using LitJson;
using Assets.Script;

public class ToggletClick3 : MonoBehaviour
{
    public GameObject slot;
    public GameObject item;

    public GameObject screen;
    public GameObject slotPanel;

    public ToggleGroup tg;

    //void Start()
    //{
    //    Toggle tl3 = GameObject.Find("分类3").GetComponent<Toggle>();
    //    Text txt3 = GameObject.Find("Text3").GetComponent<Text>();

    //    tl3.onValueChanged.AddListener(state => { if (state) { OnValueChanged(state, txt3); } });
    //}

    public void OnValueChanged3(bool state)
    {
        if (state == false)
            return;

        Text txt = GameObject.Find("Text3").GetComponent<Text>();
        //Debug.Log("toggle text： " + txt.text + ",toggle change：" + state + ",toggle name：" + gameObject.name);

        //修改类别为单选
        //tg.allowSwitchOff = false;
        screen.SetActive(false);

        string ServerStr = SocketClient.Send("0*" + txt.text);
        List<Equipment_Model> emList = JsonMapper.ToObject<List<Equipment_Model>>(ServerStr);

        //销毁预制体
        DetailsAssets.NewDestroyedObjects(slotPanel);
        //生成预制体
        DetailsAssets.NewGeneratedObjects(slotPanel, slot, item, emList);
    }
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Model;
using LitJson;
using Assets.Script;

public class ToggletClick3 : MonoBehaviour
{
    public GameObject slot;
    public GameObject item;

    public GameObject screen;
    public GameObject slotPanel;

    public ToggleGroup tg;

    //void Start()
    //{
    //    Toggle tl3 = GameObject.Find("分类3").GetComponent<Toggle>();
    //    Text txt3 = GameObject.Find("Text3").GetComponent<Text>();

    //    tl3.onValueChanged.AddListener(state => { if (state) { OnValueChanged(state, txt3); } });
    //}

    public void OnValueChanged3(bool state)
    {
        if (state == false)
            return;

        Text txt = GameObject.Find("Text3").GetComponent<Text>();

        //修改类别为单选
        //tg.allowSwitchOff = false;
        if (screen.activeInHierarchy)
            screen.SetActive(false);

        string ServerStr = SocketClient.Send("0*" + txt.text);
        List<Equipment_Model> emList = JsonMapper.ToObject<List<Equipment_Model>>(ServerStr);

        //销毁预制体
        DetailsAssets.NewDestroyedObjects(slotPanel);
        //生成预制体
        DetailsAssets.NewGeneratedObjects(slotPanel, slot, item, emList);
    }
}
>>>>>>> fcf44dd04a2e3b23f0872a0785bc9baa53fbe61d
