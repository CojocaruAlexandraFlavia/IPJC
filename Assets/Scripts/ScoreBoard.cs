using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    // Start is called before the first frame updateint
    public int score = 0;
    TMP_Text scoreText;
    void Start(){
        scoreText = GetComponent<TMP_Text>();
        scoreText.text += score.ToString();
    }
    public void IncreaseScore(int amountToIncrease){
        score += amountToIncrease;
        scoreText.text = "Knowledge: ";
        scoreText.text += score.ToString();
    }
}
