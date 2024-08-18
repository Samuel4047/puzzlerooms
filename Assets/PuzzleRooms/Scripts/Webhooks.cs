using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Webhooks : MonoBehaviour
{
    private string webhookUrl = "https://discord.com/api/webhooks/1274715345881665616/diQwjqmsadrWnGF59_WHRIBlnL11ilEhrtOSHUHNOByb238NVVEa1JloKmgfsgWH_j4u";
    private string counterUrl = "https://lstwo.net/puzzlerooms/count_training_steps.php"; // URL to your PHP script

    public void SendMessageToDiscord()
    {
        StartCoroutine(UpdateCounterAndSendMessage());
    }

    private IEnumerator UpdateCounterAndSendMessage()
    {
        // Step 1: Get the current counter value from the server
        UnityWebRequest counterRequest = UnityWebRequest.Get(counterUrl);
        yield return counterRequest.SendWebRequest();

        if (counterRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error getting counter: " + counterRequest.error);
            yield break;
        }

        // Step 2: Parse the response
        string jsonResponse = counterRequest.downloadHandler.text;
        int counterValue = int.Parse(jsonResponse.Split(':')[1].Replace("}", "").Trim());

        // Step 3: Format the message with the counter value
        string message = $"Training Data Collection Step: {counterValue}!";

        // Step 4: Send the message to Discord
        WWWForm form = new WWWForm();
        form.AddField("content", message);

        UnityWebRequest discordRequest = UnityWebRequest.Post(webhookUrl, form);
        yield return discordRequest.SendWebRequest();

        if (discordRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error sending message to Discord: " + discordRequest.error);
        }
        else
        {
            Debug.Log("Message sent to Discord successfully with counter: " + counterValue);
        }
    }

    // Example usage
    void Start()
    {
        SendMessageToDiscord();
    }
}