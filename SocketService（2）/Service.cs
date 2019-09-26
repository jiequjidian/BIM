using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using LitJson;

namespace SocketService
{
    public partial class Service : Form
    {
        public Service()
        {
            InitializeComponent();
        }

        void Form1_Load(object sender, EventArgs e)
        {
            //LogHelper.Info("-配置文件中格式-");
            //LogHelper.error("-配置文件中格式-");
            //LogHelper.fatal("-配置文件中格式-");
            //LogHelper.warn("-配置文件中格式-");
            //LogHelper.debug("-配置文件中格式-");

            button3.Enabled = false;
            CheckForIllegalCrossThreadCalls = false;
        }

        private Socket sService;//服务端套接字

        //记录客户端连接Socket 
        Dictionary<string, Socket> dic = new Dictionary<string, Socket>();

        //连接
        void button1_Click(object sender, EventArgs e)
        {
            Connect();
        }

        /// <summary>
        /// Socket连接
        /// </summary>
        private void Connect()
        {
            int port = Convert.ToInt32(textBox3.Text.Trim());

            IPAddress ip = IPAddress.Parse(textBox1.Text.Trim());
            IPEndPoint ipe = new IPEndPoint(ip, port);

            sService = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                sService.Bind(ipe);
                sService.Listen(10);

                //ShowMsg("服务器开始监听");
                LogHelper.Info("服务器开始监听");

                Thread td = new Thread(AcceptInfo);
                td.IsBackground = true;
                td.Name = "监控客户端";
                td.Start(sService);

                textBox1.Enabled = false;
                textBox3.Enabled = false;
                button1.Enabled = false;
                button3.Enabled = true;
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
                LogHelper.error(ex.Message);
            }
        }

        /// <summary>
        /// 监听客户端连接
        /// </summary>
        /// <param name="o"></param>
        void AcceptInfo(object o)
        {
            Socket tSocket;
            string clientName=string.Empty;

            while (true)
            {
                //通信用socket
                try
                {
                    tSocket = sService.Accept();
                    clientName = tSocket.RemoteEndPoint.ToString();
                    LogHelper.Info("客户端："+ clientName+",已连接");

                    comboBox1.Items.Add(clientName);
                    dic.Add(clientName, tSocket);
                    dataGridView1.Rows.Add(DateTime.Now, clientName, "已连接！");

                    Thread th = new Thread(ReceiveMsg);
                    th.IsBackground = true;
                    th.Name = "接收消息";
                    th.Start(tSocket);
                }
                catch (Exception ex)
                {
                    ShowMsg("异常退出！" + ex.Message);
                    LogHelper.error("异常退出！" + ex.Message);
                    comboBox1.Items.Remove(clientName);

                    dic[clientName].Shutdown(SocketShutdown.Both);
                    dic[clientName].Close();

                    dic.Remove(clientName);
                    break;
                }
            }
        }

