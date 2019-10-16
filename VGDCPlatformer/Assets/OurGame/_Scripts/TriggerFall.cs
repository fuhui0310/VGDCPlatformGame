using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFall : MonoBehaviour {

    public int fall = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            fall = 1;
        } 
    }
    private void Update()
    {
        if (fall == 1)
        {
            Rigidbody2D gravity = gameObject.GetComponentInChildren<Rigidbody2D>();
            gravity.isKinematic = false;
            Transform speed = gameObject.GetComponentInChildren<Transform>();
            speed.Translate(Vector2.down * 0.3f);

        }
        if (fall == 2)
        {
            Destroy(gameObject);

        }
    }
    
}
