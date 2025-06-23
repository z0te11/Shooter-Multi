using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPlayerBehaviour : BehaviourComponent
{
    [SerializeField] public float distanceToPlayer;
    [SerializeField] private AnimController animController;
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

        if (dist > distanceToPlayer) return 0.8f;
        return 0f;
    }
    public override void Behave()
    {
        if (FindTarget() != null) _navMeshAgent.destination = _target.transform.position;
        if (animController != null) animController.Move(true);
    }

    private GameObject FindTarget()
    {
        float dist = 0f;
        GameObject newTarget = null;
        foreach (var player in _playersGO)
        {
            float playerDist = Vector3.Distance(player.transform.position, transform.position);
            if (playerDist > dist)
            {
                dist = playerDist;
                newTarget = player;
            }
        }
        //if (GameManager.instance.GetPlayer() != null) return GameManager.instance.GetPlayer();
        return newTarget;
    }
}
