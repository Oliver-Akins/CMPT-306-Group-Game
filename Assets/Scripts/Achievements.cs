using System.Collections;
using UnityEngine;
using TMPro;

public class Achievements : MonoBehaviour {


	public GameObject achievementPanel;

	public AudioSource achievementSound;

	public GameObject achievementImage;

	// achievement title text object
	public GameObject achievementTypeTitle;

	// achievement description text game object
	public GameObject achievementDescription;

    private Coroutine achievementPanelRoutine;


	// ==================== COIN COLLECTION ACHIEVEMENTS ======================

	private int coin20Trigger = 20;
	private int coin40Trigger = 40;
	private int coin60Trigger = 60;
	private int coin80Trigger = 80;
	private int coin100Trigger = 100;

	// ========================================================================


	// ===================== KEY COLLECTION ACHIEVEMENTS ======================

	private int key5Trigger = 5;
	private int key10Trigger = 10;
	private int key15Trigger = 15;
	private int key20Trigger = 20;
	private int key25Trigger = 25;

	// ========================================================================


	// =================== POTION COLLECTION ACHIEVEMENTS =====================

	private int potion5Trigger = 5;
	private int potion10Trigger = 10;
	private int potion15Trigger = 15;
	private int potion20Trigger = 20;
	private int potion25Trigger = 25;

	// ========================================================================


	// ================== HEALTH UP COLLECTION ACHIEVEMENTS ===================

	private int healthUp5Trigger = 5;
	private int healthUp10Trigger = 10;
	private int healthUp15Trigger = 15;

	// ========================================================================


	// ================= STRENGTH UP COLLECTION ACHIEVEMENTS ==================

	private int strengthUp5Trigger = 5;
	private int strengthUp10Trigger = 10;
	private int strengthUp15Trigger = 15;

	// ========================================================================


	// ================== AGILITY UP COLLECTION ACHIEVEMENTS ==================

	private int agilityUp5Trigger = 5;
	private int agilityUp10Trigger = 10;
	private int agilityUp15Trigger = 15;

	// ========================================================================


	// ================= STAMINA UP COLLECTION ACHIEVEMENTS ===================

	private int staminaUp5Trigger = 5;
	private int staminaUp10Trigger = 10;
	private int staminaUp15Trigger = 15;

	// ========================================================================


	// =================== POISON COLLECTION ACHIEVEMENTS =====================

	private int poison2Trigger = 2;
	private int poison5Trigger = 5;
	private int poison10Trigger = 10;

	// ========================================================================


	// ====================== TOTAL KILLS ACHIEVEMENTS ========================

	private int kills5Trigger = 5;
	private int kills10Trigger = 10;
	private int kills15Trigger = 15;
	private int kills20Trigger = 20;
	private int kills25Trigger = 25;
	private int kills30Trigger = 30;
	private int kills35Trigger = 35;
	private int kills40Trigger = 40;
	private int kills45Trigger = 45;
	private int kills50Trigger = 50;

	// ========================================================================

