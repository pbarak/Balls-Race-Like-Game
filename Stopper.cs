using UnityEngine;
using UnityEngine.SceneManagement;

public class Stopper : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("Player") && (!other.gameObject.name.Equals("Player")))
        {
            other.gameObject.GetComponent<ObstacleAvoidance>().speed = 0;
        }
        if (other.gameObject.name.Equals("Player"))
        {
            //other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(1, 0f, 0f) * 20f, ForceMode.VelocityChange);
            //other.gameObject.GetComponent<Rigidbody>().AddForce(other.gameObject.GetComponent<Rigidbody>().velocity.normalized * -80f, ForceMode.Impulse);
            other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3( 0f, 0f, 0f);// Vector3.ClampMagnitude(other.gameObject.GetComponent<Rigidbody>().velocity, 75f);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.name.Equals("Player"))
        {
            
            //other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(1, 0f, 0f) * 20f, ForceMode.VelocityChange);
            //other.gameObject.GetComponent<Rigidbody>().AddForce(other.gameObject.GetComponent<Rigidbody>().velocity.normalized * -f, ForceMode.Impulse);
            other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);// Vector3.ClampMagnitude(other.gameObject.GetComponent<Rigidbody>().velocity, 75f);



            SceneManager.UnloadSceneAsync("MiniGame");

            SceneManager.LoadScene("EndScene");

           
        }
    }
}
