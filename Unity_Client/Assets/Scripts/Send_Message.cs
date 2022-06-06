using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.AspNetCore.SignalR.Client;
using Assets.Model;

public class Send_Message : MonoBehaviour
{
    public Text ReceivedText;
    public InputField MessageInput;
    private SignalRConnector connector;
    public async Task Start()
    {
        connector = new SignalRConnector();
        connector.OnMessageReceived += UpdateReceivedMessages;

        await connector.InitAsync();
    }
    private void UpdateReceivedMessages(Message newMessage)
    {
        var lastMessages = this.ReceivedText.text;
        if (string.IsNullOrEmpty(lastMessages) == false)
        {
            lastMessages += "\n";
        }
        lastMessages += $"User:{newMessage.UserName} Message:{newMessage.Text}";
        this.ReceivedText.text = lastMessages;
    }
    private async void SendMessage()
    {
        await connector.SendMessageAsync(new Message
        {
            UserName = "Example",
            Text = MessageInput.text,
        });
    }
}