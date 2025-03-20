using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Photon.Pun;

public class PlayerHealth : Health
{
    public Action<float> onPlayerHealthChanged;
    public override float Healths
    {
        get { return _health; }
        set { _health = value;
              onPlayerHealthChanged?.Invoke(_health);}
    }

    public override void SetHealth(int health)
    {
        Healths = health;
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
