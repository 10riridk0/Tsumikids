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
    static bool isRecieve = false;

    void Start()
    {
        udp.Client.ReceiveTimeout = 0;
        thread = new Thread(new ThreadStart(Recieve));
        thread.Start();
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
        //Debug.Log(received_data);
        isRecieve = false;
        Program_Execution.exe(received_data);
        
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