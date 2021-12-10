using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(Animator))]
public class PlayerController : MonoBehaviour
{

    private CharacterController characterController;
    private Animator animator;

    [SerializeField]
    private float movementSpeed, rotationSpeed, jumpSpeed, gravity;

    private Vector3 movementDirection = Vector3.zero;
    private bool playerGrounded, jumpKeyWasPressed;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerGrounded = characterController.isGrounded;

        //movement
        Vector3 inputMovement = transform.forward * movementSpeed * Input.GetAxisRaw("Vertical");
        characterController.Move(inputMovement * Time.deltaTime);

        transform.Rotate(Vector3.up * Input.GetAxisRaw("Horizontal") * rotationSpeed);


        //jumping
        if(Input.GetKeyDown(KeyCode.Space) && playerGrounded)
        {
            movementDirection.y = jumpSpeed;
            jumpKeyWasPressed = true;
        }
        movementDirection.y -= gravity * Time.deltaTime;

        characterController.Move(movementDirection * Time.deltaTime);


        //animations
        animator.SetBool("isRunning", Input.GetAxisRaw("Vertical") != 0);
        animator.SetBool("isJumping", !characterController.isGrounded);

    }

    // private void FixedUpdate() {

    //     Vector3 inputMovement = transform.forward * movementSpeed * Input.GetAxisRaw("Vertical");
    //     characterController.Move(inputMovement * Time.deltaTime);
    //     transform.Rotate(Vector3.up * Input.GetAxisRaw("Horizontal") * rotationSpeed);

    //     if (jumpKeyWasPressed){
    //         movementDirection.y = jumpSpeed;
    //     }

    //     movementDirection.y -= gravity * Time.deltaTime;

    //     characterController.Move(movementDirection * Time.deltaTime);
    // }
}