﻿using UnityEngine;
using System.Net.Sockets;
using System.Text;

public class UDPClient : MonoBehaviour
{
    // broadcast address
    public string host = "192.168.137.1";
    public int port = 4000;
    public string text;
    private UdpClient client;

    void Start()
    {
        /*
        client = new UdpClient();
        client.Connect(host, port);
        */
    }

    void Update()
    {
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 40), "Send"))
        {
            Send_data(text);
        }
    }

    public void Send_data(string text)
    {
        client = new UdpClient();
        client.Connect(host, port);
        byte[] dgram = Encoding.UTF8.GetBytes(text);
        client.Send(dgram, dgram.Length);
        Debug.Log(text);
        client.Close();
    }

    /*void OnApplicationQuit()
    {
        client.Close();
    }*/
}