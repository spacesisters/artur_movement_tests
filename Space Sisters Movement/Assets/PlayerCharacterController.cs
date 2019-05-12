using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : BasicMovement
{

    private CharacterController controller;
    private Vector3 moveDirection;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        SetGrounded();
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal") * movementVelocity, moveDirection.y, 0f);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            moveDirection.y = jumpVelocity;
        }
        if (!isGrounded)
        {
            moveDirection.y += gravity * Time.deltaTime;
        }

        controller.Move(moveDirection * Time.deltaTime);
    }
}
