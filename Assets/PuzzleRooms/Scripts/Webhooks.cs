using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Webhooks : MonoBehaviour
{
    public void Send()
    {
        StartCoroutine(UpdateCounter());
    }

    private IEnumerator UpdateCounter()
    {
        // Step 1: Get the current counter value from the server
        UnityWebRequest counterRequest = UnityWebRequest.Get("https://lstwo.net/puzzlerooms/count_training_steps.php");
        yield return counterRequest.SendWebRequest();

        if (counterRequest.result != UnityWebRequest.Result.Success)
        {
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

        UnityWebRequest discordRequest = UnityWebRequest.Post("https://discord.com/api/webhooks/1274715345881665616/diQwjqmsadrWnGF59_WHRIBlnL11ilEhrtOSHUHNOByb238NVVEa1JloKmgfsgWH_j4u", form);
        yield return discordRequest.SendWebRequest();
    }
}