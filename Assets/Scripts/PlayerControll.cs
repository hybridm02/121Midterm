using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    // public Rigidbody thisRigidbody;
    public CharacterController thisCharacterController;
    public float forwardBackward;
    public float rightLeft;
    public float mouseX, mouseY;
    public float moveSpeed = 2f;
    public Vector3 inputVector;

    void Start()
    {
        thisCharacterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        //  GET MOUSELOOK
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(0, mouseX, 0);
        Camera.main.transform.Rotate(-mouseY, 0, 0);
        forwardBackward = Input.GetAxis("Vertical");
        rightLeft = Input.GetAxis("Horizontal");

        inputVector = transform.forward * forwardBackward;
        inputVector += transform.right * rightLeft;
        thisCharacterController.Move(inputVector * moveSpeed + (Physics.gravity * .69f));
    }
    // PHYSICS-BASED CONTROLLER IS NO LONGER NEEEDED!
    // void FixedUpdate()
    // {
    //     thisRigidbody.velocity = (inputVector * moveSpeed * Time.fixedDeltaTime * 50) + (Physics.gravity * .69f);
    // }
}