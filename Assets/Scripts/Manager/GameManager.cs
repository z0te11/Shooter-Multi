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
    }

    public void Start()
    {
        //Pause;
    }


    public void Play(int playerID)
    {
        //UnPause;
        spawnSystem.SpawnPlayer();
        currentPlayer.GetComponent<CharacterData>().inventory = inventar;
        if (playerID == 1) spawnSystem.StartSpawnEnemy();
        onGameStarted?.Invoke();
    }


}
