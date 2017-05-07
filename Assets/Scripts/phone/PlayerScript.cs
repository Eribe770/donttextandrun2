using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public GameObject camera;
    public GameObject phone;
    public GameObject markerSphere;
    public float animationSpeed = 1.0f;
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
    public Vector3 worldPosition;
    public Vector3 phonePosition;
    public States state;

    public float movePhoneDistance = 1.0f;
    private float socialPoints;

    // Use this for initialization
    void Start ()
    {

        socialPoints = 0;

        state = States.world;

        phoneLookAt = new Quaternion();
        worldLookAt = new Quaternion();

        worldLookAt = Quaternion.Euler(0, 0, 0);
        phoneLookAt = Quaternion.Euler(+60, 0, 0);
        //phoneLookAt = Quaternion.AngleAxis(45f, camera.transform.right);

        worldPosition = phone.transform.localPosition;
        phonePosition = markerSphere.transform.localPosition;
        //phonePosition = Vector3.MoveTowards(phone.transform.localPosition, camera.transform.localPosition, movePhoneDistance);
        //phonePosition = new Vector3(0, 0.298f, 0.2f);

    }

    // Update is called once per frame
    void Update () {

        if (state == States.phone)
        {
            socialPoints += Time.deltaTime;
        }

        // Key input stuff
		if (Input.GetKeyDown(KeyCode.Space) && !transitioning)
        {
            if (state != States.phone)
            {
                transitioning = true;
                t = 0;
                state = States.worldToPhone;
                // BroadcastMessage("PhoneState");
            }
            else
            {
                transitioning = true;
                t = 0;
                state = States.phoneToWorld;
                // BroadcastMessage("WorldState");
            }
        }


        // Animation stuff


        if (transitioning)
        {
            t += Time.deltaTime * animationSpeed;

            if (state == States.worldToPhone)
            {
                phone.transform.localPosition = Vector3.Lerp(worldPosition, phonePosition, t);
                camera.transform.localRotation = Quaternion.Lerp(worldLookAt, phoneLookAt, t);
                
                if (t >= 1)
                {
                    state = States.phone;
                    BroadcastMessage("StatePhone");
                    transitioning = false;
                }

            }

            if (state == States.phoneToWorld)
            {
                phone.transform.localPosition = Vector3.Lerp(phonePosition, worldPosition, t);
                camera.transform.localRotation = Quaternion.Lerp(phoneLookAt, worldLookAt, t);

                if (t >= 1)
                {
                    state = States.world;
                    BroadcastMessage("StateWorld");
                    transitioning = false;
                }

            }

        }
    }
}
