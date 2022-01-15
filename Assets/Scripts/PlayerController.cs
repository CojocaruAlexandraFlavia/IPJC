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
    ScoreBoard scoreBoard;

    [SerializeField]
    private float movementSpeed, rotationSpeed, jumpSpeed, gravity;
    [SerializeField] Transform transformPlayer;
    [SerializeField] int paperToCollect;
    private Vector3 movementDirection = Vector3.zero;
    private bool playerGrounded, jumpKeyWasPressed;
    public GameObject spawnPoint, collect;
    // bool checkPoint = false;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        livesBoard = FindObjectOfType<LivesBoard>();
        scoreBoard = FindObjectOfType<ScoreBoard>();
        spawnPoint = GameObject.FindWithTag("Start");
        collect = GameObject.Find("Collect");
        paperToCollect = collect.transform.childCount*100;
        
        spawnPoint.tag = "LastCheckPoint";
    }

    void Update()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
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
        
        if(transform.position.y < -5f){   
            //daca cade scadem vietile    
           
            RespawnPlayer();
        }

    }

    void RespawnPlayer(){
        livesBoard.DecreaseLives(1);   
        if(livesBoard.lives == 0){
                //daca nu mai avem vieti, incepem nivelul de la capat
            Invoke("LoadMyScene", 0f);  
        }
        else{
                // daca mai avem vieti, ne respawnam la ultimul checkpoint
            transformPlayer.position = spawnPoint.transform.position;
        }
    }
    void LoadMyScene(){
        livesBoard.lives = 3;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);     
    } 
    void OnTriggerEnter(Collider other)
    {
    //     if(other.gameObject.tag == "Collect")
    //     {
              
    //         Debug.Log("Collect");
    //         // collectedPapers += 1;
    //         // Debug.Log("Papers Collected" + collectedPapers);        
              
    //     }
    //    else if(other.gameObject.tag == "Heart")
    //     {
    //         Debug.Log("New Life");
            
            
    //     }
    //     else 
        if (other.gameObject.tag == "CheckPoint"){
            other.gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = Color.magenta;
            //GameObject.FindWithTag("Flag").GetComponent<MeshRenderer>().material.color = Color.magenta;
            other.gameObject.tag = "Checked";
            GameObject.FindWithTag("Flag").tag = "CheckedFlag";
            spawnPoint = other.gameObject;
        }
        else if(other.gameObject.tag == "Finish"){
            if(scoreBoard.score != paperToCollect){
                Debug.Log("Nu ai acumulat toate cunostintele!");
            }
            else{
                Debug.Log("Cunostinte acumutale");
                LoadNextLevel();
                
                
            }
              
        }
        else if (other.gameObject.tag == "EvilBook"){
                RespawnPlayer();

        }
       
         
        // else if(other.gameObject.tag == "Platform"){
        //          Debug.Log("In moving");
        //         transform.parent = other.gameObject.transform;
                //  Debug.Log(other.transform.position.x);
               // transform.position = other.gameObject.transform.position;
                
         //}
        
        
    
     } 
    // void Restart(){
    //     int index = SceneManager.GetActiveScene().buildIndex;
    //     SceneManager.LoadScene(index);
    // }

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

    // void OnTriggerStay(Collider other){
        
             
    //          if(other.gameObject.tag == "Platform"){
    //              Debug.Log("In moving");
    //             transform.position = other.transform.position;
    //             transform.rotation = other.transform.rotation;
    //      }
    //  }
 
    void LoadNextLevel(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("LastLevelIndex", currentSceneIndex + 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene(currentSceneIndex);    
    }
    
}