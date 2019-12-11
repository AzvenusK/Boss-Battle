using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour 
{
	public Transform player = null;
	public GameObject cannonBall= null;
	public Color hitColor = Color.white;
	public float health = 100;
	public float minDelay = 1.0f;
	public float maxDelay = 4.0f;
	public float delayTime = 0.0f;
	public float lastTime = 0.0f;
	private Color originalColor = Color.white;

	void Awake(){
		originalColor = this.GetComponent<Renderer> ().material.color;	
	}
	void Update(){
		FollowPlayer ();
		Shoot ();
	}

	void FollowPlayer(){
		this.transform.LookAt (player);
	}

	void Shoot(){
		if (Time.time > delayTime + lastTime) {
			lastTime = Time.time;
			delayTime = GetRandomValue ();

			GameObject obj = Instantiate (cannonBall, this.transform.position, this.transform.rotation) as GameObject;

			obj.name = "CannonBall";
		}
	}

	float GetRandomValue(){
		return Random.Range (minDelay, maxDelay);
	}

	void OnTriggerEnter (Collider other){
		if(other.name == "MagicOrb"){
			int hp = other.GetComponent<MagicOrb> ().hitpoint;
			GetHealth (hp);
		}
	}

	void GetHealth(int hp){
		if (health > 0) {
			health -= hp;

			StartCoroutine (ColorChange());
		}
		else {
			Destroy (this.gameObject);
		}
	}

	IEnumerator ColorChange(){
		this.GetComponent<Renderer> ().material.color = hitColor;

		yield return new WaitForSeconds (0.4f);

		this.GetComponent<Renderer> ().material.color = originalColor;
	}
}