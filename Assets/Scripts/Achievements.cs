using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.U2D.IK;
using UnityEngine.SocialPlatforms.Impl;
using UnityEditor.AssetImporters;

public class Achievements : MonoBehaviour {


	// general achievement variables
	public Player player;
	public GameObject achievementPanel;
	public GameObject achievementImage;
	public GameObject achievementDescription;
	// private bool achievementRunning = false;

    private Coroutine achievementPanelRoutine;


	// collected 5 coins
	private int coin5Trigger = 5;
	private bool coin5TriggerBoolean = false;

	// collected 10 coins
	private int coin10Trigger = 10;
	private bool coin10TriggerBoolean = false;


	// Update is called once per frame
	void Update() {
		if(player.skillCoins >= coin5Trigger && !coin5TriggerBoolean) {
			achievementDescription.GetComponent<TextMeshProUGUI>().text = "Collected 5 coins!";
			StartCoroutine(AchievementPanelRoutine());
			coin5TriggerBoolean = true;
		}

		if(player.skillCoins >= coin10Trigger && !coin10TriggerBoolean) {
			achievementDescription.GetComponent<TextMeshProUGUI>().text = "Collected 10 coins!";
			StartCoroutine(AchievementPanelRoutine());
			coin10TriggerBoolean = true;
		}
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