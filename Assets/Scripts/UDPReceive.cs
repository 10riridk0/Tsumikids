using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class UDPReceive : MonoBehaviour
{
    static int LOCA_LPORT = 4000;
    static string ADDRESS = "192.168.137.1";
    static IPAddress localAddress = IPAddress.Parse(ADDRESS);
    //static UdpClient udp;
    static IPEndPoint localEP = new IPEndPoint(localAddress, LOCA_LPORT);
    static UdpClient udp = new UdpClient(localEP);
    public static string received_data;
    Thread thread;

    //受信を開始するかどうかの変数
    static bool isRecieve = false;
    //受信したデータをVector3に格納するための変数
    static string[] split_data;
    //コルーチンを実行するためのインスタンス
    public static MonoBehaviour instance;

    void Start()
    {
        udp.Client.ReceiveTimeout = 0;
        thread = new Thread(new ThreadStart(Recieve));
        thread.Start();

        instance = this;
    }

    void Update()
    {
        if (isRecieve)
        {
            hand_over();
        }
    }

    void OnApplicationQuit()
    {
        thread.Abort();
    }

    private static void hand_over()
    {
        //分割した受信データ
        split_data = received_data.Split(',');
        //エフェクトを出す座標
        Vector3 effect_pos = new Vector3();


        //Debug.Log(received_data);
        isRecieve = false;
        if (split_data[0] == "1")
        {
            Program_Execution.exe(split_data[1]);
        }
        else if (split_data[0] == "2")
        {
            effect_pos.x = 210 + int.Parse(split_data[2]) * 250 / 160;
            effect_pos.y = -500 + int.Parse(split_data[1]) * 250 / 160;

            //座標の調整
            effect_pos.x += (960 - effect_pos.x) / 7.5f;

            instance.StartCoroutine(EffectPosition.tsumiki_effect(effect_pos));
        }
        
        Debug.Log(isRecieve);
    }

    private static void Recieve()
    {
        while (true)
        {
            IPEndPoint remoteEP = null;
            byte[] data = udp.Receive(ref remoteEP);
            received_data = Encoding.UTF8.GetString(data);
            isRecieve = true;
        }
    }
}