using Assets.Model;
using Assets.Script;
using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextQuery : MonoBehaviour
{
    public GameObject slot;
    public GameObject item;
    public GameObject slotPanel;
    public GameObject screen;

    public ToggleGroup tg;
    public Toggle tl1;
    public Toggle tl2;
    public Toggle tl3;
    public Toggle tl4;

    public InputField txt;

    // Start is called before the first frame update
    void Start()
    {
        txt.onEndEdit.AddListener(delegate { InputEnd(txt.text); });
    }

    void InputEnd(string str)
    {
        tg.allowSwitchOff = true;
        tl1.isOn = false;
        tl2.isOn = false;
        tl3.isOn = false;
        tl4.isOn = false;

        screen.SetActive(true);

        print("您输入了：" + str);

        if (str == null)
        {
            print("请正确输入！");
            return;
        }
        string ServerStr = SocketClient.Send("4*" + str);
        List<Equipment_Model> emList = JsonMapper.ToObject<List<Equipment_Model>>(ServerStr);

        //销毁预制体
        DetailsAssets.NewDestroyedObjects(slotPanel);
        //生成预制体
        DetailsAssets.NewGeneratedObjects(slotPanel, slot, item, emList);
    }
}
