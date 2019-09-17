using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Model;
using System;

public class InsertClick : MonoBehaviour
{
    //public Button BtnDetermine;

    public Text InputName;
    public Text InputSpecifications;
    public Text InputNumber;
    public Text InputUnit;
    public Text InputRemarks;
    public Dropdown DdList;

    static GameObject itemObject1;
    public GameObject HintWindow;
    public GameObject InsertWindow;
    
    public CanvasGroup canvasgroup1;
    

    // Start is called before the first frame update
    void Start()
    {
        canvasgroup1 = GetComponent<CanvasGroup>();
        //BtnDetermine.onClick.AddListener(OnClick);
    }

    //新增
    public void OnClick()
    {

        Equipment_Model em = new Equipment_Model();
        em.E_Name = InputName.text;
        switch (DdList.options[DdList.value].text)
        {
            case "工艺设备":
                em.E_Type = "1";
                break;
            case "除臭设备":
                em.E_Type = "2";
                break;
            case "建筑工程":
                em.E_Type = "3";
                break;
            case "电气工程":
                em.E_Type = "4";
                break;
        }
        em.E_Specifications = InputSpecifications.text;
        em.E_Number = InputNumber.text;
        em.E_Unit = InputUnit.text;
        em.E_Remarks = InputRemarks.text;

        var JsonStr = LitJson.JsonMapper.ToJson(em);

        string ServerStr = SocketClient.Send("1*" + JsonStr);
        if (ServerStr == "1")
        {
            Destroy(itemObject1);
            //PromptMsg.GetInstance().MsgBox("添加成功！", HintWindow);
        }
        else
        {
            //PromptMsg.GetInstance().MsgBox("添加失败！", HintWindow);
        }
        

        //Destroy(itemObject1);
        //canvasgroup1.blocksRaycasts = true;
    }

    public void Click()
    {
        if (canvasgroup1.blocksRaycasts == true)
        {
            itemObject1 = Instantiate(InsertWindow);
            itemObject1.transform.SetParent(GameObject.Find("panel_modification").transform);
            itemObject1.transform.position = new Vector2(960, 540);
            itemObject1.SetActive(true);

            canvasgroup1.blocksRaycasts = false;
        }

    }

    public void DeleteClick()
    {
        Destroy(itemObject1);
        canvasgroup1.blocksRaycasts = true;
    }
}
