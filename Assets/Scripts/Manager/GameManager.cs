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
    private SpawnSystem _spawnSystem;


    
    private void Awake()
    {
        if (instance == null) instance = this;
        _spawnSystem = GetComponent<SpawnSystem>();
    }

    public void Start()
    {
        //Pause;
    }

    public void Play(PlayerStats playerStats)
    {
        //UnPause;
        currentPlayer = _spawnSystem.SpawnPlayer(playerStats);
        currentPlayer.GetComponent<CharacterData>().inventory = inventar;
        _spawnSystem.StartSpawnEnemy();
        onGameStarted?.Invoke();
    }


}
