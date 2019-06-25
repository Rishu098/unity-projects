using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class playerHealth : MonoBehaviour {

	// Use this for initialization
	public float fullHealth;
	public GameObject deathFX;
	public AudioClip playerHurt;
	AudioSource playerAS;
	float currentHealth;
	public restartGame theGameManager;
	playercontrol controlMovement;
	// HUD variables
	public Slider healthSlider; 
	public Image damageScreen;
	public Text gameOverScreen;
	Color damagedColor = new Color (0f,0f,0f,0.5f);
	float smoothColor = 5f;
	bool damaged = false;
	void Start () {
		currentHealth = fullHealth;
		controlMovement = GetComponent<playercontrol> ();
		// HUD initialization
		healthSlider.maxValue = fullHealth;
		healthSlider.value = fullHealth;
		damaged = false;
		playerAS = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (damaged) {
			damageScreen.color = damagedColor;
		} else {
			damageScreen.color = Color.Lerp(damageScreen.color,Color.clear,smoothColor*Time.deltaTime);
		}
		damaged = false;
	}
	public void addDamage (float damage){
		if (damage <= 0) return;
		currentHealth -= damage;
		playerAS.clip = playerHurt;
		playerAS.Play();
		damaged = true;
		healthSlider.value = currentHealth;
		if (currentHealth <= 0) {
			makeDead();
		} 
	}
	public void addHealth(float health){
		currentHealth += health;
		if (currentHealth > fullHealth)
			currentHealth = fullHealth;
		healthSlider.value = currentHealth;
	}
	public void makeDead(){
		Instantiate(deathFX, transform.position, transform.rotation);
		Destroy(gameObject);
		damageScreen.color = damagedColor;
		Animator gameOverAnimator = gameOverScreen.GetComponent<Animator> ();
		gameOverAnimator.SetTrigger ("gameOver");
		theGameManager.restartTheGame ();
	}
}
