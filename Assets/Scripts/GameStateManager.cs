using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

// The game's possible states
public enum GameState {
	MAIN_MENU,
	IN_GAME,
	BETWEEN_LEVEL,
	DEATH,
	CREDITS,
	CONTROLS
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
	public void SetGameState(GameState state, bool changeScene = true) {

		this.gameState = state;

		// Check if the caller is wanting to change the scene as well
		if (changeScene) {

			// Load the scene that is associated with that game state
			switch (state) {
				case GameState.IN_GAME:
					SceneManager.LoadScene("inGame");
					break;
				case GameState.BETWEEN_LEVEL:
					// Get the player info before the gameobject gets destroyed
					if (this._player) {
						this._playerStats = this._player.GetStats();
						this.inventory = this._player.GetInventoryItems();
						this.equippedItems = this._player.GetEquippedWeaps();
						this.skillLevels = this._player.GetSkillLevels();
					};

					this._level++;

					SceneManager.LoadScene("betweenLevels");
					break;
				case GameState.CREDITS:
					SceneManager.LoadScene("Credits");
					break;
				case GameState.CONTROLS:
					SceneManager.LoadScene("controls");
					break;
				default:
					this._level = 1;
					SceneManager.LoadScene("mainMenu");
					break;
			};
		};


		// Call all of the event listeners if any exist
		if (OnStateChange != null) {
			OnStateChange();
		};
	}

	// When quitting the application, make sure to purge the singleton so that
	// it doesn't get accidentally saved.
	public void OnApplicationQuit(){
		GameStateManager.instance = null;
	}


	//=======================================================================\\
	// Generic game-data

	private int _level = 1;
	public int level {
		get {
			return this._level;
		}
	}

	//=======================================================================\\
	// Methods relating to the player data


	// Allow the player property to be set from anywhere if it isn't defined
	// already, otherwise it will not be updated and will not throw an error
	private Player _player = null;
	public Player player {
		private get {
			return this._player;
		}
		set {
			if (this._player == null) {
				this._player = value;
			}
		}
	}

	// The player's inventory, allowing them to save their items between levels
	public List<InventoryItem> inventory = null;

	public Dictionary<string, InventoryItem> equippedItems = null;

	public Dictionary<string, int> skillLevels = null;

	// Allow updating the player's stats by passing a dictionary through with
	// the stats that are able to be updated
	private Dictionary<string, int> _playerStats = null;
	public Dictionary<string, int> playerStats {
		get {
			return this._playerStats;
		}
		set {
			this._playerStats = value;
		}
	}
}