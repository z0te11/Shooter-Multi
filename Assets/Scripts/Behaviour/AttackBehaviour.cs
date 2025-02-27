using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : BehaviourComponent
{
    [SerializeField] private AnimController animController;
    [SerializeField] private float attackDelay;
    protected AbilityTarget[] _abilitysTarget;
    protected List<AbilityType> abilityTypeList = new List<AbilityType>();
    private Transform _player;
    private float _attackTime = float.MinValue;

    private void Start()
    {
        _abilitysTarget = GetComponents<AbilityTarget>();
        for (int i = 0; i < _abilitysTarget.Length; i++)
        {
            abilityTypeList.Add(_abilitysTarget[i].Type);
        }
    }
    public override float Evaluate()
    {
        if (GameManager.instance.currentPlayer != null)
        {
            if (GameManager.instance.currentPlayer.GetComponent<InvisibleAbility>().isInvisible) return 0f;
            _player = GameManager.instance.currentPlayer.transform;

            float dist = Vector3.Distance(_player.position, transform.position);

            if (dist < 1f) return 0.9f;
        } 
        return 0f;
    }
    public override void Behave()
    {
        if (Time.time < _attackTime + attackDelay) return;

        _attackTime = Time.time;
        UseAbilitysTargets(_player.gameObject);
        if (animController != null) animController.Attack();
    }

    protected void UseAbilitysTargets(GameObject target)
    {
        for (int i = 0; i < _abilitysTarget.Length; i++)
        {
            if (_abilitysTarget[i] != null) _abilitysTarget[i].Execute(target);
        }
    }
}
