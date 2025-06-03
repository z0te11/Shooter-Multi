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

    [SerializeField] public SpawnSystem spawnSystem;
    [SerializeField] public WaveContorller waveController;
    private PlayerStats _stats;
    private ISettings _settings;


    private void Awake()
    {
        if (instance == null) instance = this;
    }

    [Inject]
    public void Construct(ISettings settings)
    {
        _settings = settings;
    }

    public void Play(int playerID)
    {
        //UnPause;
        spawnSystem.SpawnPlayer();
        if (playerID == 1) waveController.StartWave();
        onGameStarted?.Invoke();
    }


}
