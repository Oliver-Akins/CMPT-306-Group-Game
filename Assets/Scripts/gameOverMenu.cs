using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//attached to gameOverMenu object for restarting the scene 
public class gameOverMenu : MonoBehaviour
{
  public void RestartGame() {
      SceneManager.LoadScene("inGame");
  }
  public void TakeMeToMainMenu(){
    SceneManager.LoadScene("mainMenu");
  }
}
