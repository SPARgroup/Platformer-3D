﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour {

    public float amount;
    public float smoothAmount;
    public float maxAmount;
    public float maxRotSway;
    public float smoothRot;
    public float tiltAngle;


    public Vector3 initPos;

	// Use this for initialization
	void Start () {

        initPos = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {

        //positional sway
        float movementX = -Input.GetAxis("Mouse X") * amount;
        float movementY = -Input.GetAxis("Mouse Y") * amount;

        movementX = Mathf.Clamp(movementX, -maxAmount, maxAmount);
        movementY = Mathf.Clamp(movementY, -maxAmount, maxAmount);

        Vector3 finalPos = new Vector3(movementX, movementY, 0);

        transform.localPosition = Vector3.Lerp(transform.localPosition, finalPos + initPos, Time.deltaTime * smoothAmount);

        //rotational sway

        float tiltAroundZ = Input.GetAxis("Mouse X") * tiltAngle;
        float tiltAroundX = Input.GetAxis("Mouse Y") * tiltAngle;

        tiltAroundZ = Mathf.Clamp(tiltAroundZ, -maxRotSway, maxRotSway);
        tiltAroundX = Mathf.Clamp(tiltAroundX, -maxRotSway, maxRotSway);

        Quaternion finalRot = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);

        transform.localRotation = Quaternion.Lerp(transform.localRotation, finalRot, Time.deltaTime * smoothRot);

    }
}
