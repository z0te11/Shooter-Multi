using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitBehaviour : BehaviourComponent
{
    [SerializeField] private AnimController animController;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    public override float Evaluate()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        return 0.5f;
    }
    public override void Behave()
    {
        if (animController != null) animController.Move(false);
        navMeshAgent.destination = this.transform.position;
    }

}
