using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    public static Action onGameStarted;
    public static GameManager instance;
    public GameObject currentPlayer;
    public float roundTime;
    public int roundDifficluty;
    public InventarItems inventar;
    public SpawnSystem spawnSystem;
    private PlayerStats _stats;


    
    private void Awake()
    {
        if (instance == null) instance = this;
        spawnSystem = GetComponent<SpawnSystem>();
    }

    public void Start()
    {
        //Pause;
    }

    public void SetPlayerStats(PlayerStats stats)
    {
        _stats = stats;
    }

    public void Play()
    {
        //UnPause;
        spawnSystem.SpawnPlayer(_stats);
        currentPlayer.GetComponent<CharacterData>().inventory = inventar;
        spawnSystem.StartSpawnEnemy();
        onGameStarted?.Invoke();
    }


}
