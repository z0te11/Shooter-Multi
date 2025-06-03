using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    [SerializeField] protected float _speed;
    [SerializeField] protected bool isRotateAim;
    protected Rigidbody _rb;
    public virtual float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    protected void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        if (TryGetComponent<CharacterData>(out CharacterData statsData))
        {
            Speed = statsData.playerStatsSettings.speedStat;
        }
    }

    private void Update()
    {
        if (isRotateAim) RotateToAim();
    }

    public virtual void Move(Vector2 dataPos)
    {
        var pos = this.transform.position;
        var newPos = new Vector3(dataPos.x * Speed * Time.deltaTime * 50, 0, dataPos.y * Speed * Time.deltaTime * 50);
        if (_rb != null) _rb.velocity = newPos;
        if (!isRotateAim) Rotate(newPos);
    }

    protected void Rotate(Vector3 dir)
    {
        if (dir != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 0.5f);
        }
    }

    protected void RotateToAim()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Vector3 targetDirection = hitInfo.point - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
            transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
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
