using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHideObj : MonoBehaviour
{
    [SerializeField] private Shader _invisibleShader;
    private Transform _player;
    private List<GameObject> _hiddenGoList = new List<GameObject>();

    private void OnEnable()
    {
        SpawnSystem.onPlayerSpawn += StartPlayer;
    }

    private void OnDisable()
    {
        SpawnSystem.onPlayerSpawn -= StartPlayer;
    }

    private void StartPlayer()
    {
        _player = GameManager.instance.currentPlayer.transform;
    }

    private void Update()
    {
        if (_player != null)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            Debug.DrawRay(transform.position, transform.forward, Color.green);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject.GetComponent<ShaderSwitcher>() && !IsGoInList(hit.collider.gameObject))
                {
                    HideObjects(hit.collider.gameObject);
                }
                else if (!IsGoInList(hit.collider.gameObject))
                {
                    ShowObjects();
                }
            }
        }
    }

    private void HideObjects(GameObject go)
    {
        Debug.Log("Hide" + go.name);
        go.GetComponent<ShaderSwitcher>().ChangeShader(_invisibleShader);
        _hiddenGoList.Add(go);
    }

    private void ShowObjects()
    {
        if (_hiddenGoList.Count <= 0) return;

        for (int i = 0; i < _hiddenGoList.Count; i++)
        {
            _hiddenGoList[i].GetComponent<ShaderSwitcher>().UseDefaultShader();
            Debug.Log("ShowObject" + _hiddenGoList[i].name);
            _hiddenGoList.Remove(_hiddenGoList[i]);
        }
    }

    private bool IsGoInList(GameObject go)
    {
        if (_hiddenGoList.Count <= 0) return false;

        for (int i = 0; i < _hiddenGoList.Count; i++)
        {
            if (go == _hiddenGoList[i]) return true;
        }
        return false;
    }
}
