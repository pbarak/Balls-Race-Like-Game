using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NewPlane : MonoBehaviour {

    public GameObject rotPlane;
    public GameObject newPlane;
    public GameObject rotatedPlane;
    public GameObject curPlane = null;
    public GameObject playerObject;
    public GameObject Obstacles;


    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
    private BoxCollider boxCollider;
    private SphereCollider sphereCollider;
    private Renderer n_Renderer;
    private Renderer o_Renderer;
    private Renderer r_Renderer;
    public GameObject ground;
    public GameObject speedboosters;
    public bool newGroundCreated = false;
    public bool setOnce = false;

    public  int numOfPlanes = 3;
    // Use this for initialization
    void Start () {
        GameObject canvas = GameObject.Find("EndCanvas");
        canvas.SetActive(false);
        speedboosters = GameObject.Find("SpeedBooster");
        playerObject = GameObject.Find("Player");
        Obstacles = GameObject.Find("Obstacles");
        GameObject.Find("Ground").AddComponent<BoxCollider>();
        GameObject.Find("Ground1").AddComponent<BoxCollider>();

        ground = GameObject.Find("Ground2");
        ground.AddComponent<BoxCollider>();
    }

    // Update is called once per frame
    void FixedUpdate() {

        Debug.Log("numOfPlanes" + numOfPlanes);

        if ( playerObject.transform.position.z > ( numOfPlanes*50f)  && numOfPlanes < 23)
        {
            if(numOfPlanes == 3)
            {
                if (curPlane == null)
                {
                    curPlane = ground;
                }
             
                //curPlane = GameObject.Find("Ground");

                //var myAngleInDegrees = 10;
                //var sinOfAngle = Mathf.Sin((myAngleInDegrees * Mathf.PI) / 180);
                //var cosOfAngle = Mathf.Cos((myAngleInDegrees * Mathf.PI) / 180);
                //newPlane.AddComponent<NewPlane>();

                Rect result = new Rect();
                result.width = Screen.height * 10 * curPlane.transform.localScale.x;
                result.height = Screen.height * 10 * curPlane.transform.localScale.z;
                result.x = 0.5f * Screen.width + curPlane.transform.localPosition.z * Screen.height - result.width * 0.5f;
                result.y = Screen.height - Screen.height * (0.5f + curPlane.transform.localPosition.x) - result.height * 0.5f; //a slight difference...
                //Debug.Log("Dimensions                               are   " + result.x.ToString() + "  "  + result.y.ToString());

             

                newPlane = GameObject.CreatePrimitive(PrimitiveType.Plane);
                o_Renderer = curPlane.GetComponent<Renderer>();


                n_Renderer = newPlane.GetComponent<Renderer>();
                ////Debug.Log("renderer" + n_Renderer.material.ToString());
                //n_Renderer.material.EnableKeyword("_NORMALMAP");

                //var texture = Resources.Load("CheckerBlue_diffuse");
                
                n_Renderer.material = Resources.Load("Unlit_CubeMap") as Material;
                ////Debug.Log("renderer" + n_Renderer.material.name.ToString());

                Texture2D texture = Resources.Load("CheckerBlue_diffuse") as Texture2D;
                ////Debug.Log("texture" + texture.ToString());

                n_Renderer.material.mainTexture = texture;


                newPlane.name = "Ground" + numOfPlanes.ToString();
                newPlane.transform.parent = ground.transform;
                newPlane.transform.localScale = new Vector3(1f, 1f, 1f);
                //Debug.Log("curPlane.transform.position.y = " + curPlane.transform.position.y);
                //Debug.Log("curPlane.transform.localScale.x" + curPlane.transform.localScale.x);

                //newPlane.transform.Rotate(new Vector3(0f, 0f, 10f));


                //newPlane.transform.position = new Vector3(curPlane.transform.position.x + cosOfAngle * curPlane.transform.localScale.x * 10, curPlane.transform.position.y + sinOfAngle*curPlane.transform.localScale.x*5 , curPlane.transform.position.z );
                Bounds bounds1 = curPlane.GetComponent<Renderer>().bounds;
                //Debug.Log("The             bounds1                min      is " + bounds1.min.z);
                //Debug.Log("The             bounds1                max      is " + transform.InverseTransformPoint(transform.TransformPoint(bounds1.size)).z);

                newPlane.transform.position = transform.InverseTransformPoint((transform.TransformPoint(curPlane.GetComponent<Renderer>().bounds.center.x, curPlane.GetComponent<Renderer>().bounds.center.y, bounds1.max.z + 0.0001f + newPlane.GetComponent<Renderer>().bounds.size.z / 2)));

                //newPlane.transform.position = new Vector3(0f, transform.InverseTransformPoint(transform.TransformPoint(bounds1.max)).y, transform.InverseTransformPoint(transform.TransformPoint(bounds1.max)).z + 0.000006f + (transform.InverseTransformPoint(transform.TransformPoint(newPlane.GetComponent<Renderer>().bounds.size)).z/2));
                //Debug.Log("The      isa      zzz            Transform is" + newPlane.transform.position.z);
                //newPlane.transform.rotation = new Quaternion(0f, 0f, 10f, 0f);
                DestroyImmediate(newPlane.GetComponent<BoxCollider>());
                
                
               
                newPlane.AddComponent<BoxCollider>();
                newPlane.GetComponent<BoxCollider>().center = newPlane.transform.position;
                newPlane.GetComponent<BoxCollider>().size = newPlane.GetComponent<Renderer>().bounds.size;
                //Debug.Log("newPlane collider size" + newPlane.GetComponent<BoxCollider>().size.ToString());
                //newPlane.GetComponent<BoxCollider>().center = new Vector3(0f, 0f, 0f);

                //newPlane.GetComponent<MeshCollider>().size = new Vector3(11f, 0f, 9.09f);

                ////Debug.Log("newPlane collider center" + newPlane.GetComponent<BoxCollider>().center);

                ////Debug.Log("newPlane collider bounds" + newPlane.GetComponent<BoxCollider>().bounds);

                ////Debug.Log("newPlane collider size" + newPlane.GetComponent<BoxCollider>().size.ToString());
                //setOnce = true;
                //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                //cube.transform.position = new Vector3(0f, 0.5f, 60f);
                //cube.transform.localScale = new Vector3(2f, 2f, 2f);
                //cube.name = "Cube" + numOfPlanes.ToString();
                //cube.transform.parent = Obstacles.transform;
                //cube.layer = Obstacles.layer;


                GameObject cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                DestroyImmediate(cube1.GetComponent<BoxCollider>());
                cube1.AddComponent<BoxCollider>();
                cube1.transform.localScale = new Vector3(10f, 20f, 150f);
                cube1.transform.position = new Vector3(10f, 10f, 450f);
                cube1.name = "Cube" + numOfPlanes.ToString() + "_1";
                //cube1.transform.parent = Obstacles.transform;
                //cube1.layer = Obstacles.layer;

                Renderer t_Renderer = cube1.GetComponent<Renderer>();
                t_Renderer.material = Resources.Load("CheckerBrown") as Material;
                Texture2D texture3 = Resources.Load("CheckerBrow_diffuse") as Texture2D;
                t_Renderer.material.mainTexture = texture3;


                GameObject cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                DestroyImmediate(cube2.GetComponent<BoxCollider>());
                cube2.AddComponent<BoxCollider>();
                cube2.transform.localScale = new Vector3(10f, 20f, 150f);
                cube2.transform.position = new Vector3(-10f, 10f, 450f);
                cube2.name = "Cube" + numOfPlanes.ToString() + "_1";
                //cube6.transform.parent = Obstacles.transform;
                //cube6.layer = Obstacles.layer;
                Renderer t_Renderer1 = cube2.GetComponent<Renderer>();
                t_Renderer1.material = Resources.Load("CheckerBrown") as Material;
                Texture2D texture4 = Resources.Load("CheckerBrow_diffuse") as Texture2D;
                t_Renderer1.material.mainTexture = texture4;





                    //   rotatedPlane = GameObject.Find("Quad");//.CreatePrimitive(PrimitiveType.Quad);

                    //   rotatedPlane.transform.position = new Vector3(0f, 0.01f, numOfPlanes * 150 + 170f);
                    //   ////rotatedPlane.tag = "speedbooster";
                    //   Destroy(rotatedPlane.GetComponent<MeshCollider>());
                    //   rotatedPlane.AddComponent<MeshCollider>();
                    //   ////rotatedPlane.AddComponent<SpeedBooster>();

                    //    rotatedPlane.GetComponent<MeshCollider>().material = Resources.Load("NewPhysicMaterial") as PhysicMaterial;
                    //rotatedPlane.GetComponent<BoxCollider>().center = new Vector3(0f, 0f, 0f);
                    //// rotatedPlane.GetComponent<BoxCollider>().isTrigger = true;
                    //    r_Renderer = rotatedPlane.GetComponent<Renderer>();

                    //Texture2D texture1 = LoadPNG();
                    //r_Renderer.material.mainTexture = texture1;
                    //    Texture2D texture1 = Resources.Load("speedbooster") as Texture2D;
                    //    r_Renderer.material.mainTexture = texture1;
                    //    rotatedPlane.transform.localScale = new Vector3(2f, 6f, 4f);
                    ////rotatedPlane.transform.Rotate(new Vector3(90f, 0f, 90f));
                    //    rotatedPlane.transform.Rotate(new Vector3(-90f, 0f, 90f));

                    ////rotatedPlane.GetComponent<MeshCollider>().center = new Vector3(0f, 0f, 0f);



                

            }
            else
            {

                //////rotPlane = GameObject.CreatePrimitive(PrimitiveType.Cube);
                //////rotPlane.transform.localScale = new Vector3(2f, 2f, 2f);
                //////rotPlane.transform.position = new Vector3(numOfPlanes*150f + 75f + 75f, 0f, -3f);
                //////rotPlane.transform.Rotate(new Vector3(0f, 0f, 45f));
                //////rotPlane.name = "Cube_000" + numOfPlanes.ToString();
                //////Destroy(rotPlane.GetComponent<BoxCollider>());
                //////rotPlane.AddComponent<BoxCollider>();
                //////rotPlane.GetComponent<BoxCollider>().material = Resources.Load("NewPhysicMaterial") as PhysicMaterial;

                curPlane = GameObject.Find("Ground" + (numOfPlanes-1).ToString());

               
                                newPlane = GameObject.CreatePrimitive(PrimitiveType.Plane);
                o_Renderer = curPlane.GetComponent<Renderer>();


                n_Renderer = newPlane.GetComponent<Renderer>();
                ////Debug.Log("renderer" + n_Renderer.material.ToString());
                //n_Renderer.material.EnableKeyword("_NORMALMAP");

                //var texture = Resources.Load("CheckerBlue_diffuse");
                
                n_Renderer.material = Resources.Load("Unlit_CubeMap") as Material;
                ////Debug.Log("renderer" + n_Renderer.material.name.ToString());

                Texture2D texture = Resources.Load("CheckerBlue_diffuse") as Texture2D;
                ////Debug.Log("texture" + texture.ToString());

                n_Renderer.material.mainTexture = texture;


                newPlane.name = "Ground" + numOfPlanes.ToString();
                newPlane.transform.parent = ground.transform;
                newPlane.transform.localScale = new Vector3(1f, 1f, 1f);
                //Debug.Log("curPlane.transform.position.y = " + curPlane.transform.position.y);
                //Debug.Log("curPlane.transform.localScale.x" + curPlane.transform.localScale.x);

                //newPlane.transform.Rotate(new Vector3(0f, 0f, 10f));


                //newPlane.transform.position = new Vector3(curPlane.transform.position.x + cosOfAngle * curPlane.transform.localScale.x * 10, curPlane.transform.position.y + sinOfAngle*curPlane.transform.localScale.x*5 , curPlane.transform.position.z );
                Bounds bounds1 = curPlane.GetComponent<Renderer>().bounds;
                //Debug.Log("The             bounds1                min      is " + bounds1.min.z);
                //Debug.Log("The             bounds1       aaaaaaaaaaaaaaaaa         max      is " + newPlane.GetComponent<Renderer>().bounds.size.ToString());

                newPlane.transform.position = transform.InverseTransformPoint( (transform.TransformPoint(curPlane.GetComponent<Renderer>().bounds.center.x, curPlane.GetComponent<Renderer>().bounds.center.y, bounds1.max.z + 0.0001f + newPlane.GetComponent<Renderer>().bounds.size.z/2)));
                //Debug.Log("The      isa      zzz            Transform is" + newPlane.transform.position.z);
                //newPlane.transform.rotation = new Quaternion(0f, 0f, 10f, 0f);
                DestroyImmediate(newPlane.GetComponent<BoxCollider>());
                
                
               
                newPlane.AddComponent<BoxCollider>();
                newPlane.GetComponent<BoxCollider>().center = newPlane.transform.position;
                newPlane.GetComponent<BoxCollider>().size = new Vector3(10.5f, 0.5f, 152f);//transform.InverseTransformPoint(transform.TransformPoint(newPlane.GetComponent<Renderer>().bounds.size));


                if (numOfPlanes < 20)
                {
                    if (Random.Range(1, 3) - 1 == 0)
                    {
                        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                       
                        DestroyImmediate(cube.GetComponent<BoxCollider>());
                        cube.AddComponent<BoxCollider>();
                        cube.GetComponent<BoxCollider>().isTrigger = true;
                        cube.transform.position = new Vector3(Random.Range(-2f, 2f), 0.5f, Random.Range(10f, 20f) + numOfPlanes * 150f);
                        cube.transform.localScale = new Vector3(2f, 2f, 2f);
                        cube.name = "Cube" + numOfPlanes.ToString();
                        cube.transform.parent = Obstacles.transform;
                        cube.layer = Obstacles.layer;
                        Renderer t_Renderer2 = cube.GetComponent<Renderer>();
                        t_Renderer2.material = Resources.Load("CheckerBrown") as Material;
                        Texture2D texture5 = Resources.Load("CheckerBrow_diffuse") as Texture2D;
                        t_Renderer2.material.mainTexture = texture5;
                        cube.AddComponent<CubeCollisions>();
                        cube.AddComponent<BoxCollider>();
                        cube.transform.parent = GameObject.Find("Cube1").transform;

                    }
                    else
                    {
                        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        foreach (MeshCollider c in cube.GetComponents<MeshCollider>())
                        {
                            DestroyImmediate(c);
                        }
                        DestroyImmediate(cube.GetComponent<BoxCollider>());
                        cube.AddComponent<BoxCollider>();

                        cube.GetComponent<BoxCollider>().isTrigger = true;

                        if (Random.Range(1, 3) - 1 == 0)
                        {
                            cube.transform.position = new Vector3(-4f, 0.5f, Random.Range(10f, 20f) + numOfPlanes * 150f);
                        }
                        else
                        {
                            cube.transform.position = new Vector3(4f, 0.5f, Random.Range(10f, 20f) + numOfPlanes * 150f);

                        }

                        cube.transform.localScale = new Vector3(2f, 2f, 2f);
                        cube.name = "Cube" + numOfPlanes.ToString();
                       cube.transform.parent = Obstacles.transform;
                        cube.layer = Obstacles.layer;

                        Renderer t_Renderer2 = cube.GetComponent<Renderer>();
                        t_Renderer2.material = Resources.Load("CheckerBrown") as Material;
                        Texture2D texture5 = Resources.Load("CheckerBrow_diffuse") as Texture2D;
                        t_Renderer2.material.mainTexture = texture5;

                        cube.AddComponent<CubeCollisions>();
                        cube.AddComponent<BoxCollider>();
                        cube.transform.parent = GameObject.Find("Cube1").transform;

                    }


                    rotatedPlane = GameObject.CreatePrimitive(PrimitiveType.Plane);

                    rotatedPlane.transform.position = new Vector3(Random.Range(-2.5f, 2.5f), 0.001f, numOfPlanes * 150 + Random.Range(-40f, -20f));
                    ////rotatedPlane.tag = "speedbooster";

                    ////Destroy(rotatedPlane.GetComponent<MeshCollider>());
                    //DestroyImmediate(rotatedPlane.GetComponent<BoxCollider>());
                    /////Destroy(rotatedPlane.GetComponent<BoxCollider>());
                    ////Destroy(rotatedPlane.GetComponent<BoxCollider2D>());

                    foreach (MeshCollider c in rotatedPlane.GetComponents<MeshCollider>())
                    {
                        DestroyImmediate(c);
                    }

                    rotatedPlane.AddComponent<BoxCollider>();
                    rotatedPlane.transform.parent = speedboosters.transform;
                    rotatedPlane.layer = speedboosters.layer;

                    ////rotatedPlane.GetComponent<BoxCollider2D>().material = Resources.Load("NewPhysicMaterial") as PhysicMaterial;
                    //rotatedPlane.GetComponent<BoxCollider>().center = new Vector3(0f, 0f, 0f);
                    rotatedPlane.GetComponent<BoxCollider>().isTrigger = true;
                    rotatedPlane.AddComponent<SpeedBooster>();
                    Renderer k_Renderer = rotatedPlane.GetComponent<Renderer>();

                    //Texture2D texture1 = LoadPNG();
                    //r_Renderer.material.mainTexture = texture1;
                    Texture2D texture2 = Resources.Load("speedbooster") as Texture2D;
                    k_Renderer.material.mainTexture = texture2;
                    rotatedPlane.transform.localScale = new Vector3(0.25f, 1f, 1f);
                    ////rotatedPlane.transform.Rotate(new Vector3(90f, 0f, 90f));
                    rotatedPlane.transform.Rotate(new Vector3(180f, 0f, 180f));
                    rotatedPlane.transform.parent = GameObject.Find("Ground").transform;


                }







                GameObject cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                DestroyImmediate(cube1.GetComponent<BoxCollider>());
                cube1.AddComponent<BoxCollider>();
                cube1.transform.localScale = new Vector3(10f, 20f, 150f);
                cube1.transform.position = new Vector3(10f, 10f, (numOfPlanes) * 150f );
                cube1.name = "Cube" + numOfPlanes.ToString() + "_1";
                //cube1.transform.parent = Obstacles.transform;
                //cube1.layer = Obstacles.layer;

                Renderer t_Renderer = cube1.GetComponent<Renderer>();
                t_Renderer.material = Resources.Load("CheckerBrown") as Material;
                Texture2D texture3 = Resources.Load("CheckerBrow_diffuse") as Texture2D;
                t_Renderer.material.mainTexture = texture3;

                cube1.transform.parent = GameObject.Find("Cube1").transform;




                GameObject cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                DestroyImmediate(cube2.GetComponent<BoxCollider>());
                cube2.AddComponent<BoxCollider>();
                cube2.transform.localScale = new Vector3(10f, 20f, 150f );
                cube2.transform.position = new Vector3(-10f, 10f, (numOfPlanes) * 150f );
                cube2.name = "Cube" + numOfPlanes.ToString() + "_1";
                //cube6.transform.parent = Obstacles.transform;
                //cube6.layer = Obstacles.layer;
                Renderer t_Renderer1 = cube2.GetComponent<Renderer>();
                t_Renderer1.material = Resources.Load("CheckerBrown") as Material;
                Texture2D texture4 = Resources.Load("CheckerBrow_diffuse") as Texture2D;
                t_Renderer1.material.mainTexture = texture4;

                cube2.transform.parent = GameObject.Find("Cube1").transform;





                if (numOfPlanes == 20)
                {
                    GameObject rotatedPlane1 = GameObject.CreatePrimitive(PrimitiveType.Plane);

                    rotatedPlane1.transform.position = new Vector3(0f, 0.001f, numOfPlanes * 150 - 50f);
                    rotatedPlane1.transform.localScale = new Vector3(1f, 1f, 2f);

                    ////rotatedPlane.tag = "speedbooster";

                    ////Destroy(rotatedPlane.GetComponent<MeshCollider>());
                    //DestroyImmediate(rotatedPlane.GetComponent<BoxCollider>());
                    /////Destroy(rotatedPlane.GetComponent<BoxCollider>());
                    ////Destroy(rotatedPlane.GetComponent<BoxCollider2D>());

                    foreach (MeshCollider c in rotatedPlane1.GetComponents<MeshCollider>())
                    {
                        DestroyImmediate(c);
                    }

                    rotatedPlane1.AddComponent<BoxCollider>();
                    

                    ////rotatedPlane.GetComponent<BoxCollider2D>().material = Resources.Load("NewPhysicMaterial") as PhysicMaterial;
                    //rotatedPlane.GetComponent<BoxCollider>().center = new Vector3(0f, 0f, 0f);
                    rotatedPlane1.GetComponent<BoxCollider>().isTrigger = true;
                    rotatedPlane1.AddComponent<Stopper>();

                    rotatedPlane1.transform.parent = GameObject.Find("Ground").transform;

                    Renderer l_Renderer = rotatedPlane1.GetComponent<Renderer>();

                    //Texture2D texture1 = LoadPNG();
                    //r_Renderer.material.mainTexture = texture1;
                    l_Renderer.material = Resources.Load("CheckerClassic") as Material;

                    Texture2D texture_1 = Resources.Load("Checker_diffuse") as Texture2D;
                    l_Renderer.material.mainTexture = texture_1;
                    ////rotatedPlane.transform.Rotate(new Vector3(90f, 0f, 90f));
                    //rotatedPlane.transform.Rotate(new Vector3(180f, 0f, 180f));
                }


            }
            ////Debug.Log("curPlane.transform.localScale.x" + playerObject.transform.position.x);
            //if (playerObject.transform.position.x > 70)
            //{
            //    Debug.Log("Hello");
            //    Destroy(curPlane);
            //    curPlane = null;
            //    newPlane.name = "Ground";
            //    newGroundCreated = true;
            //    setOnce = false;
            //}

            if(numOfPlanes < 21)
            {
                numOfPlanes += 1;

            }

            if(playerObject.transform.position.x > (numOfPlanes)*150)
            {
                DestroyImmediate(GameObject.Find("Ground" + (numOfPlanes - 1).ToString()));
            }
        }
    }


    public static Texture2D LoadPNG()
    {

        Texture2D tex = null;
        byte[] fileData;

        if (File.Exists("Resources/speedbooster.png"))
        {
            fileData = File.ReadAllBytes("Resources/speedbooster.png");
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
        }
        return tex;
    }
}


