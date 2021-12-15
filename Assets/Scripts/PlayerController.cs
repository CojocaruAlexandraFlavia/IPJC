using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController), typeof(Animator))]
public class PlayerController : MonoBehaviour
{

    private CharacterController characterController;
    private Animator animator;
    LivesBoard livesBoard;

    [SerializeField]
    private float movementSpeed, rotationSpeed, jumpSpeed, gravity;
    [SerializeField] private Transform transformPlayer;
    private Vector3 movementDirection = Vector3.zero;
    private bool playerGrounded, jumpKeyWasPressed;
    int collectedPapers = 0, lifes = 3;
    // bool checkPoint = false;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        livesBoard = FindObjectOfType<LivesBoard>();
    }

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
        
        if(transformPlayer.position.y < -5f){      
            Invoke("LoadMyScene", 0.5f);  
            livesBoard.DecreaseLives(1);
             
        }

    }

   

    void LoadMyScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);     
    } 
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Inside OnCollision");
        if(other.gameObject.tag == "Collect")
        {
              
            Debug.Log("Collect");
            collectedPapers += 1;
            Debug.Log("Papers Collected" + collectedPapers);        
              
        }
        if(other.gameObject.tag == "CheckPoint")
        {
            Debug.Log("checkpoint");
            // GameObject varGameObject = GameObject.FindGameObjectWithTag("CheckPoint");
            // varGameObject.GetComponent<CollectPaper>().enabled = false;
        }
       if(other.gameObject.tag == "Heart")
        {
            Debug.Log("New Life");
            lifes += 1;
            
        }
        
        
    }
    void Restart(){
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }

    // void ReloadLevel(){
    //     if(lives == 0){
    //         SceneManager.LoadScene(0);
    //     }
    //     else{
    //         if(checkPoint){
    //             int index = SceneManager.GetActiveScene().buildIndex;
    //             SceneManager.LoadScene(index);
    //         }
    //     }
        
        
    // }

    private void FixedUpdate() {

        Vector3 inputMovement = transform.forward * movementSpeed * Input.GetAxisRaw("Vertical");
        characterController.Move(inputMovement * Time.deltaTime);
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Horizontal") * rotationSpeed);

        if (jumpKeyWasPressed){
            movementDirection.y = jumpSpeed;
            jumpKeyWasPressed = false;
        }

        movementDirection.y -= gravity * Time.deltaTime;

        characterController.Move(movementDirection * Time.deltaTime);
    }
    
}