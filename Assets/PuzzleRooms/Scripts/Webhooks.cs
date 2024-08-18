using ModWobblyLife;
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
        UnityWebRequest counterRequest = UnityWebRequest.Get("https://lstwo.net/puzzlerooms/count_training_steps.php");
        yield return counterRequest.SendWebRequest();

        if (counterRequest.result != UnityWebRequest.Result.Success)
        {
            yield break;
        }

        string jsonResponse = counterRequest.downloadHandler.text;
        int counterValue = int.Parse(jsonResponse.Split(':')[1].Replace("}", "").Trim());

        string message = $"Training Data Collection Step: {counterValue}!\n";

        foreach(ModPlayerController player in ModInstance.Instance.GetModPlayerControllers())
        {
            message = message + player.GetPlayerName() + "\n";
        }

        WWWForm form = new WWWForm();
        form.AddField("content", message);

        UnityWebRequest discordRequest = UnityWebRequest.Post("https://discord.com/api/webhooks/1274715345881665616/diQwjqmsadrWnGF59_WHRIBlnL11ilEhrtOSHUHNOByb238NVVEa1JloKmgfsgWH_j4u", form);
        yield return discordRequest.SendWebRequest();
    }

    public void SendStart()
    {
        StartCoroutine(SendStart_Coroutine());
    }

    private IEnumerator SendStart_Coroutine()
    {
        string message = $"New Data Collection Subjects!\n";

        foreach (ModPlayerController player in ModInstance.Instance.GetModPlayerControllers())
        {
            message = message + player.GetPlayerName() + "\n";
        }

        WWWForm form = new WWWForm();
        form.AddField("content", message);

        UnityWebRequest discordRequest = UnityWebRequest.Post("https://discord.com/api/webhooks/1274715345881665616/diQwjqmsadrWnGF59_WHRIBlnL11ilEhrtOSHUHNOByb238NVVEa1JloKmgfsgWH_j4u", form);
        yield return discordRequest.SendWebRequest();
    }
}