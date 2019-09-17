using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeleteClick : MonoBehaviour
{
    static GameObject itemObject1;
    static GameObject clickedBtn1;
    static GameObject HintWindow1;

    static string name = string.Empty;

    public void OnClick()
    {
        Debug.Log(name);

        //var JsonStr = LitJson.JsonMapper.ToJson(name);

        string ServerStr = SocketClient.Send("2*" + name);
        if (ServerStr == "1")
        {
            PromptMsg.GetInstance().MsgBox("删除成功！", HintWindow1);

            Destroy(clickedBtn1.transform.parent.gameObject);
            Destroy(itemObject1);
            Destroy(clickedBtn1);
        }
        else
        {
            PromptMsg.GetInstance().MsgBox("删除失败！", HintWindow1);
        }
        
    }

    public static void GetID(string ID, GameObject clickedBtn, GameObject itemObject, GameObject HintWindow)
    {
        name = ID.Substring(3);
        itemObject1 = itemObject;
        clickedBtn1 = clickedBtn;
        HintWindow1 = HintWindow;
    }
}
