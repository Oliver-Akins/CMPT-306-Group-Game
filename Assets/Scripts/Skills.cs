using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skills : MonoBehaviour
{
  public Text skillCoinAmount;
  public int skillCoins;
  public Text strengthAmount;
  public int strength;
  public Text agilityAmount;
  public int agility;
  public Text staminaAmount;
  public int stamina;
  GameStateManager GM;

  	void Awake() {
		GM = GameStateManager.Instance;
	}

    // Function to get data from game state and set local variables
    public void initializeStats(){
      skillCoins = GM.playerStats["skillCoins"];
      strength = GM.playerStats["strength"];
      agility = GM.playerStats["agility"];
      stamina = GM.playerStats["stamina"];
    }

    // Start is called before the first frame update
    void Start()
    {
      initializeStats();

      // For testing - delete when no longer needed
      // skillCoins = 5;
      // strength = 1;
      // agility = 1;
      // stamina = 1;
    }

    // Update is called once per frame - updates local variables to reflect changes in values
    void Update()
    {
      skillCoinAmount.text = skillCoins.ToString();
      strengthAmount.text = strength.ToString();
      agilityAmount.text = agility.ToString();
      staminaAmount.text = stamina.ToString();
    }


    // Values that are called by button presses, updates variables and ensures user cannot set a value that is out of bounds
    public void addStrength(){
      if(skillCoins > 4) {
        strength ++;
        skillCoins -= 5;
      }
    }

    public void subtractStrength(){
      if(strength > 0) {
        strength --;
        skillCoins += 5;
      }
    }

    public void addAgility(){
      if(skillCoins > 4) {
        agility ++;
        skillCoins -= 5;
      }
    }

    public void subtractAgility(){
      if(agility > 0) {
        agility --;
        skillCoins += 5;
      }
    }

    public void addStamina(){
      if(skillCoins > 4) {
        stamina ++;
        skillCoins -= 5;
      }
    }

    public void subtractStamina(){
      if(stamina > 0) {
        stamina --;
        skillCoins += 5;
      }
    }

    //Sets current values in a dictionary and returns it
    private Dictionary<string, int> GetStats() {
        Dictionary<string, int> stats = new Dictionary<string, int>();
        stats.Add("strength", this.strength);
        stats.Add("agility", this.agility);
        stats.Add("stamina", this.stamina);
        stats.Add("skillCoins", this.skillCoins);
        return stats;
    }

      //Call this function when the Between Levels UI closes to update the player stats via GameStateManager and switch the game state
      public void endStatsConfig(){
        Debug.Log("clicked save");
        GM.playerStats = GetStats();
        GM.SetGameState(GameState.IN_GAME);
    }
  }
