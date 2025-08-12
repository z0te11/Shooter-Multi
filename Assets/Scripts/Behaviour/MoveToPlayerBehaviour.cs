using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPlayerBehaviour : BehaviourComponent
{
    [SerializeField] public float distanceToPlayer;
    [SerializeField] private AnimController animController;
    [SerializeField] private float _speed;
    private GameObject _target;
    private NavMeshAgent _navMeshAgent;
    private List<GameObject> _playersGO;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playersGO = GameObject.FindGameObjectsWithTag("Player").ToList<GameObject>();
    }

    public override float Evaluate()
    {
        _target = FindTarget();
        if (_target == null) return 0f;

        if (_target.TryGetComponent<InvisibleAbility>(out InvisibleAbility invisAbil))
        {
            if (invisAbil.isInvisible) return 0f;
        }

        float dist = Vector3.Distance(_target.transform.position, transform.position);

        if (dist > distanceToPlayer) return 0.5f;
        return 0f;
    }
    public override void Behave()
    {
        if (FindTarget() != null)
        {
            _navMeshAgent.destination = _target.transform.position;
            _navMeshAgent.speed = _speed;
        }
        if (animController != null) animController.Move(true);
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
}
