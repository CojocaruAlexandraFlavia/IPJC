using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(Animator))]
public class PlayerController : MonoBehaviour
{


    private bool jumpKeyWasPressed = false;
    private Rigidbody rigidBody;
    private float horizontalInput;
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private LayerMask playerMask;

    //private CharacterController characterController;
    private Animator animator;

    //[SerializeField]
    private float movementSpeed, rotationSpeed, jumpSpeed, gravity;

    private Vector3 movementDirection = Vector3.zero;
    private bool playerGrounded;


    // Start is called before the first frame update
    void Start()
    {
        //characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //playerGrounded = characterController.isGrounded;

        //movement
        // Vector3 inputMovement = transform.forward * movementSpeed * Input.GetAxisRaw("Vertical");
        // characterController.Move(inputMovement * Time.deltaTime);

       // transform.Rotate(Vector3.up * Input.GetAxisRaw("Horizontal") * rotationSpeed);


        if(Input.GetKeyDown(KeyCode.Space)){
            if(playerGrounded){
                movementDirection.y = jumpSpeed;
            }
            jumpKeyWasPressed = true;
        }
        
        //jumping

        movementDirection.y -= gravity * Time.deltaTime;

        //haracterController.Move(movementDirection * Time.deltaTime);


        //animations
        animator.SetBool("isRunning", Input.GetAxisRaw("Vertical") != 0);
        //animator.SetBool("isJumping", !characterController.isGrounded);


        horizontalInput = Input.GetAxis("Horizontal");

    }

    private void FixedUpdate() {

        if(Physics.OverlapSphere(groundCheckTransform.position, 0.1f).Length == 1){
            Debug.Log("intra if Physics.OverlapSphere...");
            return;
        }

        rigidBody.velocity = new Vector3(horizontalInput, rigidBody.velocity.y, rigidBody.velocity.z);

        // if(Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0){
        //     return;
        // }
        
        if(jumpKeyWasPressed){
            rigidBody.AddForce(Vector3.up * 8, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }

    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == 9){
            Destroy(other.gameObject);
        }
    }
}
