using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Model;
using LitJson;

public class Band : MonoBehaviour
{
    public Text Txt1;
    public Text Txt2;
    public Text Txt3;
    public Text Txt4;

    // Start is called before the first frame update
    void Start()
    {
        BandDate();
    }

    public void BandDate()
    {
        try
        {
            string ServerStr = SocketClient.Send("0*资产管理");
            if (ServerStr == null)
            {
                print("暂无返回值");
            }
            List<EquipmentType_Model> etmList = JsonMapper.ToObject<List<EquipmentType_Model>>(ServerStr);

            Txt1.text = etmList[0].Type_Name;
            Txt2.text = etmList[1].Type_Name;
            Txt3.text = etmList[2].Type_Name;
            Txt4.text = etmList[3].Type_Name;
        }
        catch (Exception ex)
        {
            print(ex.Message);
        }
    }
}
