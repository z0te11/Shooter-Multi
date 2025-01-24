using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleButton : MonoBehaviour
{
    private InvisibleAbility _invisAbility;
    public void UseInvisible()
    {
        if (GameManager.currnetPlayer != null)
        {
            if (_invisAbility == null) _invisAbility = GameManager.currnetPlayer.GetComponent<InvisibleAbility>();
            _invisAbility.Execute();
        }
    }
}
