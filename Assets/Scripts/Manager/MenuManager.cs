using UnityEngine;
using Photon.Pun;

public class MenuManager : MonoBehaviour
{
    private int _numberPlayer = 0;
    private int _numberMaxPlayer;
    private PlayerStatsSettings[] _statPlayers;
    [SerializeField] private PlayersVariantSettings _playersSettings;
    [SerializeField] private ChoosingPlayer _choosingPlayer;
    [SerializeField] private Settings _levelSettings;
    [SerializeField] private StatsPanelMenu _statsPanelMenu;

    private void Start()
    {
        _numberMaxPlayer = _playersSettings.variantPlayers.Length;
        _statPlayers = new PlayerStatsSettings[_playersSettings.variantPlayers.Length];
        for (int i = 0; i < _statPlayers.Length; i++)
        {
            _statPlayers[i] = _playersSettings.variantPlayers[i].GetComponent<CharacterData>().playerStatsSettings;
        }
        ChangePlayer(0);
    }
    public void ChangePlayer(int number)
    {
        _numberPlayer = number;
        _statsPanelMenu.ShowStats(_statPlayers[number]);
        _choosingPlayer.ShowPlayer(number);
         _levelSettings.player = _playersSettings.variantPlayers[_numberPlayer];
    }

    public void NextPlayer()
    {
        if (_numberPlayer < _numberMaxPlayer - 1)
        {
            _numberPlayer++;
            ChangePlayer(_numberPlayer);
        } 
    }

    public void PreviousPlayer()
    {
        if (_numberPlayer > 0) 
        {
            _numberPlayer--;
            ChangePlayer(_numberPlayer);
        }
        
    }

    public void StartGame()
    {
        _levelSettings.player = _playersSettings.variantPlayers[_numberPlayer];
        PhotonNetwork.LoadLevel("Level");
    }
}
