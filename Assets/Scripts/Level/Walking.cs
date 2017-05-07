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
    public bool Slowed;
    private bool InPhone;
    private float fulcounter;
    private int fuldirection;
    
    // Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();
        InPhone = false;
        fulcounter = 0;
        fuldirection = 1;
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


            if (InPhone && (Input.GetKey("down") || Input.GetKey("up")))
            {
                Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 50)*fuldirection, 0) * Time.deltaTime);
                rb.MoveRotation(rb.rotation * deltaRotation);
            }

        }

        //Fulhack
        fulcounter += Time.fixedDeltaTime;
        if(fulcounter > 0.4f)
        {
            Debug.Log(fuldirection);
            fuldirection = Random.Range(-1, 2);
            fulcounter = 0;
        }


        if (Slowed)
        {
            velocity *= 0.5f;
        }
        var direction = tf.forward * velocity;
        rb.velocity = direction;
    }

    // Update is called once per frame
    void Update () {
		
	} 

    void StatePhone ()
    {
        InPhone = true;
    }

    void StateWorld ()
    {
        InPhone = false;
    }
}
