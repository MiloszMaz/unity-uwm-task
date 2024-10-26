using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private bool isLaunchPlayer = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        if(isLaunchPlayer)
        {
            isLaunchPlayer = false;
            Debug.Log("Wysokoœæ podstawowego skoku: " + jumpSpeed + " Ma byæ wyrzucony na: " + moveDirection.y);
        }
        else
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        

        controller.Move(moveDirection * Time.deltaTime);
    }

    // do lab05_zadanie5
    public void LaunchPlayer(float forceMultiplier)
    {
        float launchForce = jumpSpeed * forceMultiplier;
        moveDirection.y += launchForce;
        isLaunchPlayer = true;
        Debug.Log("Si³a wyrzutu: " + launchForce);
    }
}
