using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    public static Action<bool> onGamePaused;
    private bool isPaused = false;
    private bool isGameEnd = false;

    public static PauseManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void OnEnable()
    {
        EndGameController.onGameEnded += TrackEndGame;
    }

    private void OnDisable()
    {
        EndGameController.onGameEnded -= TrackEndGame;   
    }
    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame && !isGameEnd)
        {
            TogglePause();
        }
    }
    private void TogglePause()
    {
        if (isGameEnd) return;
        if (isPaused)
            ResumeGame();
        else
            PauseGame();
    }

    public void PauseGame()
    {
        if (isGameEnd) return;
        Time.timeScale = 0f;
        isPaused = true;
        onGamePaused?.Invoke(isPaused);
    }


    public void ResumeGame()
    {
        if (isGameEnd) return;
        Time.timeScale = 1f;
        isPaused = false;
        onGamePaused?.Invoke(isPaused);
    }

    private void TrackEndGame()
    {
        isGameEnd = true;
        Time.timeScale = 0f;
        onGamePaused?.Invoke(false);
    }
}
