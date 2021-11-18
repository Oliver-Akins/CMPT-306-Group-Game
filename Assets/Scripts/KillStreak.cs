using TMPro;
using UnityEngine;

public class KillStreak : MonoBehaviour {

	// text mesh pro reference
	TextMeshProUGUI text;

	void Awake() {
		text = GetComponent<TextMeshProUGUI>();
	}

	void FixedUpdate() {

		if(AchievementCollection.killStreak > 4) {
			text.text = AchievementCollection.killStreak.ToString() + " KILLSTEAK!";
		} else {
			text.text = "";
		}
	}
};