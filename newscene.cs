using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class newscene : MonoBehaviour {

	// Use this for initialization
	public string nextLevel;
	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player"))
			{
			SceneManager.LoadScene (nextLevel);
		}
	}
}
