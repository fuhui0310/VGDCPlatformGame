using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerP : MonoBehaviour {
    public string sceneName;
    public int level;

    AudioSource audioData;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    IEnumerator PlaySound()
    {
        audioData.PlayOneShot(audioData.clip);

        yield return new WaitForSeconds(audioData.clip.length);

        SceneManager.LoadScene(sceneName);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(PlaySound());
        }
    }
}
