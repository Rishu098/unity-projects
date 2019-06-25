using UnityEngine;
using System.Collections;

public class enemyHealth : MonoBehaviour {

	// Use this for initialization
	public 	float enemyMaxHealth;
	float currentHealth;
	public bool drops;
	public GameObject theDrops;
	void Start () {
		currentHealth = enemyMaxHealth;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void addDamage(float damage){
		currentHealth -= damage;
		if(currentHealth<=0) makeDead();

	}
	void makeDead(){
		Destroy (gameObject);
		if (drops)
			Instantiate (theDrops, transform.position, transform.rotation);
	}
}
