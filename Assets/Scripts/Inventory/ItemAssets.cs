using UnityEngine;

public class ItemAssets : MonoBehaviour {

	public static ItemAssets Instance {get; private set;}

	private void Awake(){
		Instance = this;
	}

	public Sprite swordSprite;
	public Sprite healthPotionSprite;
	public Sprite coinSprite;
	public Sprite keySprite;
};