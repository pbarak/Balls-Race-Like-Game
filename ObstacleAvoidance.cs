using UnityEngine;
using System.Collections;
public class ObstacleAvoidance : MonoBehaviour
{
    public float speed = 35.0f;
    public float mass = 1.0f;
    public float force = 10.0f;
    public float minimumDistToAvoid = 40.0f;
    //Actual speed of the vehicle
    private float curSpeed;
    private Vector3 targetPoint;
    public GameObject playerObject;
    public Rigidbody rb;
    public bool obstacleFound = false;
    public bool obstacleFound45 = false;
    public bool obstacleFound_minus_45 = false;
    //Vector3 m_EulerAngleVelocity;

    // Use this for initialization
    void Start()
    {
        //m_EulerAngleVelocity = new Vector3(45, 0, 0);

        playerObject = this.gameObject;

        DestroyImmediate(playerObject.GetComponent<Rigidbody>());
        rb = playerObject.AddComponent<Rigidbody>();
        rb.mass = 1.0f;
        mass = 1.0f;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        targetPoint = Vector3.zero;
    }
    //void OnGUI()
    //{
    //    GUILayout.Label("Click anywhere to move the vehicle.");
    //}

    //Update is called once per frame
    void FixedUpdate()
    {
        //Vehicle move by mouse click
        RaycastHit hit;
        var ray = new Ray(playerObject.transform.position, new Vector3(0f, 0f, 1000f) - playerObject.transform.position);//Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawRay(playerObject.transform.position,  playerObject.transform.right);

        Debug.DrawRay(playerObject.transform.position, Quaternion.Euler(0f, 0f, 120f) * ( new Vector3(0f, 0f, 1000f) - playerObject.transform.position));
        //if (Input.GetMouseButtonDown(0) &&
        ////if (Physics.Raycast(ray, out hit, 250.0f, 1 << 9))
        ////{
        ////    targetPoint = hit.point;
        ////    Debug.Log("targetPoint" + targetPoint.ToString());
        ////}
        //Directional vector to the target position
        Vector3 dir = (targetPoint - playerObject.transform.position);
        dir.Normalize();
        //Apply obstacle avoidance
        AvoidObstacles( ref dir);
        //if (Vector3.Distance(targetPoint, playerObject.transform.position) < 40.0f) return;
        //Assign the speed with delta time
        curSpeed = speed * Time.deltaTime;
        //Rotate the vehicle to its target
        //directional vector

        //var rot = Quaternion.LookRotation(dir);
        //playerObject.transform.rotation = rot;// Quaternion.Slerp(playerObject.transform.rotation, rot, 100f * Time.deltaTime);

        //playerObject.transform.rotation = Quaternion.Euler(new Vector3(playerObject.transform.rotation.eulerAngles.x, 0.0f, playerObject.transform.rotation.eulerAngles.z));
        //Move the vehicle towards
        ////if (!obstacleFound)
        ////{

        ////Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime*100);
        ////playerObject.transform.rotation = deltaRotation;

        //rb.MoveRotation(rb.rotation * deltaRotation);
        if (!obstacleFound && !obstacleFound45 && !obstacleFound_minus_45)
        {
            playerObject.transform.position += playerObject.transform.forward * curSpeed; //+ playerObject.transform.forward* curSpeed;

            playerObject.transform.position = new Vector3(playerObject.transform.position.x, 0.5f, playerObject.transform.position.z);
        }
        
        ////}
    }

