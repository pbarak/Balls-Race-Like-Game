using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.name.Contains("Player") && (!other.gameObject.name.Equals("Player")) )
        {
            

            //other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(1, 0f, 0f) * 20f, ForceMode.VelocityChange);
            //Vector3 newPosition = new Vector3(other.gameObject.transform.position.x, 0.5f, other.gameObject.transform.position.z + 20f);
            other.gameObject.transform.position = Vector3.Lerp(other.gameObject.transform.position, new Vector3(other.gameObject.transform.position.x, 0.5f, other.gameObject.transform.position.z + 20f), Time.time * 2f);
            //Vector3.Slerp(other.gameObject.transform.position, newPosition, 2f * Time.deltaTime);
        }
        if (other.gameObject.name.Equals("Player"))
        {
           
            //other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(1, 0f, 0f) * 20f, ForceMode.VelocityChange);
            other.gameObject.GetComponent<Rigidbody>().AddForce(other.gameObject.GetComponent<Rigidbody>().velocity.normalized * 75f, ForceMode.Impulse);
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.ClampMagnitude(other.gameObject.GetComponent<Rigidbody>().velocity, 75f);
        }
    }
}
