using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DestroyerAbility : Ability
{
    public override void Execute()
    {
        PhotonNetwork.Destroy(gameObject);
    }
}
