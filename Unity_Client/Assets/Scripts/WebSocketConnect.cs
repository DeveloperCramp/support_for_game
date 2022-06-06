using Assets.Model;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

public class SignalRConnector
{
    public Action<Message> OnMessageReceived;
    private HubConnection connection;
    public async Task InitAsync()
    {
        connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/dialog")
                .Build();
        connection.On<string, string>("ReceiveMessage", (user, message) =>
        {
            OnMessageReceived?.Invoke(new Message
            {
                UserName = user,
                TextField = message,
            });
        });
        await StartConnectionAsync();
    }
    public async Task SendMessageAsync(Message message)
    {
        try
        {
            await connection.InvokeAsync("SendMessage",
                message.UserName, message.TextField);
        }
        catch (Exception ex)
        {
            UnityEngine.Debug.LogError($"Error {ex.Message}");
        }
    }
    private async Task StartConnectionAsync()
    {
        try
        {
            await connection.StartAsync();
        }
        catch (Exception ex)
        {
            UnityEngine.Debug.LogError($"Error {ex.Message}");
        }
    }
}