using System;
using UnityEngine;
using Zenject;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Action<GameObject> onPlayerSpawn;
    public static Action onGameStarted;
    public static GameManager instance;


    [SerializeField] public SpawnSystem spawnSystem;
    [SerializeField] public WaveContorller waveController;
    private GameObject _currentPlayer;
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

    public GameObject GetPlayer()
    {
        if (_currentPlayer != null) return _currentPlayer;
        else return null;
    }

    public void Play()
    {
        PauseManager.instance.ResumeGame();
        Debug.Log("Start Play");
        var playerID = NetworkManager.playerId;
        _currentPlayer = spawnSystem.SpawnPlayer();
        if (_currentPlayer != null) onPlayerSpawn?.Invoke(_currentPlayer);
        else
        {
            Debug.Log("Cant start game without Player");
            return;
        }
        if (PhotonNetwork.IsMasterClient) waveController.StartWave();
        onGameStarted?.Invoke();
    }
    public void RestartGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void ExitToMenu()
    {
        GetComponent<EndGameController>().EndGame();
        SceneManager.LoadScene("Menu");
    }

    


}
