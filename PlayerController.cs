using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public  int numOfRepeats = 0;
    public int frames = 0;
    public bool first = false;
    public Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GameObject.Find("Player").GetComponent<Rigidbody>();
        rb.mass = 5f;
	}
	

    private void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3( moveVertical, 0f,0f);
        rb.AddForce(movement * (speed/5 ));

        if(!first)
        {
            rb.AddForce(rb.velocity.normalized + new Vector3(0f, 0f, 1f), ForceMode.VelocityChange);
            first = true;
        }
        else
        {
            if (rb.velocity.z < 30f)
            {
                rb.AddForce(rb.velocity.normalized * 1f, ForceMode.VelocityChange);

            }

        }
    }
}
