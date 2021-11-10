using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private bool jumpKeyWasPressed = false;
    private Rigidbody rigidBody;
    private float horizontalInput;
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private LayerMask playerMask;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space)){
            jumpKeyWasPressed = true;
        }
        
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
