using System;
using UnityEditor;
using UnityEngine;
using Button = UnityEngine.UI.Button;

public class Exit : MonoBehaviour
{
    public GameObject exitPanel; //面板
    static GameObject itemObject1; //面板
    public Button quxiao;      //取消按钮
    public Button queding;     //确定按钮

    static bool flag = false;
    // Use this for initialization
    void Start()
    {
        quxiao.onClick.AddListener(delegate ()
        {
            this.QuXiao();
        });
        queding.onClick.AddListener(delegate ()
        {
            this.QueDing();
        });
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!flag || itemObject1 == null)
            {
                Create();
                flag = true;
            }
            else
            {
                Destroy(itemObject1);
                flag = false;
            }
        }
    }

    public void Create()
    {
        itemObject1 = Instantiate(exitPanel);
        itemObject1.transform.SetParent(GameObject.Find("panel_modification").transform);
        itemObject1.transform.position = new Vector2(960, 540);
        itemObject1.SetActive(true);
    }

    void QuXiao()
    {
        Destroy(itemObject1);
    }

    void QueDing()
    {
        //安全关闭socket 连接
        SocketClient.SafeClose();
        QuitApplication();
    }

    /// <summary>
    /// 退出程序
    /// </summary>
    public void QuitApplication()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}



