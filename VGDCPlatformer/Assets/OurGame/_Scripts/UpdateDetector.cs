using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateDetector : MonoBehaviour {

    public float mCameraViewWidth;
    public float mCameraViewHeight;
    public float mForwardMove;

	// Use this for initialization
	void Start ()
    {
        Debug.Log("Testing Debug Log");
        transform.position = new Vector3(transform.parent.position.x + mCameraViewWidth, transform.parent.position.y + mCameraViewHeight, mForwardMove);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    // Called when Player collider collides with detector
    void OnTriggerEnter2D(Collider2D other)
    {
        float origSpeed;
        // If the player runs into a detector, move the camera and detectors appropriately
        if(other.gameObject.CompareTag("Player"))
        {
            origSpeed = other.gameObject.GetComponent<PlayerMovementBeginner>().runSpeed;

            if (mCameraViewWidth > 0)
            {
                other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x + .6f, other.gameObject.transform.position.y, other.gameObject.transform.position.z);
                StartCoroutine(LeftOrRight(other.gameObject));
            }
            else if(mCameraViewWidth < 0)
            {
                other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x - .6f, other.gameObject.transform.position.y, other.gameObject.transform.position.z);
                StartCoroutine(LeftOrRight(other.gameObject));
            }

            if (mCameraViewHeight > 0)
            {
                other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y + .6f, other.gameObject.transform.position.z);
                StartCoroutine(UpOrDown());  
            }
            else if(mCameraViewHeight < 0)
            {
                other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y - .6f, other.gameObject.transform.position.z);
                StartCoroutine(UpOrDown());
            }
            other.gameObject.GetComponent<PlayerMovementBeginner>().runSpeed = origSpeed;
        }
        
    }

    // Slowly moves the camera over 11 units left or right
    IEnumerator LeftOrRight(GameObject player)
    {
        float count = 0;
        while(count < 110)
        {
            player.GetComponent<PlayerMovementBeginner>().runSpeed = 0.0f;

            if (mCameraViewWidth > 0)
                transform.parent.position = new Vector3(transform.parent.position.x + .2f, transform.parent.position.y, transform.parent.position.z);
            else
                transform.parent.position = new Vector3(transform.parent.position.x - .2f, transform.parent.position.y, transform.parent.position.z);

            count++;
            yield return new WaitForSecondsRealtime(.01f);
        }
        player.GetComponent<PlayerMovementBeginner>().runSpeed = 40.0f;
    }

    // slowly moves the camera up or down 6 units
    IEnumerator UpOrDown()
    {
        float count = 0;
        while (count < 60)
        {
            if (mCameraViewHeight > 0)
                transform.parent.position = new Vector3(transform.parent.position.x, transform.parent.position.y + .2f, transform.parent.position.z);
            else
                transform.parent.position = new Vector3(transform.parent.position.x, transform.parent.position.y - .2f, transform.parent.position.z);

            count++;
            yield return new WaitForSecondsRealtime(.01f);
        }
    }

}
