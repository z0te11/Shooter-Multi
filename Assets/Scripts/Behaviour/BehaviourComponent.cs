using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BehaviourComponent : MonoBehaviour
{
    public virtual float Evaluate()
    {
        return 0f;
    }
    public virtual void Behave()
    {

    }
}
