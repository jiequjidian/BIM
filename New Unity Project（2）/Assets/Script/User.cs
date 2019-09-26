using Assets.Model;
using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class User : MonoBehaviour
{
    Text TxtName;
    Text TxtPwd;

    public void Login()
    {
        if (TxtName == null || TxtPwd == null)
        {
            PromptMsg.GetInstance().MsgBox("账号密码不正确！", new GameObject());
            return;
        }

        string ServerStr = SocketClient.Send("5*" + TxtName.text + "*" + TxtPwd.text);
        User_model um = JsonMapper.ToObject<User_model>(ServerStr);

        if (um == null)
            return;

        switch (um.RoleName)
        {
            case "普通用户":
                
                //控制功能菜单显示

                break;
            case "超级管理员":

                //控制功能菜单显示

                break;
        }
    }
}
