using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostMovement : MonoBehaviour {

    public float speed = 6;
    public float jumpSpeed = 8;
    public float gravity = 20;

    CharacterController controller;

    private void Awake()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (!controller)
            gameObject.AddComponent<CharacterController>();
    }

    private void Update()
    {
        bool isGrounded = false;
        //check to see if the controller collides with the ground and make isGrounded true
        if(controller.collisionFlags == CollisionFlags.Below)
        {
            isGrounded = true;
        }

        if (isGrounded)
        {
            //can only move control directions while on ground
            Vector3 moveDirection = new Vector3(Input.GetAxis("Hrizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }

            moveDirection.y -= gravity * Time.deltaTime;
        }
    }
}
