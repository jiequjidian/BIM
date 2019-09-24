using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public  Text Timerr1; //Text 组件
    public  Text Timerr2;  //Text 组件

    void Start()
    {
        //Timerr1.text = DateTime.Now.ToString("yyyy-dd-MM HH:MM:ss");
        //Timerr2.text = DateTime.Now.ToString("yyyy-dd-MM HH:MM:ss");
    }

    void Update()
    {
        Timerr1.text = DateTime.Now.ToString("yyyy-MM-dd");
        Timerr2.text = DateTime.Now.ToString("HH:MM:ss");
    }
}
