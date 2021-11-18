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

	private int coin10Trigger = 10;
	public bool coin10Achievement = false;

	private int coin20Trigger = 20;
	public bool coin20Achievement = false;

	private int coin30Trigger = 30;
	public bool coin30Achievement = false;

	private int coin40Trigger = 40;
	public bool coin40Achievement = false;

	private int coin50Trigger = 50;
	public bool coin50Achievement = false;

	// ========================================================================


	// ===================== KEY COLLECTION ACHIEVEMENTS ======================

	private int key5Trigger = 5;
	public bool key5Achievement = false;

	private int key10Trigger = 10;
	public bool key10Achievement = false;

	private int key15Trigger = 15;
	public bool key15Achievement = false;

	private int key20Trigger = 20;
	public bool key20Achievement = false;

	private int key25Trigger = 25;
	public bool key25Achievement = false;

	// ========================================================================


	// =================== POTION COLLECTION ACHIEVEMENTS =====================

	private int potion5Trigger = 5;
	public bool potion5Achievement = false;

	private int potion10Trigger = 10;
	public bool potion10Achievement = false;

	private int potion15Trigger = 15;
	public bool potion15Achievement = false;

	private int potion20Trigger = 20;
	public bool potion20Achievement = false;

	private int potion25Trigger = 25;
	public bool potion25Achievement = false;

	// ========================================================================


	// ================== HEALTH UP COLLECTION ACHIEVEMENTS ===================

	private int healthUp5Trigger = 5;
	public bool healthUp5Achievement = false;

	private int healthUp10Trigger = 10;
	public bool healthUp10Achievement = false;

	private int healthUp15Trigger = 15;
	public bool healthUp15Achievement = false;

	// ========================================================================


	// ================= STRENGTH UP COLLECTION ACHIEVEMENTS ==================

	private int strengthUp5Trigger = 5;
	public bool strengthUp5Achievement = false;

	private int strengthUp10Trigger = 10;
	public bool strengthUp10Achievement = false;

	private int strengthUp15Trigger = 15;
	public bool strengthUp15Achievement = false;

	// ========================================================================


	// ================== AGILITY UP COLLECTION ACHIEVEMENTS ==================

	private int agilityUp5Trigger = 5;
	public bool agilityUp5Achievement = false;

	private int agilityUp10Trigger = 10;
	public bool agilityUp10Achievement = false;

	private int agilityUp15Trigger = 15;
	public bool agilityUp15Achievement = false;

	// ========================================================================


	// ================= STAMINA UP COLLECTION ACHIEVEMENTS ===================

	private int staminaUp5Trigger = 5;
	public bool staminaUp5Achievement = false;

	private int staminaUp10Trigger = 10;
	public bool staminaUp10Achievement = false;

	private int staminaUp15Trigger = 15;
	public bool staminaUp15Achievement = false;

	// ========================================================================


	// =================== POISON COLLECTION ACHIEVEMENTS =====================

	private int poison2Trigger = 2;
	public bool poison2Achievement = false;

	private int poison5Trigger = 5;
	public bool poison5Achievement = false;

	private int poison10Trigger = 10;
	public bool poison10Achievement = false;

	// ========================================================================


	// ====================== TOTAL KILLS ACHIEVEMENTS ========================

	private int kills5Trigger = 5;
	public bool kills5Achievement = false;

	private int kills10Trigger = 10;
	public bool kills10Achievement = false;

	private int kills15Trigger = 15;
	public bool kills15Achievement = false;

	private int kills20Trigger = 20;
	public bool kills20Achievement = false;

	private int kills25Trigger = 25;
	public bool kills25Achievement = false;

	private int kills30Trigger = 30;
	public bool kills30Achievement = false;

	private int kills35Trigger = 35;
	public bool kills35Achievement = false;

	private int kills40Trigger = 40;
	public bool kills40Achievement = false;

	private int kills45Trigger = 45;
	public bool kills45Achievement = false;

	private int kills50Trigger = 50;
	public bool kills50Achievement = false;

	// ========================================================================


	void FixedUpdate() {

		// ================= COIN COLLECTION ACHIEVEMENTS =====================

		if(!coin10Achievement || !coin20Achievement || !coin30Achievement ||
			!coin40Achievement || !coin50Achievement) {

			if(player.coinCollection >= coin10Trigger && !coin10Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text = "Collected 10 coins";
				StartCoroutine(AchievementPanelRoutine());
				coin10Achievement = true;
			}

			if(player.coinCollection >= coin20Trigger && !coin20Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text = "Collected 20 coins";
				StartCoroutine(AchievementPanelRoutine());
				coin20Achievement = true;
			}

			if(player.coinCollection >= coin30Trigger && !coin30Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text = "Collected 30 coins";
				StartCoroutine(AchievementPanelRoutine());
				coin30Achievement = true;
			}

			if(player.coinCollection >= coin40Trigger && !coin40Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text = "Collected 40 coins";
				StartCoroutine(AchievementPanelRoutine());
				coin40Achievement = true;
			}

			if(player.coinCollection >= coin50Trigger && !coin50Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text = "Collected 50 coins";
				StartCoroutine(AchievementPanelRoutine());
				coin50Achievement = true;
			}

		}

		// ====================================================================


		// ================== KEY COLLECTION ACHIEVEMENTS =====================

		if(!key5Achievement || !key10Achievement || !key15Achievement ||
			!key20Achievement || !key25Achievement) {

			if(player.keyCollection >= key5Trigger && !key5Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text = "Collected 5 keys";
				StartCoroutine(AchievementPanelRoutine());
				key5Achievement = true;
			}

			if(player.keyCollection >= key10Trigger && !key10Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text = "Collected 10 keys";
				StartCoroutine(AchievementPanelRoutine());
				key10Achievement = true;
			}

			if(player.keyCollection >= key15Trigger && !key15Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text = "Collected 15 keys";
				StartCoroutine(AchievementPanelRoutine());
				key15Achievement = true;
			}

			if(player.keyCollection >= key20Trigger && !key20Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text = "Collected 20 keys";
				StartCoroutine(AchievementPanelRoutine());
				key20Achievement = true;
			}

			if(player.keyCollection >= key25Trigger && !key25Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text = "Collected 25 keys";
				StartCoroutine(AchievementPanelRoutine());
				key25Achievement = true;
			}

		}

		// ====================================================================


		// ================ POTION COLLECTION ACHIEVEMENTS ====================

		if(!potion5Achievement || !potion10Achievement || !potion15Achievement ||
			!potion20Achievement || !potion25Achievement) {

			if(player.potionCollection >= potion5Trigger && !potion5Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text = "Collected 5 potions";
				StartCoroutine(AchievementPanelRoutine());
				potion5Achievement = true;
			}

			if(player.potionCollection >= potion10Trigger && !potion10Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text = "Collected 10 potions";
				StartCoroutine(AchievementPanelRoutine());
				potion10Achievement = true;
			}

			if(player.potionCollection >= potion15Trigger && !potion15Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text = "Collected 15 potions";
				StartCoroutine(AchievementPanelRoutine());
				potion15Achievement = true;
			}

			if(player.potionCollection >= potion20Trigger && !potion20Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text = "Collected 20 potions";
				StartCoroutine(AchievementPanelRoutine());
				potion20Achievement = true;
			}

			if(player.potionCollection >= potion25Trigger && !potion25Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text = "Collected 25 potions";
				StartCoroutine(AchievementPanelRoutine());
				potion25Achievement = true;
			}

		}

		// ====================================================================


		// ================ HEALTH UP COLLECTION ACHIEVEMENTS =================

		if(!healthUp5Achievement || !healthUp10Achievement || !healthUp15Achievement) {
		
			if(player.healthUpCollection >= healthUp5Trigger && !healthUp5Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 5 health ups";
				StartCoroutine(AchievementPanelRoutine());
				healthUp5Achievement = true;
			}

			if(player.healthUpCollection >= healthUp10Trigger && !healthUp10Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 10 health ups";
				StartCoroutine(AchievementPanelRoutine());
				healthUp10Achievement = true;
			}

			if(player.healthUpCollection >= healthUp15Trigger && !healthUp15Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 15 health ups";
				StartCoroutine(AchievementPanelRoutine());
				healthUp15Achievement = true;
			}
		}

		// ====================================================================


		// =============== STRENGTH UP COLLECTION ACHIEVEMENTS ================

		if(!strengthUp5Achievement || !strengthUp10Achievement || !strengthUp15Achievement) {

			if(player.strengthUpCollection >= strengthUp5Trigger && !strengthUp5Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 5 strength ups";
				StartCoroutine(AchievementPanelRoutine());
				strengthUp5Achievement = true;
			}

			if(player.strengthUpCollection >= strengthUp10Trigger && !strengthUp10Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 10 strength ups";
				StartCoroutine(AchievementPanelRoutine());
				strengthUp10Achievement = true;
			}

			if(player.strengthUpCollection >= strengthUp15Trigger && !strengthUp15Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 15 strength ups";
				StartCoroutine(AchievementPanelRoutine());
				strengthUp15Achievement = true;
			}

		}

		// ====================================================================


		// ================ AGILITY UP COLLECTION ACHIEVEMENTS ================

		if(!agilityUp5Achievement || !agilityUp10Achievement || !agilityUp15Achievement) {

			if(player.agilityUpCollection >= agilityUp5Trigger && !agilityUp5Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 5 agility ups";
				StartCoroutine(AchievementPanelRoutine());
				agilityUp5Achievement = true;
			}

			if(player.agilityUpCollection >= agilityUp10Trigger && !agilityUp10Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 10 agility ups";
				StartCoroutine(AchievementPanelRoutine());
				agilityUp10Achievement = true;
			}

			if(player.agilityUpCollection >= agilityUp15Trigger && !agilityUp15Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 15 agility ups";
				StartCoroutine(AchievementPanelRoutine());
				agilityUp15Achievement = true;
			}
		}

		// ====================================================================


		// =============== STAMINA UP COLLECTION ACHIEVEMENTS =================

		if(!staminaUp5Achievement || !staminaUp10Achievement || !staminaUp15Achievement) {

			if(player.staminaUpCollection >= staminaUp5Trigger && !staminaUp5Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 5 stamina ups";
				StartCoroutine(AchievementPanelRoutine());
				staminaUp5Achievement = true;
			}

			if(player.staminaUpCollection >= staminaUp10Trigger && !staminaUp10Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 10 stamina ups";
				StartCoroutine(AchievementPanelRoutine());
				staminaUp10Achievement = true;
			}

			if(player.staminaUpCollection >= staminaUp15Trigger && !staminaUp15Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 15 stamina ups";
				StartCoroutine(AchievementPanelRoutine());
				staminaUp15Achievement = true;
			}
		}

		// ====================================================================


		// ================= POISON COLLECTION ACHIEVEMENTS ===================

		if(!poison2Achievement || !poison5Achievement || !poison10Achievement) {

			if(player.poisonCollection >= poison2Trigger && !poison2Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Picked up 2 poisons";
				StartCoroutine(AchievementPanelRoutine());
				poison2Achievement = true;
			}

			if(player.poisonCollection >= poison5Trigger && !poison5Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Picked up 5 poisons";
				StartCoroutine(AchievementPanelRoutine());
				poison5Achievement = true;
			}

			if(player.poisonCollection >= poison10Trigger && !poison10Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Picked up 10 poisons";
				StartCoroutine(AchievementPanelRoutine());
				poison10Achievement = true;
			}
		}

		// ====================================================================


		// ==================== TOTAL KILLS ACHIEVEMENTS ======================

		if(!kills5Achievement || !kills10Achievement || !kills15Achievement || 
			!kills20Achievement || !kills25Achievement || !kills30Achievement || 
			!kills35Achievement|| !kills40Achievement|| !kills45Achievement ||
			!kills50Achievement) {

			if(player.killCollection >= kills5Trigger && !kills5Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Killed 5 enemies";
				StartCoroutine(AchievementPanelRoutine());
				kills5Achievement = true;
			}

			if(player.killCollection >= kills10Trigger && !kills10Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Killed 10 enemies";
				StartCoroutine(AchievementPanelRoutine());
				kills10Achievement = true;
			}

			if(player.killCollection >= kills15Trigger && !kills15Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Killed 15 enemies";
				StartCoroutine(AchievementPanelRoutine());
				kills15Achievement = true;
			}

			if(player.killCollection >= kills20Trigger && !kills20Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Killed 20 enemies";
				StartCoroutine(AchievementPanelRoutine());
				kills20Achievement = true;
			}

			if(player.killCollection >= kills25Trigger && !kills25Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Killed 25 enemies";
				StartCoroutine(AchievementPanelRoutine());
				kills25Achievement = true;
			}

			if(player.killCollection >= kills30Trigger && !kills30Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Killed 30 enemies";
				StartCoroutine(AchievementPanelRoutine());
				kills30Achievement = true;
			}

			if(player.killCollection >= kills35Trigger && !kills35Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Killed 35 enemies";
				StartCoroutine(AchievementPanelRoutine());
				kills35Achievement = true;
			}

			if(player.killCollection >= kills40Trigger && !kills40Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Killed 40 enemies";
				StartCoroutine(AchievementPanelRoutine());
				kills40Achievement = true;
			}

			if(player.killCollection >= kills45Trigger && !kills45Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Killed 45 enemies";
				StartCoroutine(AchievementPanelRoutine());
				kills45Achievement = true;
			}

			if(player.killCollection >= kills50Trigger && !kills50Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Killed 50 enemies";
				StartCoroutine(AchievementPanelRoutine());
				kills50Achievement = true;
			}
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