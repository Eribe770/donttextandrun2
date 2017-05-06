using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {
    public float TimeLimit;
    private float TimeLeft = 100f;
    private Text Counter;
	// Use this for initialization
	void Start () {
	}

    private void FixedUpdate()
    {
        Debug.Log("but why");
        TimeLeft -= Time.fixedDeltaTime;
        GetComponent<Text>().text = "Time left: " + TimeLeft;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
