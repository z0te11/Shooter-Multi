using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour
{
    [SerializeField] private Text _textHp;
    [SerializeField] private Text _textDamage;
    [SerializeField] private Text _textSpeed;
    private PlayerHealth _playerHealth;
    private ShootAbility _playerShoot;
    private Movement _playerMove;

    private void OnEnable()
    {
        GameManager.onGameStarted += SubEventPlayer;
    }

    private void OnDisable()
    {
        _playerHealth.onPlayerHealthChanged -= ShowHpPlayer;
        _playerShoot.onPlayerDamageChanged -= ShowDamagePlayer;
        _playerMove.onPlayerSpeedChanged -= ShowSpeedPlayer;
    }

    private void SubEventPlayer()
    {
        var playerObj = GameManager.instance.currentPlayer;
        if (playerObj.TryGetComponent<PlayerHealth>(out PlayerHealth health))
        {
            _playerHealth = health;
            _playerHealth.onPlayerHealthChanged += ShowHpPlayer;
            ShowHpPlayer(_playerHealth.Healths);
        }
        if (playerObj.TryGetComponent<ShootAbility>(out ShootAbility shoot))
        {
            _playerShoot = shoot;
            _playerShoot.onPlayerDamageChanged += ShowDamagePlayer;
            ShowDamagePlayer(_playerShoot.Damage);
        } 
        if (playerObj.TryGetComponent<Movement>(out Movement move))
        {
            _playerMove = move;
            _playerMove.onPlayerSpeedChanged += ShowSpeedPlayer;
            ShowSpeedPlayer(_playerMove.Speed);
        } 
    }

    private void ShowHpPlayer(int value)
    {
        _textHp.text = "Hp " + value.ToString();
    }

    private void ShowSpeedPlayer(float value)
    {
        _textSpeed.text = "Speed " + value.ToString();
    }
    private void ShowDamagePlayer(float value)
    {
        _textDamage.text = "Damage " + value.ToString();
    }
}
