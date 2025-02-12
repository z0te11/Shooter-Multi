using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Action<float> onPlayerSpeedChanged;
    [SerializeField] protected float _speed;
    [SerializeField] protected bool isRotate;
    protected Rigidbody _rb;
    public float Speed
    {
        get { return _speed; }
        set { _speed = value;
             onPlayerSpeedChanged?.Invoke(_speed);}
    }

    protected void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public virtual void Move(Vector2 dataPos)
    {
        var pos = this.transform.position;
        var newPos = new Vector3(dataPos.x * Speed * Time.deltaTime * 50, 0, dataPos.y * Speed * Time.deltaTime * 50);
        if (_rb != null) _rb.velocity = newPos;
        if (isRotate) Rotate(newPos);
    }

    protected void Rotate(Vector3 dir)
    {
        if (dir != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 0.5f);
        }
    }
    public virtual void ChangeDir()
    {
        Speed *= -1f;
    }

    public virtual void UpSpeed(float value)
    {
        Speed += value;
    }
}
