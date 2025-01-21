using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    protected AbilityTarget[] _abilitysTarget;
    protected Ability[] _abilitys;
    [SerializeField] protected bool isAlwaysUseAbilities = false;
    [SerializeField] protected bool isCanInteractWithPlayer = false;
    [SerializeField] protected bool isInteractOnlyWithPlayer = false;
    [SerializeField] protected bool isInteractOnlyWithUnit = false;
    protected List<AbilityType> abilityTypeList = new List<AbilityType>();


    protected void Start()
    {
        _abilitysTarget = GetComponents<AbilityTarget>();
        _abilitys = GetComponents<Ability>();

        for (int i = 0; i < _abilitysTarget.Length; i++)
        {
            abilityTypeList.Add(_abilitysTarget[i].Type);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        TryInteract(collision.gameObject);
    }

    protected void TryInteract(GameObject go)
    {
        bool isPlayer = go.GetComponent<PlayerUnit>();

        if (isPlayer == false && isInteractOnlyWithPlayer == true) return;
        if (isPlayer == true && isCanInteractWithPlayer == false) return;

        bool isUnit = go.GetComponent<Unit>();

        if (isUnit == false && isInteractOnlyWithUnit == true) return;

        Interact(go);
    }

    protected void Interact(GameObject go)
    {
        Debug.Log(go);
        if (CanIntearctWithObject(go))
        {
            UseAbilitysTargets(go);
            UseAbilities();
            return;
        }
        if (isAlwaysUseAbilities) UseAbilities();
    }

    protected void UseAbilitysTargets(GameObject target)
    {
        for (int i = 0; i < _abilitysTarget.Length; i++)
        {
            if (_abilitysTarget[i] != null) _abilitysTarget[i].Execute(target);
        }
    }

    protected void UseAbilities()
    {
        for (int i = 0; i < _abilitys.Length; i++)
        {
            if (_abilitys[i] != null) _abilitys[i].Execute();
        }
    }

    protected bool CanIntearctWithObject(GameObject go)
    {
        IType[] array = go.GetComponents<IType>();
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < abilityTypeList.Count; j++)
            {
                if (array[i].Type == abilityTypeList[j]) return true;
            } 
        }
        return false;
    }

}
