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


    // Start is called before the first frame update
    void Start()
    {
      skillCoins = 5;
      strength = 1;
      agility = 1;
      stamina = 1;
    }

    // Update is called once per frame
    void Update()
    {
      skillCoinAmount.text = skillCoins.ToString();
      strengthAmount.text = strength.ToString();
      agilityAmount.text = agility.ToString();
      staminaAmount.text = stamina.ToString();
    }

    public void addStrength(){
      if(skillCoins != 0) {
        strength ++;
        skillCoins --;
      }
    }

    public void subtractStrength(){
      if(strength > 0) {
        strength --;
        skillCoins ++;
      }
    }

    public void addAgility(){
      if(skillCoins != 0) {
        agility ++;
        skillCoins --;
      }
    }

    public void subtractAgility(){
      if(agility > 0) {
        agility --;
        skillCoins ++;
      }
    }

    public void addStamina(){
      if(skillCoins != 0) {
        stamina ++;
        skillCoins --;
      }
    }

    public void subtractStamina(){
      if(stamina > 0) {
        stamina --;
        skillCoins ++;
      }
    }
}
