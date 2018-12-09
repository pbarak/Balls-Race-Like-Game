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
	
	// Update is called once per frame
	//void Update () {
		
	//}

    private void FixedUpdate()
    {
        //float moveHorizontal = Input.GetAxis("Vertical");
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
            // rb.AddForce(rb.velocity.normalized * 0.1f, ForceMode.Impulse);
            // Debug.Log("the normalized speed is:" + rb.velocity.ToString());
            ////Debug.Log("the normalized speed in x is:" + rb.velocity.x.ToString());
            if (rb.velocity.z < 30f)
            {
                rb.AddForce(rb.velocity.normalized * 1f, ForceMode.VelocityChange);
                ////Debug.Log("the normalized speed is:" + rb.velocity.ToString());

            }

        }
        


    }

  //  public void OnTriggerEnter(Collider other)
  //  {
  //      if (other.gameObject.layer.Equals("Obstacles"))
  //      {
  //          rb.AddForce(rb.velocity.normalized * 1000f, ForceMode.VelocityChange);
  //      }
  //      if (other.gameObject.layer.Equals("speedbooster"))
  //      {
  //          Debug.Log("Entered   Entered   Entered   Entered   Entered");
  //          rb.AddForce(rb.velocity.normalized * 10f, ForceMode.VelocityChange);
  //      }
  //  }

  
}
