using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayerBehaviour : BehaviourComponent
{
    private Transform _player;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    public override float Evaluate()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        if (GameManager.currnetPlayer != null)
        {
            _player = GameManager.currnetPlayer.transform;
            return 1f;
        } 
        return 0f;
    }
    public override void Behave()
    {
        navMeshAgent.destination = _player.position;
    }
}
