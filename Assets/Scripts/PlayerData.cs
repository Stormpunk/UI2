using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int points;
    // Start is called before the first frame update
 public PlayerData (MenuHandler player)
    {
        points = player.points;
    }
}
