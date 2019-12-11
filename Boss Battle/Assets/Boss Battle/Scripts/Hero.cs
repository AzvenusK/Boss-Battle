using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour 
{
	public int health = 100;
	public float moveSpeed = 5.0f;
	public float rotationSpeed = 75.0f;
	public int magicOrbAmount = 50;
	public GameObject magicOrb = null;
	public Transform socket = null; 

	void Update(){
		Move ();
		Shoot (); 
	}

	void Move(){
		float move = Input.GetAxis ("Vertical") * moveSpeed;
		float rotate = Input.GetAxis ("Horizontal") * rotationSpeed;
		this.transform.Translate (0, 0, move * Time.deltaTime);
		this.transform.Rotate (0, rotate * Time.deltaTime, 0);
	}

	void Shoot(){
			if (Input.GetButtonDown ("Fire1")) {
			if (magicOrbAmount > 0){
				magicOrbAmount--;
				GameObject obj = Instantiate (magicOrb, socket.position, socket.rotation) as GameObject;
				obj.name = "MagicOrb";
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.name == "CannonBall") {
			int hp = other.GetComponent<Cannonball> ().hitPoint;
			GetHealth (hp);
		}
	}

	void GetHealth(int hp){
		if (health > 0) {
			health -= hp;
			Debug.Log ("Hero hit for hp : " +hp+"\n Hero health : "+health);
		} 
		else {
			Debug.Log ("Game Over");
		}
	}
			
	
}
