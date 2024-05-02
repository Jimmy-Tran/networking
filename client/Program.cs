using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using MessageNS;

// SendTo();
class Program
{
    static void Main(string[] args)
    {
        ClientUDP cUDP = new ClientUDP();
        cUDP.start();
    }
}

class ClientUDP
{

    private const int serverPort = 12345; // Change this to the actual server port
    private const string serverIP = "127.0.0.1"; // Change this to the actual server IP
    private UdpClient udpClient;
    private IPEndPoint serverEndPoint;

    //TODO: implement all necessary logic to create sockets and handle incoming messages
    // Do not put all the logic into one method. Create multiple methods to handle different tasks.
    public void start()
    {
        try
        {
            // Initialize UDP client
            udpClient = new UdpClient();
            serverEndPoint = new IPEndPoint(IPAddress.Parse(serverIP), serverPort);

            // Send Hello message
            SendHelloMessage();

            // Receive Welcome message
            ReceiveWelcomeMessage();

            // Send RequestData message
            SendRequestDataMessage();

            // Receive Data messages
            ReceiveDataMessages();

            // Send End message
            SendEndMessage();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            udpClient.Close();
        }
    }
    //TODO: create all needed objects for your sockets


    //TODO: [Send Hello message]
    private void SendHelloMessage()
    {
        Message helloMessage = new Message()
        {
            Type = MessageType.Hello,
            Content = "20" // Threshold for slow start
        };
        SendMessage(helloMessage);
    }
    //TODO: [Receive Welcome]
    private void ReceiveWelcomeMessage()
    {
        Message welcomeMessage = ReceiveMessage();
        // Handle welcome message
    }
    //TODO: [Send RequestData]
    private void SendRequestDataMessage()
    {
        Message requestDataMessage = new Message()
        {
            Type = MessageType.RequestData,
            Content = "hamlet.txt" // Name of the resource
        };
        SendMessage(requestDataMessage);
    }
    //TODO: [Receive Data]
    private void ReceiveDataMessages()
    {
        // Receive and acknowledge Data messages from the server
    }
    //TODO: [Send RequestData]
    private void SendRequestDataMessage()
    {
        Message requestDataMessage = new Message()
        {
            Type = MessageType.RequestData,
            Content = "hamlet.txt" // Name of the resource
        };
        SendMessage(requestDataMessage);
    }
    //TODO: [Send End]
    private void SendEndMessage()
    {
        Message endMessage = new Message()
        {
            Type = MessageType.End
        };
        SendMessage(endMessage);
    }
    //TODO: [Handle Errors]


}