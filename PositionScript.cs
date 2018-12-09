using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionScript : MonoBehaviour {

    private int position;
    // Use this for initialization
    void Start()
    {
        GameObject obj1 = this.gameObject;
        
        Transform child = obj1.transform.Find("Panel");

       // Transform child1 = child.transform.Find("PositionText");


        
        //Text t = child1.GetComponent<Text>();
        //t.text = "You Finished " + position.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setPosition(int position)
    {
        this.position = position;
    }

    public int getFirst()
    {
        return this.position;
    }

    
}

