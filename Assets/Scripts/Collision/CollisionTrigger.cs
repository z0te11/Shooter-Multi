using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : CollisionHandler
{

    private void OnTriggerEnter(Collider other)
    {
        TryInteract(other.gameObject);
    }
} 
