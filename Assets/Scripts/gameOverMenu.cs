using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//attached to gameOverMenu object for restarting the scene
public class gameOverMenu : MonoBehaviour {
	public void TakeMeToMainMenu(){
		GameStateManager.Instance.SetGameState(GameState.MAIN_MENU);
	}
}
