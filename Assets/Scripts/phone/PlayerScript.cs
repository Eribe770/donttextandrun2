using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public GameObject camera;
    private Quaternion phoneLookAt;
    private Quaternion worldLookAt;
    private float t;
    private bool transitioning;
    public enum States
    {
        phoneToWorld,
        worldToPhone,
        phone,
        world
    }

    public States state;

	// Use this for initialization
	void Start ()
    {
        state = States.world;

        phoneLookAt = new Quaternion();
        worldLookAt = new Quaternion();

        worldLookAt = Quaternion.Euler(0, 0, 0);
        phoneLookAt = Quaternion.Euler(+45, 0, 0);
        //phoneLookAt = Quaternion.AngleAxis(45f, camera.transform.right);
        
    }
	
	// Update is called once per frame
	void Update () {

        // Key input stuff
		if (Input.GetKeyDown(KeyCode.Space) && !transitioning)
        {
            if (state != States.phone)
            {
                transitioning = true;
                t = 0;
                state = States.worldToPhone;
                BroadcastMessage("PhoneState");
            }
            else
            {
                transitioning = true;
                t = 0;
                state = States.phoneToWorld;
                BroadcastMessage("WorldState");
            }
        }


        // Animation stuff


        if (transitioning)
        {
            if (state == States.worldToPhone)
            {
                camera.transform.localRotation = Quaternion.Lerp(worldLookAt, phoneLookAt, t);
                t += Time.deltaTime;
                if (t >= 1)
                {
                    state = States.phone;
                    transitioning = false;
                }

            }

            if (state == States.phoneToWorld)
            {
                camera.transform.localRotation = Quaternion.Lerp(phoneLookAt, worldLookAt, t);
                t += Time.deltaTime;
                if (t >= 1)
                {
                    state = States.world;
                    transitioning = false;
                }

            }

        }
    }
}
