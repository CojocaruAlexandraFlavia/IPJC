using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LivesBoard : MonoBehaviour
{
    public int lives = 3;
    TMP_Text liveText;
    void Start(){
        liveText = GetComponent<TMP_Text>();
        liveText.text += lives.ToString();
    }
    public void IncreaseScore(int amountToIncrease){
        lives += amountToIncrease;
        liveText.text = "Lives: ";
        liveText.text += lives.ToString();
    }
    public void DecreaseLives(int amountToDecrease){
        lives -= amountToDecrease;
        liveText.text = "Lives: ";
        liveText.text += lives.ToString();
    }
}
