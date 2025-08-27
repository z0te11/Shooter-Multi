using System;
using UnityEngine;

public class EndGameController : MonoBehaviour
{
    public static Action onGameEnded;
    [SerializeField] private GameObject _endGameMenu;
    private GameObject _player;
    private bool _isPlayerAlive = false;

    private void OnEnable()
    {
        GameManager.onPlayerSpawn += StartTrackPlayer;
    }

    private void StartTrackPlayer(GameObject player)
    {
        _player = player;
        _isPlayerAlive = true;
    }

    private void Update()
    {
        if (_isPlayerAlive)
        {
            if (_player == null)
            {
                EndGame();
            }
        }
    }

    public void EndGame()
    {
        onGameEnded?.Invoke();
        _endGameMenu.SetActive(true);
        _isPlayerAlive = false;
    }
}
