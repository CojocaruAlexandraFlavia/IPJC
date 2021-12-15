using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPaper : MonoBehaviour
{ 
    ScoreBoard scoreBoard;
    void Start(){
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }
    void Update()
    {
        transform.Rotate(0, 0.5f, 0);
    }
   
     void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        { 
            Destroy(this.gameObject, 0.2f);
            scoreBoard.IncreaseScore(1);
           
        }
        
    }
}
