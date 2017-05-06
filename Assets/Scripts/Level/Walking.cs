using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour {
    private Rigidbody rb;
    private Transform tf;

    public float Speed;
    public float RotationSpeed;
    [System.NonSerialized]
    public bool Stunned;
    
    // Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();
	}

    // Static update
    private void FixedUpdate()
    {
        float velocity = 0;
        if (!Stunned)
        {
            if (Input.GetKey("up") && !Input.GetKey("down"))
            {
                velocity = Speed;
            }

            if (Input.GetKey("down") && !Input.GetKey("up"))
            {
                velocity = -Speed;
            }

            if (Input.GetKey("left"))
            {
                Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, -RotationSpeed, 0) * Time.deltaTime);
                rb.MoveRotation(rb.rotation * deltaRotation);
            }

            if (Input.GetKey("right"))
            {
                Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, RotationSpeed, 0) * Time.deltaTime);
                rb.MoveRotation(rb.rotation * deltaRotation);
            }
        }

        var direction = tf.forward * velocity;
        rb.velocity = direction;
    }

    // Update is called once per frame
    void Update () {
		
	} 
}
