using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;

    private void OnEnable()
    {
        PauseManager.onGamePaused += OpenPauseMenu;
    }

    private void OnDisable()
    {
        PauseManager.onGamePaused -= OpenPauseMenu;
    }

    private void OpenPauseMenu(bool isPaused)
    {
        _pauseMenu.SetActive(isPaused);
    }
}
