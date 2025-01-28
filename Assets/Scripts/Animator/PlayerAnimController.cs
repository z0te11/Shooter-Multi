using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using System;

public class PlayerAnimController : AnimController
{
    public void MovePlayer(Vector2 dataPos, float speed)
    {
        animator.SetBool("Walking", Mathf.Abs(dataPos.x) > 0.05f || Mathf.Abs(dataPos.y) > 0.05f);
        animator.SetFloat("speedWalking", speed * math.distancesq(dataPos.x, dataPos.y) / 2);
    }
}
