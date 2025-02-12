using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDieManager : MonoBehaviour
{
    public List<MonoBehaviour> dieActions;

    public void Execute()
    {
        foreach (var action in dieActions)
        {
            if (!(action is IDie die)) return;
            die.OnDie();
        }        
    }
}
