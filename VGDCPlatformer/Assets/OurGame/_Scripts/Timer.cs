using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public int timeLeft = 5;
    public Text countdownText;
    public Respawn respawn;

    // Use this for initialization
    void Start () {
        StartCoroutine("LoseTime");
	}

    // Update is called once per frame
    void Update() {
        countdownText.text = ("Time Left = " + timeLeft);
        if (timeLeft <= 0)
        {
            StopCoroutine("LoseTime");
            respawn.Reload();
        }
    }

        IEnumerator LoseTime()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                timeLeft--;
            }
        }
	}
