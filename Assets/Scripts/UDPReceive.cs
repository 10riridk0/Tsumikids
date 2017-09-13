using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class UDPReceive : MonoBehaviour
{
    int LOCA_LPORT = 4000;
    static UdpClient udp;
    Thread thread;

    void Start()
    {
        udp = new UdpClient(LOCA_LPORT);
        udp.Client.ReceiveTimeout = 2000;
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
        Debug.Log("ここまできた");
        int i = 0;
        while (true)
        {
            Debug.Log(i++);
            IPEndPoint remoteEP = null;
            Debug.Log(i++);
            byte[] data = udp.Receive(ref remoteEP);
            Debug.Log(i++);
            string received_data = Encoding.UTF8.GetString(data);
            Debug.Log(i++);
            Debug.Log(received_data);
        }
    }
}