using BestHTTP;
using System;
using System.Collections;
using System.Text;
using UnityEngine;

public class HttpRequest : MonoBehaviour
{
    [SerializeField] public string nickname;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SendRequest());
    }
    private IEnumerator SendRequest()
    {
        string jsonString = "{\"nickname\": \"" + nickname + "\", \"token\": \"" + SystemInfo.deviceUniqueIdentifier + "\"}";

        HTTPRequest request = new HTTPRequest(new Uri("http://localhost:5000/api/player"), HTTPMethods.Post, OnRequestFinished);

        request.SetHeader("Content-Type", "application/json; charset=UTF-8");
        request.RawData = Encoding.UTF8.GetBytes(jsonString);
        yield return request.Send();

        void OnRequestFinished(HTTPRequest request, HTTPResponse response)
        {

            Debug.Log("Request Finished! Text received: " + response.DataAsText);
        }
    }
}
