using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliding : MonoBehaviour {
    private Rigidbody rb;
    private float StunCounter;
    private float SlowCounter;
    public float StunDuration;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        StunCounter = 0;
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if(collision.other.tag == "StandardClashObject")
        {
            GetComponent<Walking>().Stunned = true;
            StunCounter = StunDuration;
            collision.other.tag = "InactiveObject";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TripObject")
        {
            GetComponent<Walking>().Slowed = true;
            SlowCounter = StunDuration;
            other.tag = "InactiveObject";
        }
    }
    // Update is called once per frame
    void Update () {
		
	}

    private void FixedUpdate()
    {
        if(GetComponent<Walking>().Stunned == true)
        {
            StunCounter -= Time.fixedDeltaTime;

            if(StunCounter <= 0)
            {
                GetComponent<Walking>().Stunned = false;
            }
         }
        if(GetComponent<Walking>().Slowed == true)
        {
            SlowCounter -= Time.fixedDeltaTime;

            if(SlowCounter <= 0)
            {
                GetComponent<Walking>().Slowed = false;
            }
        }
    }
}
