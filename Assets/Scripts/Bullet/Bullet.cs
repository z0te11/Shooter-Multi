using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody _rb;

    [SerializeField] private Movement _moveComp;

    protected void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    protected void FixedUpdate()
    {
        if (_moveComp != null) _moveComp.Move(Vector3.forward);
    }

}
