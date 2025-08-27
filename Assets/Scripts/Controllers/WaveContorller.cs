using System.Collections;
using System;
using UnityEngine;
using Photon.Pun;
using Zenject;

public class WaveContorller : MonoBehaviour
{
    public static Action<int> onWaveChanged;
    [SerializeField] private Transform[] _spawnsForEnemys;
    [SerializeField] public SpawnSystem spawnSystem;
    private ISettings _settings;
    private int _countWave;

    public static WaveContorller instance;
    
    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public int CountWave
    {
        get { return _countWave; }
        set { _countWave = value; onWaveChanged?.Invoke(_countWave); }
    }

    [Inject]
    public void Construct(ISettings settings)
    {
        _settings = settings;
    }

    public void StartWave()
    {
        StartSpawnEnemy();
    }

    public void StartSpawnEnemy()
    {
        StartCoroutine(WaitAndSpawning(_settings.DelaySpawn));
    }

    private IEnumerator WaitAndSpawning(float waitTime)
    {
        while (true)
        {
            SpawnWave(0);
            if (CountWave > 0) SpawnWave(0);
            if (CountWave > 1) SpawnWave(1);
            if (CountWave > 3) SpawnWave(2);
            if (CountWave > 5) SpawnWave(1);
            if (CountWave > 6) SpawnWave(0);
            CountWave++;
            int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
            Debug.Log(playerCount);
            yield return new WaitForSeconds(waitTime / playerCount);
        }
    }

    private void SpawnWave(int numberEnemy)
    {
        for (int i = 0; i < _spawnsForEnemys.Length; i++)
        {
            spawnSystem.SpawnUnit(_settings.Enemys[numberEnemy], _spawnsForEnemys[i].position);
        }
    }
}
