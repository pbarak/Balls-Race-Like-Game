using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CubeCollisions : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Player") && (!other.gameObject.name.Equals("Player")))
        {

            //other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(1, 0f, 0f) * 20f, ForceMode.VelocityChange);
            // other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, new Vector3(Mathf.Lerp(other.gameObject.transform.position.z, other.gameObject.transform.position.z + other.gameObject.transform.forward.z * 50, Time.time * 10), 0, 0).z);
            //Destroy(other.gameObject);
            Renderer t_Renderer = other.gameObject.GetComponent<Renderer>();
            Texture2D texture = Resources.Load("broken") as Texture2D;
            t_Renderer.material.mainTexture = texture;
            other.gameObject.GetComponent<ObstacleAvoidance>().speed = 0;

        }
        if (other.gameObject.name.Equals("Player"))
        {
            
            other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);// Vector3.ClampMagnitude(other.gameObject.GetComponent<Rigidbody>().velocity, 75f);

            SceneManager.LoadScene("EndScene");

        }
    }
}
