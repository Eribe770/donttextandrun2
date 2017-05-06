using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneScript : MonoBehaviour {
    public GameObject phone;
    public Quaternion phoneRotation;
    public Quaternion worldRotation;

    public Vector3 worldPosition;
    public Vector3 phonePosition;

    // Use this for initialization
    void Start () {
        worldRotation = phone.transform.localRotation;
        phoneRotation = phone.transform.localRotation;

        worldPosition = phone.transform.localPosition;
        //Vector3.MoveTowards
        phonePosition = new Vector3(0, 0.298f, 0.2f);

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    void PhoneState()
    {
        phone.transform.localRotation = phoneRotation;
        phone.transform.localPosition = phonePosition;
    }

    void WorldState()
    {

        phone.transform.localRotation = worldRotation;
        phone.transform.localPosition = worldPosition;
    }
}