	public void checkAchievements() {

		// ================= COIN COLLECTION ACHIEVEMENTS =====================

		if(!AchievementCollection.coin20Achievement || !AchievementCollection.coin40Achievement || !AchievementCollection.coin60Achievement ||
			!AchievementCollection.coin80Achievement || !AchievementCollection.coin100Achievement) {

			if(AchievementCollection.coinCollection >= coin20Trigger && !AchievementCollection.coin20Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 20 coins";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.coin20Achievement = true;
			}

			if(AchievementCollection.coinCollection >= coin40Trigger && !AchievementCollection.coin40Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 40 coins";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.coin40Achievement = true;
			}

			if(AchievementCollection.coinCollection >= coin60Trigger && !AchievementCollection.coin60Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text = 
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 60 coins";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.coin60Achievement = true;
			}

			if(AchievementCollection.coinCollection >= coin80Trigger && !AchievementCollection.coin80Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 80 coins";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.coin80Achievement = true;
			}

			if(AchievementCollection.coinCollection >= coin100Trigger && !AchievementCollection.coin100Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 100 coins";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.coin100Achievement = true;
			}

		}

		// ====================================================================


		// ================== KEY COLLECTION ACHIEVEMENTS =====================

		if(!AchievementCollection.key5Achievement || !AchievementCollection.key10Achievement || !AchievementCollection.key15Achievement ||
			!AchievementCollection.key20Achievement || !AchievementCollection.key25Achievement) {

			if(AchievementCollection.keyCollection >= key5Trigger && !AchievementCollection.key5Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 5 keys";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.key5Achievement = true;
			}

			if(AchievementCollection.keyCollection >= key10Trigger && !AchievementCollection.key10Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 10 keys";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.key10Achievement = true;
			}

			if(AchievementCollection.keyCollection >= key15Trigger && !AchievementCollection.key15Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 15 keys";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.key15Achievement = true;
			}

			if(AchievementCollection.keyCollection >= key20Trigger && !AchievementCollection.key20Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 20 keys";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.key20Achievement = true;
			}

			if(AchievementCollection.keyCollection >= key25Trigger && !AchievementCollection.key25Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 25 keys";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.key25Achievement = true;
			}

		}

		// ====================================================================


		// ================ POTION COLLECTION ACHIEVEMENTS ====================

		if(!AchievementCollection.potion5Achievement || !AchievementCollection.potion10Achievement || !AchievementCollection.potion15Achievement ||
			!AchievementCollection.potion20Achievement || !AchievementCollection.potion25Achievement) {

			if(AchievementCollection.potionCollection >= potion5Trigger && !AchievementCollection.potion5Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 5 potions";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.potion5Achievement = true;
			}

			if(AchievementCollection.potionCollection >= potion10Trigger && !AchievementCollection.potion10Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 10 potions";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.potion10Achievement = true;
			}

			if(AchievementCollection.potionCollection >= potion15Trigger && !AchievementCollection.potion15Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 15 potions";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.potion15Achievement = true;
			}

			if(AchievementCollection.potionCollection >= potion20Trigger && !AchievementCollection.potion20Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 20 potions";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.potion20Achievement = true;
			}

			if(AchievementCollection.potionCollection >= potion25Trigger && !AchievementCollection.potion25Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 25 potions";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.potion25Achievement = true;
			}

		}

		// ====================================================================


		// ================ HEALTH UP COLLECTION ACHIEVEMENTS =================

		if(!AchievementCollection.healthUp5Achievement || !AchievementCollection.healthUp10Achievement || !AchievementCollection.healthUp15Achievement) {
		
			if(AchievementCollection.healthUpCollection >= healthUp5Trigger && !AchievementCollection.healthUp5Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 5 health ups";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.healthUp5Achievement = true;
			}

			if(AchievementCollection.healthUpCollection >= healthUp10Trigger && !AchievementCollection.healthUp10Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 10 health ups";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.healthUp10Achievement = true;
			}

			if(AchievementCollection.healthUpCollection >= healthUp15Trigger && !AchievementCollection.healthUp15Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 15 health ups";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.healthUp15Achievement = true;
			}
		}

		// ====================================================================


		// =============== STRENGTH UP COLLECTION ACHIEVEMENTS ================

		if(!AchievementCollection.strengthUp5Achievement || !AchievementCollection.strengthUp10Achievement || !AchievementCollection.strengthUp15Achievement) {

			if(AchievementCollection.strengthUpCollection >= strengthUp5Trigger && !AchievementCollection.strengthUp5Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 5 strength ups";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.strengthUp5Achievement = true;
			}

			if(AchievementCollection.strengthUpCollection >= strengthUp10Trigger && !AchievementCollection.strengthUp10Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 10 strength ups";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.strengthUp10Achievement = true;
			}

			if(AchievementCollection.strengthUpCollection >= strengthUp15Trigger && !AchievementCollection.strengthUp15Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 15 strength ups";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.strengthUp15Achievement = true;
			}

		}

		// ====================================================================


		// ================ AGILITY UP COLLECTION ACHIEVEMENTS ================

		if(!AchievementCollection.agilityUp5Achievement || !AchievementCollection.agilityUp10Achievement || !AchievementCollection.agilityUp15Achievement) {

			if(AchievementCollection.agilityUpCollection >= agilityUp5Trigger && !AchievementCollection.agilityUp5Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 5 agility ups";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.agilityUp5Achievement = true;
			}

			if(AchievementCollection.agilityUpCollection >= agilityUp10Trigger && !AchievementCollection.agilityUp10Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 10 agility ups";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.agilityUp10Achievement = true;
			}

			if(AchievementCollection.agilityUpCollection >= agilityUp15Trigger && !AchievementCollection.agilityUp15Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 15 agility ups";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.agilityUp15Achievement = true;
			}
		}

		// ====================================================================


		// =============== STAMINA UP COLLECTION ACHIEVEMENTS =================

		if(!AchievementCollection.staminaUp5Achievement || !AchievementCollection.staminaUp10Achievement || !AchievementCollection.staminaUp15Achievement) {

			if(AchievementCollection.staminaUpCollection >= staminaUp5Trigger && !AchievementCollection.staminaUp5Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 5 stamina ups";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.staminaUp5Achievement = true;
			}

			if(AchievementCollection.staminaUpCollection >= staminaUp10Trigger && !AchievementCollection.staminaUp10Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 10 stamina ups";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.staminaUp10Achievement = true;
			}

			if(AchievementCollection.staminaUpCollection >= staminaUp15Trigger && !AchievementCollection.staminaUp15Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Collected 15 stamina ups";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.staminaUp15Achievement = true;
			}
		}

		// ====================================================================


		// ================= POISON COLLECTION ACHIEVEMENTS ===================

		if(!AchievementCollection.poison2Achievement || !AchievementCollection.poison5Achievement || !AchievementCollection.poison10Achievement) {

			if(AchievementCollection.poisonCollection >= poison2Trigger && !AchievementCollection.poison2Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Picked up 2 poisons";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.poison2Achievement = true;
			}

			if(AchievementCollection.poisonCollection >= poison5Trigger && !AchievementCollection.poison5Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Picked up 5 poisons";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.poison5Achievement = true;
			}

			if(AchievementCollection.poisonCollection >= poison10Trigger && !AchievementCollection.poison10Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Picked up 10 poisons";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.poison10Achievement = true;
			}
		}

		// ====================================================================


		// ==================== TOTAL KILLS ACHIEVEMENTS ======================

		if(!AchievementCollection.kills5Achievement || !AchievementCollection.kills10Achievement || !AchievementCollection.kills15Achievement || 
			!AchievementCollection.kills20Achievement || !AchievementCollection.kills25Achievement || !AchievementCollection.kills30Achievement || 
			!AchievementCollection.kills35Achievement|| !AchievementCollection.kills40Achievement|| !AchievementCollection.kills45Achievement ||
			!AchievementCollection.kills50Achievement) {

			if(AchievementCollection.killCollection >= kills5Trigger && !AchievementCollection.kills5Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Killed 5 enemies";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.kills5Achievement = true;
			}

			if(AchievementCollection.killCollection >= kills10Trigger && !AchievementCollection.kills10Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Killed 10 enemies";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.kills10Achievement = true;
			}

			if(AchievementCollection.killCollection >= kills15Trigger && !AchievementCollection.kills15Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Killed 15 enemies";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.kills15Achievement = true;
			}

			if(AchievementCollection.killCollection >= kills20Trigger && !AchievementCollection.kills20Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Killed 20 enemies";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.kills20Achievement = true;
			}

			if(AchievementCollection.killCollection >= kills25Trigger && !AchievementCollection.kills25Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Killed 25 enemies";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.kills25Achievement = true;
			}

			if(AchievementCollection.killCollection >= kills30Trigger && !AchievementCollection.kills30Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Killed 30 enemies";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.kills30Achievement = true;
			}

			if(AchievementCollection.killCollection >= kills35Trigger && !AchievementCollection.kills35Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Killed 35 enemies";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.kills35Achievement = true;
			}

			if(AchievementCollection.killCollection >= kills40Trigger && !AchievementCollection.kills40Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Killed 40 enemies";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.kills40Achievement = true;
			}

			if(AchievementCollection.killCollection >= kills45Trigger && !AchievementCollection.kills45Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Killed 45 enemies";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.kills45Achievement = true;
			}

			if(AchievementCollection.killCollection >= kills50Trigger && !AchievementCollection.kills50Achievement) {
				achievementDescription.GetComponent<TextMeshProUGUI>().text =
					"Killed 50 enemies";
				StartCoroutine(AchievementPanelRoutine());
				AchievementCollection.kills50Achievement = true;
			}
		}

		// ====================================================================
	}

	private IEnumerator AchievementPanelRoutine() {

        achievementImage.SetActive(true);
		achievementPanel.SetActive(true);

		achievementSound.Play();

        yield return new WaitForSeconds(7);

		achievementPanel.SetActive(false);
		achievementDescription.GetComponent<TextMeshProUGUI>().text = "";
		achievementImage.SetActive(false);
    }
};