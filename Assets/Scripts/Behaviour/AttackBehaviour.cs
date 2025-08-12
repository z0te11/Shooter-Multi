using System.Collections.Generic;
using System.Linq;
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
    private List<GameObject> _playersGO;
    private float _attackTime = float.MinValue;

    private void Awake()
    {
        _playersGO = GameObject.FindGameObjectsWithTag("Player").ToList<GameObject>();
    }
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
        if (FindTarget() != null)
        {
            _player = FindTarget().transform;
            if (_player.gameObject.GetComponent<InvisibleAbility>().isInvisible) return 0f;
            //_player = GameManager.instance.GetPlayer().transform;

            float dist = Vector3.Distance(_player.position, transform.position);

            if (dist < distanceToAttack) return 0.8f;
        } 
        return 0f;
    }

    private GameObject FindTarget()
    {
        float dist = 1000f;
        GameObject newTarget = null;
        foreach (var player in _playersGO)
        {
            float playerDist = Vector3.Distance(player.transform.position, transform.position);
            if (playerDist < dist)
            {
                dist = playerDist;
                newTarget = player;
            }
        }
        return newTarget;
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
