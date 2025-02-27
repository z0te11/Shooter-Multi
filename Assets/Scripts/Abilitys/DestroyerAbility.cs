using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DestroyerAbility : Ability
{
    public override void Execute()
    {
        if (CheckPhotonMine())
        {
            PhotonNetwork.Destroy(this.gameObject);
        }
    }

    private bool CheckPhotonMine()
    {
        return GetComponent<PhotonView>().IsMine;
    }
}
