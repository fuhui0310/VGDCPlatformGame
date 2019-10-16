using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    public Transform mSpawnPoint; // Place player respawns

    public Transform mCamera; // the camera

    public float mFallLimit; // how far player is allowed to fall

    public BlockPlace blockPlace; // For destroying blocks created

    public PlayerMove mover;

    AudioSource audioData;

    // Use this for initialization
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        mSpawnPoint.position = new Vector3(transform.position.x, transform.position.y, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // If the player falls too far or hits the r key, destroy all created blocks and return to where the spawn point is set.
        if (transform.position.y < mFallLimit || Input.GetKeyDown("r")) // respawn if fallen too far or the r key is pressed
        {

            Reload();
            /**transform.position = new Vector3(mSpawnPoint.position.x, mSpawnPoint.position.y, 0.0f);

            mCamera.position = new Vector3(0.0f, 0.0f, mCamera.position.z);

            while(blockPlace.placedBlocks.Count > 0)
            {
                Destroy(blockPlace.placedBlocks[0]);
                blockPlace.placedBlocks.RemoveAt(0);
            }**/
        }
	}

    IEnumerator Dead()
    {
        mover.runSpeed = 0.0f;
        mover.controller.m_JumpForce = 0.0f;
        mover.controller.m_FallGravity = 0.0f;
        GameObject[] music = GameObject.FindGameObjectsWithTag("Music");
        foreach (GameObject mus in music)
        {
            mus.GetComponent<AudioSource>().Stop();
        }

        audioData.PlayOneShot(audioData.clip);

        yield return new WaitForSeconds(1);

        Application.LoadLevel(Application.loadedLevel); // Reloads the scene, returning everything back to how it was originally
    }

    public void Reload()
    {
        StartCoroutine(Dead());
    }
}
