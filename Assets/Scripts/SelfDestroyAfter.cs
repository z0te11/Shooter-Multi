using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyAfter : MonoBehaviour
{
    [SerializeField] private float sec;

    private void Start()
    {
        Destroy(gameObject, sec);
    }
}
