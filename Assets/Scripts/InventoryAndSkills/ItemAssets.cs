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

	public Sprite sword;
	public Sprite scythe;
	public Sprite flail;
	public Sprite rock;
	public Sprite arrow;
	public Sprite fireball;
	public Sprite healthPotionSprite;
	public Sprite coinSprite;
	public Sprite keySprite;
};