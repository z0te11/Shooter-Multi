using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDieExperiance : MonoBehaviour, IDie
{
    public int experianceValue;
    public void OnDie()
    {
        GameManager.instance.currentPlayer.GetComponent<ExperiancePlayer>().AddExperiance(experianceValue);
    }
}
