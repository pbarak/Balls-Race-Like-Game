using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersRanks : MonoBehaviour {
    public bool isFirst = false;
   
    public Rigidbody rb;
    public SphereCollider sphCo;
    public GameObject Players;
    public GameObject[] AllPlayers;
    public GameObject speedboosters;
    public  int objectPosition = 0;
    public int myPos;
    public  int myPosition;
    public Canvas c;

    // Use this for initialization
    void Start () {
        Transform child = this.gameObject.transform.Find("Canvas");
        myPos = 0;
        myPosition = 0;

        c = child.GetComponent<Canvas>();

        AllPlayers = new GameObject[10];
        Players = GameObject.Find("Players");



        if (this.gameObject.name.Equals("Player"))
        {


            for (int i = 0; i <= 9; i++)
            {

                GameObject player = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                player.name = "Player" + i.ToString();
                player.AddComponent<Rigidbody>();
                rb = player.GetComponent<Rigidbody>();
                rb.mass = 1;
                rb.useGravity = true;
                rb.drag = 0;
                rb.angularDrag = 0.05f;
                rb.isKinematic = true;
                rb.interpolation = RigidbodyInterpolation.None;
                rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
                Destroy(player.GetComponent<SphereCollider>());
                player.AddComponent<SphereCollider>();
                sphCo = player.GetComponent<SphereCollider>();
                sphCo.center = new Vector3(0f, 0f, 0f);
                sphCo.material = Resources.Load("NewPhysicMaterial") as PhysicMaterial;
                player.AddComponent<ObstacleAvoidance>();
                player.AddComponent<SetPlayerBounds>();
                float z_position = i * 35f;
                if (i % 2 == 0)
                {
                    player.transform.position = new Vector3(Random.Range(-3.5f, 0f), 0.5f, z_position);

                }
                else
                {
                    player.transform.position = new Vector3(Random.Range(1f, 3.5f), 3.5f, z_position);

                }

                player.transform.parent = Players.transform;
                player.layer = Players.layer;
                AllPlayers[i] = player;
            }


        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
         

    float minZ = 0.0f;
        float maxZ = 0.0f;

        int firstPlayer = 0;
        int lastPlayer = 0;


        minZ = 0f;//AllPlayers[0].transform.position.z;
        maxZ = 0f;// AllPlayers[0].transform.position.z;
       
      
            for (int k = 0; k <= 9; k++)
            {
                if(AllPlayers[k] != null)
            {
                
                if (this.gameObject.name.Equals("Player"))
                {

                    if (AllPlayers[k].transform.position.z < this.gameObject.transform.position.z)
                    {
                        if (myPos > 1)
                        {
                            myPos--;

                        }
                    }
                    else
                    {
                        if (myPos < 11)
                        {
                            myPos++;
                        }

                    }
                }
            }
               
            }
        myPosition = myPos;
        //this.gameObject.GetComponent<PositionScript>().setPosition(myPosition);
        Transform child = c.transform.Find("Position");
        Text t = child.GetComponent<Text>();
        t.text = myPos.ToString();
     

        //Debug.Log("My                 Position is " + myPosition.ToString());


        
        if (AllPlayers[firstPlayer].transform.position.z < this.gameObject.transform.position.z && (AllPlayers[firstPlayer] != null) )
            {
            this.gameObject.GetComponent<SetPlayerBounds>().setFirst(true);
            this.gameObject.GetComponent<SetPlayerBounds>().setLast(false);


            }
            else if (AllPlayers[lastPlayer].transform.position.z > this.gameObject.transform.position.z && (AllPlayers[lastPlayer] != null))
            {
            this.gameObject.GetComponent<SetPlayerBounds>().setFirst(false);
            this.gameObject.GetComponent<SetPlayerBounds>().setLast(true);


            }
            else 
            {
            if(AllPlayers[lastPlayer] != null && AllPlayers[firstPlayer] != null)
            {
                this.gameObject.GetComponent<SetPlayerBounds>().setFirst(false);
                this.gameObject.GetComponent<SetPlayerBounds>().setLast(false);

                AllPlayers[firstPlayer].GetComponent<SetPlayerBounds>().setFirst(true);
                AllPlayers[firstPlayer].GetComponent<SetPlayerBounds>().setLast(false);


                AllPlayers[lastPlayer].GetComponent<SetPlayerBounds>().setFirst(false);
                AllPlayers[lastPlayer].GetComponent<SetPlayerBounds>().setLast(true);
            }


            }


   
        child = c.transform.Find("Level");
        t = child.GetComponent<Text>();
        int level = (int)(this.gameObject.transform.position.z / 150) + 1;
        
        t.text = level.ToString() + " of " + " 20 Level Parts";
        myPos = 11;

    }
}
