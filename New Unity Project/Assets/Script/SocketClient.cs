using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

public class SocketClient : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        StartServer();
    }

    static Socket sService;
    Thread c_thread;

    //创建连接，线程监听服务端发送的消息
    void StartServer()
    {
        try
        {
            IPAddress ipAddress = IPAddress.Parse("192.168.1.105");
            IPEndPoint ipe = new IPEndPoint(ipAddress, 9333);

            sService = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            sService.Connect(ipe);

            Debug.Log("连接成功");

            //开启新的线程，不停的接收服务器发来的消息
            //c_thread = new Thread(Received);
            //c_thread.IsBackground = true;
            //c_thread.Start(sService);
        }
        catch (Exception ex)
        {
            Debug.Log("连接失败："+ex.Message);
        }
    }


    public static string Send(string str)
    {
        SocketClient sc = new SocketClient();
        return sc.BtSend(str);
    }

    /// <summary>
    /// 向服务器发送消息并接收返回消息
    /// </summary>
    /// <param name="str"></param>
    string BtSend(string str)
    {
        string ServerStr = string.Empty;

        if (str == null)
        {
            Debug.Log("请正确输入！");
            return ServerStr;
        }
        try
        {
            byte[] buffer = new byte[str.Length];
            buffer = Encoding.GetEncoding("GB2312").GetBytes(str);
            sService.Send(buffer);

            Thread.Sleep(100);

            //接收服务器返回消息
            return Received();
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
        return ServerStr;
    }


    /// <summary>
    /// 接收服务端返回消息
    /// </summary>
    string Received()
    {
        string str = string.Empty;

        try
        {
            byte[] buffer = new byte[sService.ReceiveBufferSize];
            //实际接收到的有效字节数
            int len = sService.Receive(buffer);

            if (len == 0)
            {
                return str;
            }

            str = Encoding.GetEncoding("GB2312").GetString(buffer, 0, len);
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }

        return str;
    }
}
