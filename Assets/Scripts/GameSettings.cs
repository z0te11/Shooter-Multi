using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings
{
    public float roundTime;
    public int roundDifficluty;

    public GameSettings()
    {
        roundTime = 60f;
        roundDifficluty = 1;
        Debug.Log("GameSettings");
    }

}
