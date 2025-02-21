using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EnemyHealth : Health
{
    public override void Die()
    {
        base.Die();
        GetComponent<BehaviourManager>().enabled = false;
        GetComponent<Collider>().enabled = false;
        StartCoroutine(Dieing(5f));
        
    }

    private IEnumerator Dieing(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        PhotonNetwork.Destroy(gameObject);
    }
}
