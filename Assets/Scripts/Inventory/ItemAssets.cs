using UnityEngine;

/**
	this holds references to sprite images so each non stackable item
	only references one image
*/
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