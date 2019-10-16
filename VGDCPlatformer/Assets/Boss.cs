using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {
    public Respawn respawn;
    public float slowSpeed;
    public int slowingTime;
    private int count = 0;

    [SerializeField]
    private Transform[] waypoints;

    [SerializeField]
    public float moveSpeed;

    private int waypointIndex = 0;
    // Use this for initialization
    void Start()
    {

        transform.position = waypoints[waypointIndex].transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (count <= 0)
        {
            StopCoroutine("LoseTime");
            Move();
        }
        else
        {
            StartCoroutine("LoseTime");
            SlowMove();
        }
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            count--;
        }
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
            // Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "CrushBlock")
        {
            transform.Translate(Vector3.down * Time.deltaTime * slowSpeed);
            count = slowingTime;
        }
    }

    private void Move()
    {
        if(waypointIndex <= waypoints.Length - 1)
        {
            Vector3 targetDir = waypoints[waypointIndex].transform.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
            if(transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
    }

    private void SlowMove()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {
            Vector3 targetDir = waypoints[waypointIndex].transform.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, slowSpeed * Time.deltaTime);
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
    }
}