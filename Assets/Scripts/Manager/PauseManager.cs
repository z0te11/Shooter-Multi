using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PauseManager: MonoBehaviour
{
    public static Action<bool> onGamePaused;
    private bool isPaused = false;

    private void TogglePause()
    {
        if (isPaused)
            ResumeGame();
        else
            PauseGame();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        onGamePaused?.Invoke(isPaused);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        onGamePaused?.Invoke(isPaused);
    }
}
