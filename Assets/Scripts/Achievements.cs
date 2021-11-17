using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.U2D.IK;
using UnityEngine.SocialPlatforms.Impl;
using UnityEditor.AssetImporters;

public class Achievements : MonoBehaviour {


	// player reference
	public Player player;

	public GameObject achievementPanel;

	public GameObject achievementImage;

	// achievement description game object
	public GameObject achievementDescription;

    private Coroutine achievementPanelRoutine;



	// ==================== COIN COLLECTION ACHIEVEMENTS ======================
	// collected 10 coins achievement variables
	private int coin10Trigger = 10;
	private bool coin10TriggerBoolean = false;

	// collected 20 coins achievement variables
	private int coin20Trigger = 20;
	private bool coin20TriggerBoolean = false;

	// collected 30 coins achievement variables
	private int coin30Trigger = 30;
	private bool coin30TriggerBoolean = false;

	// collected 40 coins achievement variables
	private int coin40Trigger = 40;
	private bool coin40TriggerBoolean = false;

	// collected 50 coins achievement variables
	private int coin50Trigger = 50;
	private bool coin50TriggerBoolean = false;

	// ========================================================================


	// Update is called once per frame
	void Update() {

		// ================= COIN COLLECTION ACHIEVEMENTS =====================

		if(player.skillCoins >= coin10Trigger && !coin10TriggerBoolean) {
			achievementDescription.GetComponent<TextMeshProUGUI>().text = "COIN COLLECTION ACHIVEMENT\n Collected 10 coins";
			StartCoroutine(AchievementPanelRoutine());
			coin10TriggerBoolean = true;
		}

		if(player.skillCoins >= coin20Trigger && !coin20TriggerBoolean) {
			achievementDescription.GetComponent<TextMeshProUGUI>().text = "COIN COLLECTION ACHIVEMENT\n Collected 20 coins";
			StartCoroutine(AchievementPanelRoutine());
			coin20TriggerBoolean = true;
		}

		if(player.skillCoins >= coin30Trigger && !coin30TriggerBoolean) {
			achievementDescription.GetComponent<TextMeshProUGUI>().text = "COIN COLLECTION ACHIVEMENT\n Collected 30 coins";
			StartCoroutine(AchievementPanelRoutine());
			coin30TriggerBoolean = true;
		}

		if(player.skillCoins >= coin40Trigger && !coin40TriggerBoolean) {
			achievementDescription.GetComponent<TextMeshProUGUI>().text = "COIN COLLECTION ACHIVEMENT\n Collected 40 coins";
			StartCoroutine(AchievementPanelRoutine());
			coin40TriggerBoolean = true;
		}

		if(player.skillCoins >= coin50Trigger && !coin50TriggerBoolean) {
			achievementDescription.GetComponent<TextMeshProUGUI>().text = "COIN COLLECTION ACHIVEMENT\n Collected 50 coins";
			StartCoroutine(AchievementPanelRoutine());
			coin50TriggerBoolean = true;
		}

		// ====================================================================
	}



	private IEnumerator AchievementPanelRoutine() {

        // achievementRunning = true;

        achievementImage.SetActive(true);
		achievementPanel.SetActive(true);

        yield return new WaitForSeconds(5);

		achievementPanel.SetActive(false);
		achievementDescription.GetComponent<TextMeshProUGUI>().text = "";
		achievementImage.SetActive(false);

		// achievementRunning = false;

		
    }
};