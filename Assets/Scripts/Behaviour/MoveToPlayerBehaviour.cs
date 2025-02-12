using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayerBehaviour : BehaviourComponent
{
    [SerializeField] private AnimController animController;
    private Transform _player;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    public override float Evaluate()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        if (GameManager.instance.currentPlayer != null)
        {
            if (GameManager.instance.currentPlayer.GetComponent<InvisibleAbility>().isInvisible) return 0f;
            _player = GameManager.instance.currentPlayer.transform;
            return 0.8f;
        } 
        return 0f;
    }
    public override void Behave()
    {
        navMeshAgent.destination = _player.position;
        if (animController != null) animController.Move(true);
    }
}
