using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushBlockCollision : MonoBehaviour
{
    public Respawn respawn;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            respawn.Reload();
        }
        else if (collision.gameObject.tag == "environment")
        {
            Destroy(gameObject);
        }
    }
}
