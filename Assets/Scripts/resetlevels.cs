using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetlevels : MonoBehaviour
{
    Player player;
    void Start()
    {
        player = gameObject.GetComponent<Player>();
    }

    public void resetlevelselector()
    {
        player.unlock = 0;
        player.SavePlayer();
    }
}
