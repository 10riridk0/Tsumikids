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
    Thread thread;

    void Start()
    {
        udp.Client.ReceiveTimeout = 0;
        thread = new Thread(new ThreadStart(ThreadMethod));
        thread.Start();
    }

    void Update()
    {
    }

    void OnApplicationQuit()
    {
        thread.Abort();
    }

    private static void ThreadMethod()
    {
        int i = 0;
        while (true)
        {
            i++;
            IPEndPoint remoteEP = null;
            Debug.Log(i);
            byte[] data = udp.Receive(ref remoteEP);
            string received_data = Encoding.UTF8.GetString(data);
            Debug.Log("rcv" + i + "::" + received_data);
        }
    }
}