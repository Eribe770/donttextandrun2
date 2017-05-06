using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public GameObject camera;
    private Quaternion phoneLookAt;
    private Quaternion worldLookAt;
    private float t;
    private bool transitioning;
    private enum States
    {
        phoneToWorld,
        worldToPhone,
        phone,
        world
    }
    private States state;

	// Use this for initialization
	void Start ()
    {
        phoneLookAt = new Quaternion();
        worldLookAt = new Quaternion();

        worldLookAt = Quaternion.Euler(0, 0, 0);
        phoneLookAt = Quaternion.Euler(+45, 0, 0);
        //phoneLookAt = Quaternion.AngleAxis(45f, camera.transform.right);

        state = States.world;
    }

    // Update is called once per frame
    void Update () {
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
                    state = States.phone;
                    transitioning = false;
                }

            }

        }
	}

    void PhoneState()
    {
        //camera.transform.localRotation = phoneLookAt;
        state = States.worldToPhone;
        transitioning = true;
        t = 0;
    }

    void WorldState()
    {
        state = States.phoneToWorld;
        transitioning = true;
        t = 0;
        //camera.transform.localRotation = worldLookAt;
    }
}
