using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System;

public class GoogleDriveManager: MonoBehaviour
{
    [SerializeField] private bool downloadFromGDrive;
    [SerializeField] private GameManager gameManager;
    public PlayerStats playerStats;

    private readonly string dataUrl = "https://drive.google.com/uc?export=download&id=1GlWVLG-g8J-tCgdkWn6l4mUlSl9lZ-A7";

    public void Start()
    {
        if (downloadFromGDrive) StartCoroutine(GetData(dataUrl));
        else ReadJsonFile();
    }

    private IEnumerator GetData(string url)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();

        if(request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Error GetData from " + url);
            ReadJsonFile();
        } 
        else 
        {
            playerStats = JsonUtility.FromJson<PlayerStats>(request.downloadHandler.text);
            SaveJsonToFile(request.downloadHandler.text);
            Debug.Log("Success Get Data from" + url);
            SendDataToGameManager();
        }
    }

    public void SaveJsonToFile(string json)
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "data.json");
        
        if (!Directory.Exists(Application.streamingAssetsPath))
        {
            Directory.CreateDirectory(Application.streamingAssetsPath);
        }
        
        File.WriteAllText(filePath, json);
        Debug.Log("JSON saved to: " + filePath);
    }

    private void ReadJsonFile()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "data.json");
        if (File.Exists(filePath))
        {
            string jsonString = File.ReadAllText(filePath);
            if (!jsonString.Equals(String.Empty, StringComparison.Ordinal))
            {
                playerStats = JsonUtility.FromJson<PlayerStats>(jsonString);
            }
            else 
            {
                playerStats = new PlayerStats();
                Debug.LogError("No data in file");
            }
        }
        else
        {
            playerStats = new PlayerStats();
            Debug.LogError("No file");
        }
        SendDataToGameManager();
    }

    private void SendDataToGameManager()
    {
        gameManager.SetPlayerStats(playerStats);
    }

    /*
    link: https://drive.google.com/uc?export=download&id=FILE_ID

    id json: 1GlWVLG-g8J-tCgdkWn6l4mUlSl9lZ-A7
    link json: https://drive.google.com/uc?export=download&id=1GlWVLG-g8J-tCgdkWn6l4mUlSl9lZ-A7
    */
}
