using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVelocityBuiltInGravity : BasicMovement
{

    private Rigidbody rBody;
    private Vector3 velocity;

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        SetGrounded();

        velocity = rBody.velocity;
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = jumpVelocity;
        }
        
        velocity.x = Input.GetAxisRaw("Horizontal") * movementVelocity * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        rBody.velocity += velocity * Time.deltaTime;
    }
}
