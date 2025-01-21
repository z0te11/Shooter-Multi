using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform _player;
    private void OnEnable()
    {
        GameManager.onGameStarted += StartFolowPlayer;
    }

    private void OnDisable()
    {
        GameManager.onGameStarted -= StartFolowPlayer;
    }

    private void StartFolowPlayer()
    {
        _player = GameManager.currnetPlayer.transform;
    }

    private void Update()
    {
        if (_player != null)
        {
            MoveCameraTo(_player);
        }
    }

    private void MoveCameraTo(Transform target)
    {
        var p = target.transform.position;
        this.transform.position = new Vector3(p.x, p.y + 15f, p.z - 13f);
    }

}
