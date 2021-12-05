using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    int scorePoint;
    public Text scoreText;
    
    
    void Update()
    {
        scorePoint = AchievementCollection.killCollection;
        if(scorePoint < 5){
            scoreText.text = "Kills count: " + scorePoint.ToString() + 
            " \nThat's it?";
        }
        else {
            scoreText.text = "Kills count: " + scorePoint.ToString() + 
            " \nBetter Luck Next Time";
        }


    }
}
