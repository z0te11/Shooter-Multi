using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TopDownTrap : StaticUnit
{
    [SerializeField] public Vector3 newPos;
    [SerializeField] private float _timeToBack;
    [SerializeField] private CollisionHandler _collisionHandler;
    private Vector3 _startPos;


    private void Start()
    {
        _startPos = transform.position;
        _collisionHandler.isCanInteractWithAll = false;
        StartMoving();
    }

    private void StartMoving()
    {
        _collisionHandler.isCanInteractWithAll = false;
        Sequence sequence = DOTween.Sequence();
        sequence.PrependInterval(_timeToBack);
        sequence.Append(transform.DOLocalMove(newPos, 3f, false)).OnComplete(FinishMoving);
    }

    private void FinishMoving()
    {
        _collisionHandler.isCanInteractWithAll = true;
        Sequence sequence = DOTween.Sequence();
        sequence.PrependInterval(_timeToBack);
        sequence.Append(transform.DOMove(_startPos, 0.5f, false)).OnComplete(StartMoving);;
    }

}
