using TMPro;
using UnityEngine;

public class KillStreak : MonoBehaviour {

	public GameObject killStreakCanvas;

	// text mesh pro reference
	public TextMeshProUGUI text;


	void FixedUpdate() {

		if(AchievementCollection.killStreak > 4) {
			killStreakCanvas.SetActive(true);
			text.text = AchievementCollection.killStreak.ToString() + " KILLSTREAK!";
		} else {
			killStreakCanvas.SetActive(false);
		}
	}
};