        /// <summary>
        /// 接收客户端消息
        /// </summary>
        /// <param name="o"></param>
        void ReceiveMsg(object o)
        {
            Socket client = o as Socket;
            string clientName = client.RemoteEndPoint.ToString();

            while (true)
            {
                try
                {
                    byte[] buffer = new byte[client.ReceiveBufferSize];

                    int n = client.Receive(buffer);

                    Thread.Sleep(100);

                    string data = Encoding.GetEncoding("GB2312").GetString(buffer, 0, n);
                    LogHelper.Info("客户端消息：" + data);
                    
                    if (data == "")
                    {
                        dataGridView1.Rows.Add(DateTime.Now, clientName, "已退出连接！");
                        comboBox1.Items.Remove(clientName);
                        
                        dic[clientName].Shutdown(SocketShutdown.Both);
                        dic[clientName].Close();

                        dic.Remove(clientName);
                        break;
                    }
                    string StrJson = ParsingMsg(clientName, data);

                    if (StrJson == null)
                    {

                    }
                    LogHelper.Info("服务端消息：" + StrJson);
                    dataGridView1.Rows.Add(DateTime.Now, clientName, data, StrJson);//dataGridView1添加数据
                    dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);//dataGridView1倒叙显示
                    comboBox1.SelectedItem = clientName;//下拉框绑定客户端IP

                    //返回给客户端数据
                    SendMsg(client.RemoteEndPoint.ToString(),StrJson.Trim());
                }
                catch (Exception ex)
                {
                    ShowMsg("异常退出！" + ex.Message);
                    LogHelper.error("异常退出！" + ex.Message);
                    comboBox1.Items.Remove(clientName);

                    dic[clientName].Shutdown(SocketShutdown.Both);
                    dic[clientName].Close();

                    dic.Remove(clientName);
                    
                    break;
                }
            }
        }

        /// <summary>
        /// 给客户端发送消息
        /// </summary>
        /// <param name="IP">发送地址</param>
        /// <param name="str">发送数据</param>
        void SendMsg(string IP,string str)
        {
            try
            {
                byte[] buffer = Encoding.GetEncoding("GB2312").GetBytes(str);
                dic[IP].Send(buffer);
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
                LogHelper.error(ex.Message);
            }
        }

        /// <summary>
        /// 提示框
        /// </summary>
        /// <param name="Messge">要显示的消息</param>
        void ShowMsg(string Messge)
        {
            MessageBox.Show(Messge);
        }

        //关闭Socket
        private void button3_Click(object sender, EventArgs e)
        {
            if (dic.Count == 0)
            {
                return;
            }

            CloseSocket();

            textBox1.Enabled = true;
            textBox3.Enabled = true;
            button1.Enabled = true;
            button3.Enabled = false;
        }

        void CloseSocket()
        {
            try
            {
                foreach (Socket item in dic.Values)
                {
                    if (item ==null)
                    {
                        return;
                    }

                    if (!item.Connected)
                    {
                        item.Close();
                    }
                }

                sService.Shutdown(SocketShutdown.Both);
                sService.Close();
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
                LogHelper.error(ex.Message);
            }
        }

        //数据解析，并查询数据
        string ParsingMsg(string clientName,string str)
        {
            string resultJson = string.Empty;

            string[] a = str.Split('*');

            //00 00             报头
            //01                功能码
            //02                功能操作
            //00 04             长度
            //00 00 00 00       数据
            //CC 13             效验
            switch (a[0])
            {
                case "0"://查询
                    switch (a[1])
                    {
                        case "资产管理":
                            resultJson = BasicInformation.Query_EquipmentType();
                            break;
                        case "土建设施":
                            resultJson = BasicInformation.GetEquipmentType("土建设施");
                            break;
                        case "供水检测设备":
                            resultJson = BasicInformation.GetEquipmentType("供水检测设备");
                            break;
                        case "安防设备":
                            resultJson = BasicInformation.GetEquipmentType("安防设备");
                            break;
                        case "视频监控":
                            resultJson = BasicInformation.GetEquipmentType("视频监控");
                            break;
                    }
                    break;
                case "1"://增
                    Basic_Information_model InsertEm = JsonMapper.ToObject<Basic_Information_model>(a[1]);
                    resultJson = BasicInformation.Insert_Equipment(InsertEm).ToString();
                    break;
                case "2"://删
                    resultJson = BasicInformation.Delete_Equipment(Convert.ToInt32(a[1])).ToString();
                    break;
                case "3"://改
                    Basic_Information_model UpdateEm = JsonMapper.ToObject<Basic_Information_model>(a[1]);
                    resultJson = BasicInformation.Update_Equipment(UpdateEm).ToString();
                    break;
                case "4"://模糊查询
                    resultJson = BasicInformation.FuzzyQuery_Equipment(a[1]);
                    break;
                case "5"://登陆
                    resultJson = User.login2(a[1], a[2]);
                    break;
            }
            return resultJson;
        }
    }
}
