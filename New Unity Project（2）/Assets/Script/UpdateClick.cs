using Assets.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpdateClick : MonoBehaviour
{
    //public GameObject slot;
    //public GameObject item;
    public GameObject UpdateWindow;
    public GameObject HintWindow;
    static GameObject itemObject1;

    Text text0;
    Text text1;
    Text text2;
    Text text3;
    Text text4;
    Text text5;

    InputField input1;
    InputField input2;
    InputField input3;
    InputField input4;
    InputField input5;

    public CanvasGroup canvasgroup;

    // Start is called before the first frame update
    void Start()
    {
        canvasgroup = GetComponent<CanvasGroup>();
    }

    public void OnClick()
    {
        if (canvasgroup.blocksRaycasts == true)
        {
            GameObject clickedBtn = EventSystem.current.currentSelectedGameObject;
            text0 = GameObject.Find(clickedBtn.name + "/name").GetComponent<Text>();
            text1 = GameObject.Find(clickedBtn.name + "/Text (1)").GetComponent<Text>();
            text2 = GameObject.Find(clickedBtn.name + "/Text (2)").GetComponent<Text>();
            text3 = GameObject.Find(clickedBtn.name + "/Text (3)").GetComponent<Text>();
            text4 = GameObject.Find(clickedBtn.name + "/Text (4)").GetComponent<Text>();
            text5 = GameObject.Find(clickedBtn.name + "/Text (5)").GetComponent<Text>();

            itemObject1 = Instantiate(UpdateWindow);
            itemObject1.transform.SetParent(GameObject.Find("panel_modification").transform);
            itemObject1.transform.position = new Vector2(960, 540);
            itemObject1.SetActive(true);

            DeleteClick.GetID(text0.text, clickedBtn, itemObject1, HintWindow);

            input1 = GameObject.Find(itemObject1.name + "/new_name").GetComponent<InputField>();
            input2 = GameObject.Find(itemObject1.name + "/new_size").GetComponent<InputField>();
            input3 = GameObject.Find(itemObject1.name + "/new_amount").GetComponent<InputField>();
            input4 = GameObject.Find(itemObject1.name + "/new_units").GetComponent<InputField>();
            input5 = GameObject.Find(itemObject1.name + "/new_Ps").GetComponent<InputField>();

            input1.text = text1.text.Substring(3);
            input2.text = text2.text.Substring(3);
            input3.text = text3.text.Substring(3);
            input4.text = text4.text.Substring(3);
            input5.text = text5.text.Substring(3);

            canvasgroup.blocksRaycasts = false;
        }
    }

    public void QuXiaoClick()
    {
        Destroy(itemObject1);
        canvasgroup.blocksRaycasts = true;
    }

    public void QueDingClick()
    {
        Equipment_model em = new Equipment_model();
        em.E_ID = text0.text.Substring(3);
        em.E_Name = input1.text;
        em.E_Specifications = input2.text;
        em.E_Number = input3.text;
        em.E_Unit = input4.text;
        em.E_Remarks = input5.text;

        var JsonStr = LitJson.JsonMapper.ToJson(em);

        string ServerStr = SocketClient.Send("3*" + JsonStr);
       
        Destroy(itemObject1);
        canvasgroup.blocksRaycasts = true;

        if (ServerStr == "1")
        {
            PromptMsg.GetInstance().MsgBox("修改成功！", HintWindow);
        }
        else
        {
            PromptMsg.GetInstance().MsgBox("修改失败！", HintWindow);
        }
    }
}