    //Calculate the new directional vector to avoid
    //the obstacle
    public void AvoidObstacles(ref Vector3 dir)
    {
        RaycastHit hit;
        //Only detect layer 9 (Obstacles)
        int layerMask = 1 << 9;
        //Check that the vehicle hit with the obstacles within
        //it's minimum distance to avoid
        /////if(playerObject.transform.position.z > )
        if (Physics.Raycast(playerObject.transform.position, playerObject.transform.forward , out hit, 50f, layerMask))
        {
           
            obstacleFound = true;
            obstacleFound45 = false;
            obstacleFound_minus_45 = false;
            Debug.Log("forward It is avoided");
            //Get the normal of the hit point to calculate the
            //new direction
            Vector3 hitNormal = hit.normal;
            hitNormal.y = 0.0f; //Don't want to move in Y-Space
                                //Get the new directional vector by adding force to
                                //vehicle's current forward vector
                                //dir = playerObject.transform.forward + Quaternion.Euler(0, -90, 0)*hitNormal * (-1000) ;
            dir = playerObject.transform.forward +  hitNormal * (50);
           // Debug.Log("The dir is" + dir.ToString());
            //Debug.Log("The position is" + playerObject.transform.position.ToString());
            //rb.AddForce( new Vector3(0f, 0f, 0.1f), ForceMode.VelocityChange);//playerObject.velocity.normalized * 10f + new Vector3(1f, 0f, 0f), ForceMode.Impulse);
        }
        else
        {
            obstacleFound = false;
        }

        float angle = Mathf.Atan2((playerObject.transform.forward + playerObject.transform.right).x, (playerObject.transform.forward + playerObject.transform.right).z) * Mathf.Rad2Deg;
        //(Quaternion.Euler(70f, 0f, 70f) * 
        float angle1 = Mathf.Atan2( (-1)*(playerObject.transform.forward - playerObject.transform.right).x, (-1)*(playerObject.transform.forward - playerObject.transform.right).z) * Mathf.Rad2Deg;
        // Quaternion.Euler(114.5f, 0f, 114.5f) *
        //Debug.Log("The Angle is" + Mathf.Atan2((Quaternion.Euler(95f, 0f, 95f) * (playerObject.transform.forward + playerObject.transform.right)).x, (Quaternion.Euler(95f, 0f, 95f) * (playerObject.transform.forward + playerObject.transform.right)).z) * Mathf.Rad2Deg);

        if (Physics.Raycast(playerObject.transform.position,  (playerObject.transform.forward - playerObject.transform.right), out hit, 1.9f, layerMask))
        {
            obstacleFound_minus_45 = true;
            obstacleFound45 = false;
            obstacleFound = false;
            Debug.Log("Minus 45 It is avoided");
            //Get the normal of the hit point to calculate the
            //new direction
            Vector3 hitNormal = hit.normal;
            hitNormal.y = 0.0f; //Don't want to move in Y-Space
                                //Get the new directional vector by adding force to
                                //vehicle's current forward vector
                                //dir = playerObject.transform.forward + Quaternion.Euler(0, -90, 0)*hitNormal * (-1000) ;
            dir = playerObject.transform.forward + hitNormal * (50);
            //Debug.Log("The dir is" + dir.ToString());
            //Debug.Log("The position is" + playerObject.transform.position.ToString());
            //rb.AddForce( new Vector3(0f, 0f, 0.1f), ForceMode.VelocityChange);//playerObject.velocity.normalized * 10f + new Vector3(1f, 0f, 0f), ForceMode.Impulse);
        }
        else
        {
            obstacleFound_minus_45 = false;
        }


            if (Physics.Raycast(playerObject.transform.position, (playerObject.transform.forward + playerObject.transform.right), out hit, 1.9f, layerMask))
            {
                obstacleFound45 = true;
                obstacleFound_minus_45 = false;
                obstacleFound = false;
                //Debug.Log("45 degrees It is avoided");
                //Get the normal of the hit point to calculate the
                //new direction
                Vector3 hitNormal = hit.normal;
                hitNormal.y = 0.0f; //Don't want to move in Y-Space
                                    //Get the new directional vector by adding force to
                                    //vehicle's current forward vector
                                    //dir = playerObject.transform.forward + Quaternion.Euler(0, -90, 0)*hitNormal * (-1000) ;
                dir = playerObject.transform.forward + hitNormal * (50);
                //Debug.Log("The dir is" + dir.ToString());
                //Debug.Log("The position is" + playerObject.transform.position.ToString());
                //rb.AddForce( new Vector3(0f, 0f, 0.1f), ForceMode.VelocityChange);//playerObject.velocity.normalized * 10f + new Vector3(1f, 0f, 0f), ForceMode.Impulse);
            }
            else
            {
                obstacleFound45 = false;
            }

        


        if (obstacleFound)
        {
            if(playerObject.transform.position.x <= 0 )
            {
                //Vector3 newPosition = playerObject.transform.position + playerObject.transform.forward * 100 * curSpeed + playerObject.transform.right * 100 * curSpeed;
                Vector3 newPosition = new Vector3(15f, 0f, playerObject.transform.position.z );
                playerObject.transform.position = Vector3.Slerp(playerObject.transform.position, newPosition, 4f * Time.deltaTime);

                //playerObject.transform.position += playerObject.transform.right * 10*curSpeed + playerObject.transform.forward * 10 *curSpeed;
                playerObject.transform.position = new Vector3(playerObject.transform.position.x, 0.5f, playerObject.transform.position.z);

                ////Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
                ////rb.MoveRotation(rb.rotation * deltaRotation);
                //playerObject.transform.position = new Vector3(playerObject.transform.position.x, 0.5f, playerObject.transform.position.z);
            }
            else
            {
                //Vector3 newPosition = playerObject.transform.position + playerObject.transform.forward * 100 * curSpeed + playerObject.transform.right * 100 * curSpeed;
                Vector3 newPosition = new Vector3(-15f, 0f, playerObject.transform.position.z );
                playerObject.transform.position = Vector3.Slerp(playerObject.transform.position, newPosition, 4f * Time.deltaTime);

                //playerObject.transform.position += playerObject.transform.right * 10*curSpeed + playerObject.transform.forward * 10 *curSpeed;
                playerObject.transform.position = new Vector3(playerObject.transform.position.x, 0.5f, playerObject.transform.position.z);

                ////Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
                ////rb.MoveRotation(rb.rotation * deltaRotation);
                //playerObject.transform.position = new Vector3(playerObject.transform.position.x, 0.5f, playerObject.transform.position.z);
            }

        }

        if(obstacleFound45)
        {
           if(playerObject.transform.position.x > 0)
            {
               // Debug.Log("45              111                         degrees");
                Vector3 newPosition = new Vector3(-22f, 0f, playerObject.transform.position.z - 60f);
                playerObject.transform.position = Vector3.Slerp(playerObject.transform.position, newPosition, 4f * Time.deltaTime);

                //playerObject.transform.position += playerObject.transform.right * 10*curSpeed + playerObject.transform.forward * 10 *curSpeed;
                playerObject.transform.position = new Vector3(playerObject.transform.position.x, 0.5f, playerObject.transform.position.z);
            }
           else
            {
               // Debug.Log("45              111                         degrees");
                Vector3 newPosition = new Vector3(22f, 0f, playerObject.transform.position.z -60f);
                playerObject.transform.position = Vector3.Slerp(playerObject.transform.position, newPosition, 4f * Time.deltaTime);

                //playerObject.transform.position += playerObject.transform.right * 10*curSpeed + playerObject.transform.forward * 10 *curSpeed;
                playerObject.transform.position = new Vector3(playerObject.transform.position.x, 0.5f, playerObject.transform.position.z);
            }
            
            


        }

        if (obstacleFound_minus_45)
        {
            if (playerObject.transform.position.x >= 0)
            {
                //Debug.Log("minus 45                                       degrees");
                Vector3 newPosition = new Vector3(-22f, 0f, playerObject.transform.position.z -60f);
                playerObject.transform.position = Vector3.Slerp(playerObject.transform.position, newPosition, 4f * Time.deltaTime);

                //playerObject.transform.position += playerObject.transform.right * 10*curSpeed + playerObject.transform.forward * 10 *curSpeed;
                playerObject.transform.position = new Vector3(playerObject.transform.position.x, 0.5f, playerObject.transform.position.z);
            }
            else
            {
                Vector3 newPosition = new Vector3(22f, 0f, playerObject.transform.position.z -60f);
                playerObject.transform.position = Vector3.Slerp(playerObject.transform.position, newPosition, 4f * Time.deltaTime);

                //playerObject.transform.position += playerObject.transform.right * 10*curSpeed + playerObject.transform.forward * 10 *curSpeed;
                playerObject.transform.position = new Vector3(playerObject.transform.position.x, 0.5f, playerObject.transform.position.z);
            }
        }
        // else
        // {
        //     var rot = Quaternion.LookRotation(dir);
        //      playerObject.transform.rotation = rot;
        //  }
        // playerObject.transform.right = Vector3.Slerp(playerObject.transform.right, dir, Time.deltaTime * 100f);

       


    }
}