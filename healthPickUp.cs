using UnityEngine;
using System.Collections;

public class healthPickUp : MonoBehaviour {

	// Use this for initialization
	public float healthAmount;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			//playerHealth theHealth = other.gameObject.GetComponent<playerHealth> ();
			playerHealth theHealth=other.gameObject.GetComponent<playerHealth>();
			theHealth.addHealth (healthAmount);
			Destroy (gameObject);
		}
	}
}
