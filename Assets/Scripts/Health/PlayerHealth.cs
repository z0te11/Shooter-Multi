using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Photon.Pun;

public class PlayerHealth : Health
{
    public Action<float, float> onPlayerHealthChanged;
    public override float Healths
    {
        get { return _health; }
        set { _health = value;
              onPlayerHealthChanged?.Invoke(_health, MaxHealths);}
    }

    public override float MaxHealths
    {
        get { return _maxHealth; }
        set { _maxHealth = value;
              onPlayerHealthChanged?.Invoke(Healths, _maxHealth);}
    }

    private void Start()
    {
        if (TryGetComponent<CharacterData>(out CharacterData statsData))
        {
            MaxHealths = statsData.playerStatsSettings.livesStat;
            Healths = statsData.playerStatsSettings.livesStat;
        }  
    }

    public override void Die()
    {
        base.Die();
        GetComponent<PlayerInput>().enabled = false;
        GetComponent<Collider>().enabled = false;
        if (CheckPhotonMine()) PhotonNetwork.Destroy(gameObject);
    }

    private bool CheckPhotonMine()
    {
        return GetComponent<PhotonView>().IsMine;
    }

}
