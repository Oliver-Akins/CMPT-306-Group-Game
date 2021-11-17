using System.Collections;
using UnityEngine;
using TMPro;

public class Achievements : MonoBehaviour {


	// player reference
	public Player player;

	public GameObject achievementPanel;

	public GameObject achievementImage;

	// achievement title text object
	public GameObject achievementTypeTitle;

	// achievement description text game object
	public GameObject achievementDescription;

    private Coroutine achievementPanelRoutine;


	// ==================== COIN COLLECTION ACHIEVEMENTS ======================

	// collected 10 coins achievement variables
	private int coin10Trigger = 10;
	public bool coin10Achievement = false;

	// collected 20 coins achievement variables
	private int coin20Trigger = 20;
	public bool coin20Achievement = false;

	// collected 30 coins achievement variables
	private int coin30Trigger = 30;
	public bool coin30Achievement = false;

	// collected 40 coins achievement variables
	private int coin40Trigger = 40;
	public bool coin40Achievement = false;

	// collected 50 coins achievement variables
	private int coin50Trigger = 50;
	public bool coin50Achievement = false;

	// ========================================================================


	// ===================== KEY COLLECTION ACHIEVEMENTS ======================

	// collected 10 coins achievement variables
	private int key5Trigger = 5;
	public bool key5Achievement = false;

	// collected 20 coins achievement variables
	private int key10Trigger = 10;
	public bool key10Achievement = false;

	// collected 30 coins achievement variables
	private int key15Trigger = 15;
	public bool key15Achievement = false;

	// collected 40 coins achievement variables
	private int key20Trigger = 20;
	public bool key20Achievement = false;

	// collected 50 coins achievement variables
	private int key25Trigger = 25;
	public bool key25Achievement = false;

	// ========================================================================


	// Update is called once per frame
	void Update() {

		// ================= COIN COLLECTION ACHIEVEMENTS =====================

		if(player.coinsCollected >= coin10Trigger && !coin10Achievement) {
			achievementDescription.GetComponent<TextMeshProUGUI>().text = "Collected 10 coins";
			StartCoroutine(AchievementPanelRoutine());
			coin10Achievement = true;
		}

		if(player.coinsCollected >= coin20Trigger && !coin20Achievement) {
			achievementDescription.GetComponent<TextMeshProUGUI>().text = "Collected 20 coins";
			StartCoroutine(AchievementPanelRoutine());
			coin20Achievement = true;
		}

		if(player.coinsCollected >= coin30Trigger && !coin30Achievement) {
			achievementDescription.GetComponent<TextMeshProUGUI>().text = "Collected 30 coins";
			StartCoroutine(AchievementPanelRoutine());
			coin30Achievement = true;
		}

		if(player.coinsCollected >= coin40Trigger && !coin40Achievement) {
			achievementDescription.GetComponent<TextMeshProUGUI>().text = "Collected 40 coins";
			StartCoroutine(AchievementPanelRoutine());
			coin40Achievement = true;
		}

		if(player.coinsCollected >= coin50Trigger && !coin50Achievement) {
			achievementDescription.GetComponent<TextMeshProUGUI>().text = "Collected 50 coins";
			StartCoroutine(AchievementPanelRoutine());
			coin50Achievement = true;
		}

		// ====================================================================


		// ================== KEY COLLECTION ACHIEVEMENTS =====================

		if(player.keysCollected >= key5Trigger && !key5Achievement) {
			achievementDescription.GetComponent<TextMeshProUGUI>().text = "Collected 5 keys";
			StartCoroutine(AchievementPanelRoutine());
			key5Achievement = true;
		}

		if(player.keysCollected >= key10Trigger && !key10Achievement) {
			achievementDescription.GetComponent<TextMeshProUGUI>().text = "Collected 10 keys";
			StartCoroutine(AchievementPanelRoutine());
			key10Achievement = true;
		}

		if(player.keysCollected >= key15Trigger && !key15Achievement) {
			achievementDescription.GetComponent<TextMeshProUGUI>().text = "Collected 15 keys";
			StartCoroutine(AchievementPanelRoutine());
			key15Achievement = true;
		}

		if(player.keysCollected >= key20Trigger && !key20Achievement) {
			achievementDescription.GetComponent<TextMeshProUGUI>().text = "Collected 20 keys";
			StartCoroutine(AchievementPanelRoutine());
			key20Achievement = true;
		}

		if(player.keysCollected >= key25Trigger && !key25Achievement) {
			achievementDescription.GetComponent<TextMeshProUGUI>().text = "Collected 25 keys";
			StartCoroutine(AchievementPanelRoutine());
			key25Achievement = true;
		}

		// ====================================================================
	}



	private IEnumerator AchievementPanelRoutine() {

        achievementImage.SetActive(true);
		achievementPanel.SetActive(true);

        yield return new WaitForSeconds(7);

		achievementPanel.SetActive(false);
		achievementDescription.GetComponent<TextMeshProUGUI>().text = "";
		achievementImage.SetActive(false);
		
    }
};