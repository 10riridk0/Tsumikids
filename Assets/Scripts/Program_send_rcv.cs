using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationApp
{
    class Preclass
    {
        //データを送信するリモートホストとポート番号
        public string[] remoteHost = new string[5];
        public int[] remotePort = new int[5];
        public System.Net.Sockets.UdpClient[] udp = new System.Net.Sockets.UdpClient[5];

        public void input_info(ref string[] remoteHost, ref int[] remotePort)
        {
            remoteHost[0] = "192.168.137.118";
            remoteHost[1] = "192.168.x.x";
            remoteHost[2] = "192.168.x.x";
            remoteHost[3] = "192.168.x.x";
            remoteHost[4] = "192.168.x.x";

            remotePort[0] = 4000;
            remotePort[1] = 6000;
            remotePort[2] = 7000;
            remotePort[3] = 8000;
            remotePort[4] = 9000;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Preclass pre = new Preclass();

            pre.input_info(ref pre.remoteHost, ref pre.remotePort);

            for (int i = 0; i < 5; i++)
            {
                pre.udp[i] = new System.Net.Sockets.UdpClient(); ;
            }
            
            string rgb;
            string rgb_rv;

            //データを送信するリモートホストとポート番号
            string remoteHost = "192.168.137.118";
            int remotePort = 4000;

            //UdpClientオブジェクトを作成する
            System.Net.Sockets.UdpClient udp = new System.Net.Sockets.UdpClient();

            //バインドするローカルIPとポート番号
            string localIpString = "192.168.0.1";
            System.Net.IPAddress localAddress = System.Net.IPAddress.Parse(localIpString);
            int localPort = 3000;

            //UdpClientを作成し、ローカルエンドポイントにバインドする
            System.Net.IPEndPoint localEP = new System.Net.IPEndPoint(localAddress, localPort);
            System.Net.Sockets.UdpClient udp2 = new System.Net.Sockets.UdpClient(localEP);

            System.Net.IPEndPoint remoteEP = null;

            rgb = "S255200100";
            rgb_rv = rgb + 1;




            var task = Task.Factory.StartNew(() =>
            {
                for (;;)
                {
                    Console.WriteLine("zzz");
                    //データを受信する
                    byte[] rcvBytes = udp2.Receive(ref remoteEP);
                    Console.WriteLine("yeah");

                    //データを文字列に変換する
                    string rcvMsg = System.Text.Encoding.UTF8.GetString(rcvBytes);

                    //受信したデータと送信者の情報を表示する
                    Console.WriteLine("受信したデータ:{0}", rcvMsg);
                    Console.WriteLine("送信元アドレス:{0}/ポート番号:{1}", remoteEP.Address, remoteEP.Port);
                }
            });

            System.Threading.Thread.Sleep(1000);


            for (;;)
            {

                if (rgb != rgb_rv)
                {
                    //Random cRandom = new System.Random();
                    //int random = cRandom.Next(0, 5);
                    //送信するデータを作成する
                    byte[] sendBytes = sendBytes = System.Text.Encoding.UTF8.GetBytes(rgb); ;

                    //リモートホストを指定してデータを送信する
                    udp.Send(sendBytes, sendBytes.Length, pre.remoteHost[0], pre.remotePort[0]);
                    Console.WriteLine("{0}", rgb);
                    System.Threading.Thread.Sleep(2000);

                }
            }
        }
    }
}