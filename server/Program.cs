using System;
using System.Data.SqlTypes;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using MessageNS;


// Do not modify this class
class Program
{
    static void Main(string[] args)
    {
        ServerUDP sUDP = new ServerUDP();
        sUDP.start();
    }
}

class ServerUDP
{
    private const int serverPort = 32000; // Port to listen on
    private UdpClient udpServer;

    //TODO: implement all necessary logic to create sockets and handle incoming messages
    // Do not put all the logic into one method. Create multiple methods to handle different tasks.
    public void start()
    {
        try
        {
            // Initialize UDP server
            udpServer = new UdpClient(serverPort);
            Console.WriteLine("Server started. Waiting for clients...");

            while (true)
            {
                IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 0);
                byte[] receivedData = udpServer.Receive(ref clientEndPoint);
                Message receivedMessage = DeserializeMessage(receivedData);

                // Handle different message types
                switch (receivedMessage.Type)
                {
                    case MessageType.Hello:
                        HandleHelloMessage(clientEndPoint);
                        break;
                    case MessageType.RequestData:
                        HandleRequestDataMessage(clientEndPoint);
                        break;
                    // Add cases for other message types
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            udpServer.Close();
        }
    }

    //TODO: create all needed objects for your sockets (done)

    //TODO: keep receiving messages from clients
    // you can call a dedicated method to handle each received type of messages

    //TODO: [Receive Hello]

    //TODO: [Send Welcome]

    //TODO: [Receive RequestData]

    //TODO: [Send Data]

    //TODO: [Implement your slow-start algorithm considering the threshold] 

    //TODO: [End sending data to client]

    //TODO: [Handle Errors]

    //TODO: create all needed methods to handle incoming messages


}