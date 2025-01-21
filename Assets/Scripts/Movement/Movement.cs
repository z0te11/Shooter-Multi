using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    protected Rigidbody _rb;
    [SerializeField] protected bool isRotate;

    protected void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public virtual void Move(Vector2 dataPos)
    {
        var pos = this.transform.position;
        var newPos = new Vector3(dataPos.x * speed * Time.deltaTime * 50, 0, dataPos.y * speed * Time.deltaTime * 50);
        _rb.velocity = newPos;
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
        speed *= -1f;
    }
}
