using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class InventarItems : MonoBehaviour
{
    [SerializeField] private GameObject root;
    public void CreateItem(GameObject go, GameObject whoTarget = null)
    {
        var newItem = PhotonNetwork.Instantiate(go.name, root.transform.position, Quaternion.identity);
        var itemAbility = newItem.GetComponent<ItemAbility>();
        newItem.transform.SetParent(root.transform, false); 
        if (itemAbility != null)
        {
            if (whoTarget != null) itemAbility.target = whoTarget;
            else itemAbility.target = GameManager.instance.currentPlayer;
        }
    }
}
