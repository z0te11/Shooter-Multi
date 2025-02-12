using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleButton : MonoBehaviour
{
    private InvisibleAbility _invisAbility;
    public void UseInvisible()
    {
        if (GameManager.instance.currentPlayer != null)
        {
            if (_invisAbility == null) _invisAbility = GameManager.instance.currentPlayer.GetComponent<InvisibleAbility>();
            _invisAbility.Execute();
        }
    }
}
