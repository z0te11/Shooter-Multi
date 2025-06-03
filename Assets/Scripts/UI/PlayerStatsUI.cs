using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour
{
    [SerializeField] private Text _textHp;
    [SerializeField] private Text _textDamage;
    [SerializeField] private Image _buffDamage;
    [SerializeField] private Text _textSpeed;
    [SerializeField] private Image _buffSpeed;
    [SerializeField] private Text _textLevel;
    [SerializeField] private Text _textAmmo;
    [SerializeField] private Text _textReload;
    [SerializeField] private Image _buffReload;
    [SerializeField] private Text _textArmor;
    [SerializeField] private Image _buffArmor;
    private PlayerHealth _playerHealth;
    private ShootPlayerAbility _playerShoot;
    private PlayerMovement _playerMove;
    private ExperiancePlayer _playerExp;
    private PlayerArmor _playerArmor;

    private void OnEnable()
    {
        SpawnSystem.onPlayerSpawn += SubEventPlayer;
    }

    private void OnDisable()
    {
        if (_playerShoot != null)
        {
            _playerShoot.onPlayerDamageChanged -= ShowDamagePlayer;
            _playerShoot.onPlayerAmmoChanged -= ShowAmmoPlayer;
            _playerShoot.onPlayerReloading -= ShowIsReloadPlayer;
            _playerShoot.isPlayerDamageBuffed -= ShowBuffDamagePlayer;
            _playerShoot.isPlayerWeaponBuffed -= ShowBuffWeaponPlayer;
        }
        if (_playerMove != null)
        {
            _playerMove.onPlayerSpeedChanged -= ShowSpeedPlayer;
            _playerMove.isPlayerSpeedBuffed -= ShowBuffSpeedPlayer;
        }
        if (_playerArmor != null)
        {
            _playerArmor.onPlayerArmorChanged -= ShowArmorPlayer;
            _playerArmor.isPlayerArmorBuffed -= ShowBuffArmorPlayer;
        }
        if (_playerHealth != null) _playerHealth.onPlayerHealthChanged -= ShowHpPlayer;
        if (_playerExp != null) _playerExp.onPlayerLevelChanged -= ShowLevelPlayer;
        SpawnSystem.onPlayerSpawn -= SubEventPlayer;
    }

    private void SubEventPlayer()
    {
        var playerObj = GameManager.instance.currentPlayer;
        if (playerObj.TryGetComponent<PlayerArmor>(out PlayerArmor armor))
        {
            _playerArmor = armor;
            _playerArmor.onPlayerArmorChanged += ShowArmorPlayer;
            _playerArmor.isPlayerArmorBuffed += ShowBuffArmorPlayer;
            ShowArmorPlayer(_playerArmor.ArmorStat);
        }
        if (playerObj.TryGetComponent<PlayerHealth>(out PlayerHealth health))
        {
            _playerHealth = health;
            _playerHealth.onPlayerHealthChanged += ShowHpPlayer;
            ShowHpPlayer(_playerHealth.Healths, _playerHealth.MaxHealths);
        }
        if (playerObj.TryGetComponent<ShootPlayerAbility>(out ShootPlayerAbility shoot))
        {
            _playerShoot = shoot;
            _playerShoot.onPlayerDamageChanged += ShowDamagePlayer;
            _playerShoot.onPlayerAmmoChanged += ShowAmmoPlayer;
            _playerShoot.onPlayerReloading += ShowIsReloadPlayer;
            _playerShoot.isPlayerDamageBuffed += ShowBuffDamagePlayer;
            _playerShoot.isPlayerWeaponBuffed += ShowBuffWeaponPlayer;
            ShowDamagePlayer(_playerShoot.Damage);
            ShowAmmoPlayer(_playerShoot.curAmmoCount, _playerShoot.startAmmoCount);
            ShowIsReloadPlayer(_playerShoot.isReloading);
        }
        if (playerObj.TryGetComponent<PlayerMovement>(out PlayerMovement move))
        {
            _playerMove = move;
            _playerMove.onPlayerSpeedChanged += ShowSpeedPlayer;
            _playerMove.isPlayerSpeedBuffed += ShowBuffSpeedPlayer;
            ShowSpeedPlayer(_playerMove.Speed);
        }
        if (playerObj.TryGetComponent<ExperiancePlayer>(out ExperiancePlayer exp))
        {
            _playerExp = exp;
            _playerExp.onPlayerLevelChanged += ShowLevelPlayer;
            ShowLevelPlayer(_playerExp.Level);
        }
    }

    private void ShowHpPlayer(float curHealth, float maxHealth)
    {
        _textHp.text = "Hp " + curHealth.ToString() + "/" + maxHealth.ToString();
    }

    private void ShowSpeedPlayer(float value)
    {
        _textSpeed.text = "Speed " + value.ToString();
    }
    private void ShowDamagePlayer(float value)
    {
        _textDamage.text = "Damage " + value.ToString();
    }

    private void ShowArmorPlayer(float value)
    {
        _textArmor.text = "Armor " + value.ToString();
    }

    private void ShowLevelPlayer(int value)
    {
        _textLevel.text = "Level " + value.ToString();
    }

    private void ShowAmmoPlayer(int curAmmo, int startAmmo)
    {
        _textAmmo.text = curAmmo.ToString() + "/" + startAmmo.ToString();
    }

    private void ShowIsReloadPlayer(bool isReload)
    {
        if (isReload) _textReload.text = "Reloading!!!";
        else _textReload.text = "";
    }

    private float _timeBuffDamage = 0;
    private float _timeBuffSpeed = 0;
    private float _timeBuffWeapon = 0;
    private float _timeBuffArmor = 0;

    private void ShowBuffDamagePlayer(float isBuffed)
    {
        _buffDamage.fillAmount = 1;
        _timeBuffDamage = isBuffed;
    }

    private void ShowBuffSpeedPlayer(float isBuffed)
    {
        _buffSpeed.fillAmount = 1;
        _timeBuffSpeed = isBuffed;
    }
    private void ShowBuffWeaponPlayer(float isBuffed)
    {
        _buffReload.fillAmount = 1;
        _timeBuffWeapon = isBuffed;
    }
    private void ShowBuffArmorPlayer(float isBuffed)
    {
        _buffArmor.fillAmount = 1;
        _timeBuffArmor = isBuffed;
    }

    private void Update()
    {
        _buffDamage.fillAmount -= 1.0f / _timeBuffDamage * Time.deltaTime;
        _buffSpeed.fillAmount -= 1.0f / _timeBuffSpeed * Time.deltaTime;
        _buffReload.fillAmount -= 1.0f / _timeBuffWeapon * Time.deltaTime;
        _buffArmor.fillAmount -= 1.0f/_timeBuffArmor * Time.deltaTime;
    }


}
