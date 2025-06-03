using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosingPlayer : MonoBehaviour
{
    public GameObject[] variantPlayers;

    public void ShowPlayer(int number)
    {
        for (int i = 0; i < variantPlayers.Length; i++)
        {
            if (i == number) variantPlayers[i].SetActive(true);
            else variantPlayers[i].SetActive(false);
        }
    }
}
