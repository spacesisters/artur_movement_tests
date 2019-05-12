using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovePosition : BasicMovement
{
    public float jumpHeight;
    public float timeToJumpApex;

    private Vector3 moveDirection = Vector3.zero;
    private Rigidbody rBody;


    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
    }

    void Update()
    {
        bottomCenter = new Vector3(transform.position.x, transform.position.y - transform.localScale.y / 2, transform.position.z);
        size = new Vector3(transform.localScale.x + 1.5f, 0.75f, transform.localScale.z);
        SetGrounded();
        

        if (isGrounded)
            moveDirection.y = 0;
        else
            moveDirection.y += gravity * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            moveDirection.y = jumpVelocity;
        }

        moveDirection.x = Input.GetAxisRaw("Horizontal") * movementVelocity;
        Move(moveDirection * Time.deltaTime);
    }

    private void Move(Vector3 movement)
    {
        rBody.MovePosition(transform.position + movement);
    } 
}
