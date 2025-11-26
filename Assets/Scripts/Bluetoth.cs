using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Pipes;
using System.Threading;
using System.IO;

public class Bluetoth : MonoBehaviour
{
    bool zapocni = false;
    private string karakter;
    public pesma pesma;
    public void Start()
    {
        Thread tr = new Thread(ClientTread);
        tr.Start();
       

    }
    public void Uradi( string a)
    {
        pesma.ZasvetliOdredjenoSlovo(a);
    }
 private void ClientTread()
    {
        var client = new NamedPipeClientStream(".", "my_pipe_name", PipeDirection.InOut);
        

        client.Connect();
        Debug.Log("connected pipes");
        StreamString streamString = new StreamString(client);
        string buffer;
        try
        {
            while (client.IsConnected)
            {
                buffer = streamString.ReadString();
                Debug.Log(buffer);
                karakter = buffer;
                zapocni = true;
                Thread.Sleep(100);
            }
            while (!client.IsConnected)
            {
                client.Connect();
                Thread.Sleep(100);
            }
                Debug.Log("Client is re-conected");
            
            client.Close();
        }
        catch
        {

        }
        

    }
    public class StreamString
    {
        private Stream ioStream;
        private UnicodeEncoding streamEncoding;

        public StreamString(Stream ioStream)
        {
            this.ioStream = ioStream;
            streamEncoding = new UnicodeEncoding();
        }

        public string ReadString()
        {
            int len = 0;

            len = ioStream.ReadByte() * 256;
            len += ioStream.ReadByte();
            byte[] inBuffer = new byte[len];
            ioStream.Read(inBuffer, 0, len);

            return streamEncoding.GetString(inBuffer);
        }

        public int WriteString(string outString)
        {
            byte[] outBuffer = streamEncoding.GetBytes(outString);
            int len = outBuffer.Length;
            if (len > UInt16.MaxValue)
            {
                len = (int)UInt16.MaxValue;
            }
            ioStream.WriteByte((byte)(len / 256));
            ioStream.WriteByte((byte)(len & 255));
            ioStream.Write(outBuffer, 0, len);
            ioStream.Flush();

            return outBuffer.Length + 2;
        }
    }
    public void Update()
    {
        if (zapocni) {
            Uradi(karakter);
            zapocni = !zapocni;
                }

    }

}
