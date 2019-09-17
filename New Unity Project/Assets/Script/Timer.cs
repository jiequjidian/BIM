using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public  Text Timerr1; //Text 组件
    public  Text Timerr2;  //Text 组件
    System.Timers. Timer Mytimer = new System.Timers. Timer();
    // Start is called before the first frame update
    void Start()
    {
        ShowTime();
    }

    // Update is called once per frame
    void Update()
    {
        Timerr1.text = DateTime.Now.ToString("yyyy-MM-dd");
        Timerr2.text = DateTime.Now.ToString("HH:MM:ss");
    }

    /// <summary>
    /// 展示时间
    /// </summary>
    public void ShowTime()
    {
        Timerr1 = GameObject.Find("TextTImer1").GetComponent<Text>();
        Timerr2 = GameObject.Find("TextTImer2").GetComponent<Text>();
        Timerr1.text = DateTime.Now.ToString("yyyy-dd-MM HH:MM:ss");
        Timerr2.text = DateTime.Now.ToString("yyyy-dd-MM HH:MM:ss");
    }

}
