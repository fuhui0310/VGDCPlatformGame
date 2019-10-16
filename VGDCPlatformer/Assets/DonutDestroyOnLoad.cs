using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutDestroyOnLoad : MonoBehaviour
{
    void Awake()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("block");
        GameObject[] placers = GameObject.FindGameObjectsWithTag("blockPlacer");
        GameObject[] cursors = GameObject.FindGameObjectsWithTag("cursor");

        if (players.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else if (blocks.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else if (placers.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else if (cursors.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
