using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelHole : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {

		if(col.CompareTag("Player")) {

			SceneManager.LoadScene("betweenLevels");

		}
		
		}
}