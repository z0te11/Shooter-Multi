using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    public static Action onGameStarted;
    public static GameObject currnetPlayer;
    private static SpawnSystem _spawnSystem;
    public float roundTime;
    public int roundDifficluty;
    
    private void Awake()
    {
        _spawnSystem = GetComponent<SpawnSystem>();
    }

    public void Start()
    {
        //Pause;
    }

    public static void Play(PlayerStats playerStats)
    {
        //UnPause;
        currnetPlayer = _spawnSystem.SpawnPlayer(playerStats);
        _spawnSystem.StartSpawnEnemy();
        onGameStarted?.Invoke();
    }


}
