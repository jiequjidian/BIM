using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromptMsg : MonoBehaviour
{
    public Text Msg;
    static GameObject itemObject1;
    public static PromptMsg promprMsg;

    public static PromptMsg GetInstance()
    {
        if (promprMsg == null)
        {
            promprMsg = new PromptMsg();
        }
        return promprMsg;
    }

    /// <summary>
    /// 显示弹框
    /// </summary>
    public void MsgBox(string msg,GameObject HintWindow)
    {
        try
        {
            itemObject1 = Instantiate(HintWindow);
            itemObject1.transform.SetParent(GameObject.Find("panel_modification").transform);
            itemObject1.transform.position = new Vector2(960, 540);
            itemObject1.SetActive(true);

            Text t1 = GameObject.Find(itemObject1.name + "/提示信息txt").GetComponent<Text>();
            t1.text = msg;

            Destroy(itemObject1, 3);
            //canvasgroup1.blocksRaycasts = false;
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }
}
