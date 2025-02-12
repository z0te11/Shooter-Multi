using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoMovement : Movement
{
    public override void Move(Vector2 dataPos)
    {
        _rb.velocity = transform.forward * Speed * Time.deltaTime * 50;
    }

}
