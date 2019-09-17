using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using Assets.Model;
using Assets.Script;

public class ToggletClick1 : MonoBehaviour
{
    public GameObject slot;
    public GameObject item;

    public GameObject screen;
    public GameObject slotPanel;

    public ToggleGroup tg;

    void Start()
    {
        Toggle tl1 = GameObject.Find("分类1").GetComponent<Toggle>();
        Text txt1 = GameObject.Find("Text1").GetComponent<Text>();

        tl1.onValueChanged.AddListener(state => { if (state) { OnValueChanged(state, txt1); } });
    }

    public void OnValueChanged(bool state, Text txt)
    {
        Debug.Log(txt.text + ",toggle change " + state);

        //修改类别为单选
        tg.allowSwitchOff = false;
        screen.SetActive(false);

        string ServerStr = SocketClient.Send("0*" + txt.text);
        List<Equipment_Model> emList = JsonMapper.ToObject<List<Equipment_Model>>(ServerStr);

        //销毁预制体
        DetailsAssets.NewDestroyedObjects(slotPanel);
        //生成预制体
        DetailsAssets.NewGeneratedObjects(slotPanel, slot, item, emList);
    }
}
