using System;
using UnityEngine;
using UniRx;
using System.IO;

public class LoadDataManager
{
    public static Action<string> OnDataSceneLoaded;
    public static Action<string> OnDataLevelLoaded;
    public LoadDataManager()
    {
        Debug.Log("Start Load Data");
        StartLoadData();
    }

    private void StartLoadData()
    {
        var loadData = Observable.Start(() =>
        {
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
            var newData = ReadJsonFile();
            return newData;
        });

        Observable.WhenAll(loadData).ObserveOnMainThread().Subscribe(xs => 
        {
            LoadDataScene(xs[0].nameScene);
            LoadDataLevel(xs[0].levelScene);
        });

    }

    private void LoadDataScene(string nameScene)
    {
        OnDataSceneLoaded?.Invoke(nameScene);
        Debug.Log(nameScene);
    }

    private void LoadDataLevel(string levelScene)
    {
        OnDataLevelLoaded?.Invoke(levelScene);
        Debug.Log(levelScene);
    }

    private SceneData ReadJsonFile()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "dataScene.json");
        if (File.Exists(filePath))
        {
            string jsonString = File.ReadAllText(filePath);
            if (!jsonString.Equals(String.Empty, StringComparison.Ordinal))
            {
                return JsonUtility.FromJson<SceneData>(jsonString);
            }
        }
        return null;
    }
}
