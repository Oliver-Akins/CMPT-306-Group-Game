using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// The game's possible states
public enum GameState {
	MAIN_MENU,
	IN_GAME,
	BETWEEN_LEVEL,
	DEATH
}

public delegate void OnStateChangeHandler();

public class GameStateManager {

	// Class instantiator
	protected GameStateManager() {}


	// Singleton instance
	private static GameStateManager instance = null;

	// The event listeners for when the state changes
	public event OnStateChangeHandler OnStateChange;

	// The state that the game is currently in
	public GameState gameState {
		get; // allow anyone to read
		private set; // only allow this class to set
	}

	// Access the singleton object in the other areas as needed. Called be using
	// GameStateManager.Instance
	// if an instance doesn't already exist it will create one then return it.
	public static GameStateManager Instance {
		get {
			if (GameStateManager.instance == null){
				GameStateManager.instance = new GameStateManager();
			}
			return GameStateManager.instance;
		}
	}

	// Sets the state of the game
	public void SetGameState(GameState state){
		this.gameState = state;

		// Call all of the event listeners that exist
		OnStateChange();
	}

	// When quitting the application, make sure to purge the singleton so that
	// it doesn't get accidentally saved.
	public void OnApplicationQuit(){
		GameStateManager.instance = null;
	}
}