using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemUI : MonoBehaviour
{
    private Ability[] _abilitys;

    private void OnEnable()
    {
        _abilitys = GetComponents<Ability>();
    }

	public void UseItem()
	{
		UseAbilities();
        Debug.Log("Use Item");
	}

    protected void UseAbilities()
    {
        for (int i = 0; i < _abilitys.Length; i++)
        {
            if (_abilitys[i] != null) _abilitys[i].Execute();
        }
    }   
}
