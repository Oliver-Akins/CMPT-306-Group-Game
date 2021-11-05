using UnityEngine;
using System.Collections;

// The game's possible states
public enum GameState {
	MAIN_MENU,
	IN_GAME,
	BETWEEN_LEVEL,
	DEATH
}

public delegate void OnStateChangeHandler();

public class GameStateManager {

	protected GameStateManager() {}

	private static GameStateManager instance = null;
	public event OnStateChangeHandler OnStateChange;

	// The state that the game is currently in
	public GameState gameState {
		get;
		private set;
	}

	public static GameStateManager Instance {
		get {
			if (GameStateManager.instance == null){
				GameStateManager.instance = new GameStateManager();
			}
			return GameStateManager.instance;
		}
	}

	public void SetGameState(GameState state){
		this.gameState = state;
		OnStateChange();
	}

	public void OnApplicationQuit(){
		GameStateManager.instance = null;
	}
}