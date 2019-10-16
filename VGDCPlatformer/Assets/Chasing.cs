using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : MonoBehaviour {

    public Transform[] patrolPoints;
    public float speed;
    Transform currentPatrolPoint;
    int currentPatrolIntex;
    public Respawn respawn;

    public Transform target;
    public float chaseRange;

	// Use this for initialization
	void Start () {
        currentPatrolIntex = 0;
        currentPatrolPoint = patrolPoints[currentPatrolIntex];
		
	}

    // Update is called once per frame
    void Update() {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget < chaseRange)
        {
            Vector3 targetDir = target.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Hit player");
            respawn.Reload();
        }
    }

}
