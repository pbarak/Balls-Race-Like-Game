using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SetPlayerBounds : MonoBehaviour {

    private bool isFirst = false;
    private bool isLast = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setFirst(bool first)
    {
        this.isFirst = first;
    }

    public bool getFirst()
    {
        return this.isFirst ;
    }


    public void setLast(bool last)
    {
        this.isLast = last;
    }

    public bool getLast()
    {
        return this.isLast;
    }
}
