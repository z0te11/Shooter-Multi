using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarItems : MonoBehaviour
{
    [SerializeField] private GameObject root;
    public void CreateItem(GameObject go, GameObject whoTarget = null)
    {
        var newItem = Instantiate(go, root.transform, false);
        var itemAbility = newItem.GetComponent<ItemAbility>();
        if (itemAbility != null)
        {
            if (whoTarget != null) itemAbility.target = whoTarget;
            else itemAbility.target = GameManager.instance.currentPlayer;
        }
    }
}
