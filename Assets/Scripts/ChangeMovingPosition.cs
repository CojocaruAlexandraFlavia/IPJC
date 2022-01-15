using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMovingPosition : MonoBehaviour
{
    // Start is called before the first frame update
   
[SerializeField] Transform transformPlayer;
void OnTriggerEnter(Collider other){
    if(other.gameObject.tag == "Player"){
        Debug.Log("Pe platforma");
        other.gameObject.transform.parent = transform;
    }
}
void OnTriggerExit(Collider other){
    Debug.Log("exit playforn");
    if(other.gameObject.tag == "Player"){
        other.gameObject.transform.parent = null;
             
    }
}




}
