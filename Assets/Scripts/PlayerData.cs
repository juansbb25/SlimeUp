using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData 
{
    public int unlock;
    public PlayerData(Player player)
    {
        unlock = player.unlock;
    }

}

