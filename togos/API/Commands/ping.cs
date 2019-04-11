using Cosmos.System.Network;
using System;
using System.Collections.Generic;
using System.Text;

public static class ping
{
    public static string Name = "ping";
    public static string Info = "Pings a internet address";
    public static bool NeedsParam = true;

    public static void Run(string c)
    {
        var p = c.Split(".");

        try
        {
            UdpClient uClient = new UdpClient();

            var ip = new Cosmos.System.Network.IPv4.Address((byte)int.Parse(p[0]), (byte)int.Parse(p[1]),
                (byte)int.Parse(p[2]), (byte)int.Parse(p[3]));
            var host = new Cosmos.System.Network.IPv4.EndPoint(ip, 80);
            byte[] payload = Encoding.ASCII.GetBytes("abcdefghijklmnopqrstuvwabcdefghi");

            try
            {
                uClient.Connect(ip, 80);
                uClient.Send(payload, ip, 80);
                uClient.Receive(ref host);
                Console.WriteLine("Connected!");
                uClient = null;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Connection Failed");
                Console.WriteLine(e.Message);
            }

        }
        catch
        {
            Console.WriteLine("Connection Failed");
        }
    }
}
