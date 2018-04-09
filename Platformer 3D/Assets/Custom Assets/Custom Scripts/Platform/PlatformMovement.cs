using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlatformMovement : MonoBehaviour {

    public Vector3 startPos;
    public Vector3 finalPos;
    private Vector3 originalPos;
    private Vector3 currVel;
    public Vector3 currPos;

    public float distance = 10f;
    public float speed = 1f;
    public float cycles = 0f;

    public int axisIndex = 1;

  
    private void OnEnable()
    {
        //Which relative direction to move (Axis index : 1 = X axis (Right direction) ; 2 = Y Axis (Upwards) ; 3 = Z Axis (Forward))
        startPos = this.transform.position; 
        if(axisIndex  == 1)
        {
            finalPos = startPos + (Vector3.right * distance);
        }
        else if (axisIndex == 2)        
        {
            finalPos = startPos + (Vector3.up * distance);
        }
        else if (axisIndex == 3)
        {
            finalPos = startPos + (Vector3.forward * distance);
        }
        else
        {
            Debug.LogWarning("Insert a valid axisIndex in Platform Movement script attached to" + this.name);
        }
                        
    }


    void Start () {
        //To store the position where the platform was spawned 
        originalPos = this.transform.position;
	}
	
	
	void Update () {

        currPos = transform.position;

        //Back and forth motion. sets the final position to start position when it reaches the final position
        if (Math.Round(transform.position[axisIndex - 1], 1, MidpointRounding.AwayFromZero) == Math.Round(finalPos[axisIndex - 1],1, MidpointRounding.AwayFromZero))
        {
            Vector3 swapVar = startPos;
            startPos = finalPos;
            finalPos = swapVar;
            cycles += 0.5f;
        }

        //Move towards the finalPos
        transform.position = Vector3.SmoothDamp(transform.position, finalPos, ref currVel, distance/speed, speed );
	}
}
