using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : BehaviourComponent
{
    [SerializeField] private AnimController animController;
    [SerializeField] public float distanceToAttack;
    [SerializeField] private float _attackDelay;
    protected AbilityTarget[] _abilitysTarget;
    protected Ability[] _abilitys;
    protected List<AbilityType> abilityTypeList = new List<AbilityType>();
    private Transform _player;
    private float _attackTime = float.MinValue;

    private void Start()
    {
        _abilitysTarget = GetComponents<AbilityTarget>();
        _abilitys = GetComponents<Ability>();
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

            if (dist < distanceToAttack) return 0.9f;
        } 
        return 0f;
    }

    public override void Behave()
    {
        if (_player != null) Rotate(_player);
        if (Time.time < _attackTime + _attackDelay) return;

        _attackTime = Time.time;
        UseAbilitysTargets(_player.gameObject);
        UseAbilities();
        Debug.Log("Enemy Attack");
        if (animController != null) animController.Move(false);
        if (animController != null) animController.Attack();
    }

    protected void Rotate(Transform target)
    {
        transform.LookAt(target);
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
}
