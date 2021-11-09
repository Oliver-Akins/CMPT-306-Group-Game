using TMPro;
using UnityEngine;

public class PlayerText : MonoBehaviour {

	// enum for object types
	public enum Type{COIN, KEY}

	// set object type
	public Type type;
	
	// text mesh pro reference
	TextMeshProUGUI text;

	// player reference
	private Player player;

	void Awake() {
		text = GetComponent<TextMeshProUGUI>();
		player = FindObjectOfType<Player>();
	}

	void Update() {
		
		// update corresponding text depending on object type
		switch(type) {

				case Type.COIN: {
					text.text = player.skillCoins.ToString();
					break;
				}

				case Type.KEY: {
					text.text = player.keys.ToString();
					break;
				}
			}
	}
};