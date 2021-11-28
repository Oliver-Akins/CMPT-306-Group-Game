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
        scoreText.text = "You have killed " + scorePoint.ToString() + " Zombies!";

    }
}
