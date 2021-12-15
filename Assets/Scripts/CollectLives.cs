using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectLives : MonoBehaviour
{
    // Start is called before the first frame update
    LivesBoard livesBoard;
    void Start(){
        livesBoard = FindObjectOfType<LivesBoard>();
    }
    void Update()
   {

   }
     void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject, 0.2f);
            livesBoard.IncreaseScore(1);
            
        }
        
    }
}
