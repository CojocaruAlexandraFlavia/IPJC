using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBench : MonoBehaviour
{
    //Up at the top with your variables:
 private Vector3 dir = Vector3.right;
 [SerializeField] float speed = 2f;
 //Your Update function
 void Update(){
     
 
      if(transform.position.x <= -1){
           dir = Vector3.right;
      }else if(transform.position.x >= 1){
           dir = Vector3.left;
      }
     transform.Translate(dir*speed*Time.deltaTime);
 }


}