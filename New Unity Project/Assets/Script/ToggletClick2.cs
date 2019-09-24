using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Model;
using LitJson;
using Assets.Script;

public class ToggletClick2 : MonoBehaviour
{
    public GameObject slot;
    public GameObject item;

    public GameObject screen;
    public GameObject slotPanel;

    public ToggleGroup tg;

    //void Start()
    //{
    //    Toggle tl2 = GameObject.Find("分类2").GetComponent<Toggle>();
    //    Text txt2 = GameObject.Find("Text2").GetComponent<Text>();

    //    tl2.onValueChanged.AddListener(state => { if (state) { OnValueChanged(state, txt2); } });
    //}

    public void OnValueChanged2(bool state)
    {
        if (state == false)
            return;

        Text txt = GameObject.Find("Text2").GetComponent<Text>();

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
