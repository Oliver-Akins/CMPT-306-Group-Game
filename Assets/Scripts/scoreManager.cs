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
            scoreText.text = "kills count: " + scorePoint.ToString() + " \nthat's it?";
        }
        else {
            scoreText.text = "kills count: " + scorePoint.ToString() + " better luck next time";
        }


    }
}
