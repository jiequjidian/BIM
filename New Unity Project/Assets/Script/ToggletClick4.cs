using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Model;
using LitJson;
using Assets.Script;

public class ToggletClick4 : MonoBehaviour
{
    public GameObject slot;
    public GameObject item;

    public GameObject screen;
    public GameObject slotPanel;

    public ToggleGroup tg;

    //void Start()
    //{
    //    Toggle tl4 = GameObject.Find("分类4").GetComponent<Toggle>();
    //    Text txt4 = GameObject.Find("Text4").GetComponent<Text>();

    //    tl4.onValueChanged.AddListener(value => { if (value) { OnValueChanged(value, txt4); } });
    //}

    public void OnValueChanged4(bool state)
    {
        if (state == false)
            return;

        Text txt = GameObject.Find("Text4").GetComponent<Text>();

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
