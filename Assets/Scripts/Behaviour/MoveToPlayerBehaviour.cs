using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPlayerBehaviour : BehaviourComponent
{
    [SerializeField] public float distanceToPlayer;
    [SerializeField] private AnimController animController;
    private Transform _target;
    private NavMeshAgent _navMeshAgent;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public override float Evaluate()
    {
        if (_target == null) FindTarget();

        if (_target.TryGetComponent<InvisibleAbility>(out InvisibleAbility invisAbil))
        {
            if (invisAbil.isInvisible) return 0f;
        }

        float dist = Vector3.Distance(_target.position, transform.position);

        if (dist > distanceToPlayer) return 0.8f;
        return 0f;
    }
    public override void Behave()
    {
        _navMeshAgent.destination = _target.position;
        if (animController != null) animController.Move(true);
    }

    private void FindTarget()
    {
        _target = GameManager.instance.currentPlayer.transform;
    }
}
