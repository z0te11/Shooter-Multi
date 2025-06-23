using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform _player;
    private void OnEnable()
    {
        GameManager.onPlayerSpawn += StartFolowPlayer;
    }

    private void OnDisable()
    {
        GameManager.onPlayerSpawn -= StartFolowPlayer;
    }

    private void StartFolowPlayer(GameObject player)
    {
        _player = player.transform;
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
