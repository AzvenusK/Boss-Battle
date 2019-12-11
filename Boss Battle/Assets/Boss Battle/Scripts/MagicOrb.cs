using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MagicOrb : MonoBehaviour 
{
	//speed, hitpoint, shoot audio, hit audio, particle system
	public int hitpoint = 10;
	public float speed = 10.0f;
	public AudioClip hitAudio = null;
	public AudioClip shootAudio = null;
	public ParticleSystem particle1 = null;
	private bool canMove = true;
	void Awake (){
		this.GetComponent<AudioSource> ().PlayOneShot (shootAudio);
	}

	void Update(){
		MoveObject ();
	}

	void MoveObject(){
		if (canMove) {
			this.transform.Translate (0, 0, speed * Time.deltaTime); 
		}
	}

	void OnTriggerEnter (Collider other){
		this.GetComponent<AudioSource> ().PlayOneShot (hitAudio);
		this.GetComponent<Renderer> ().enabled = false;
		this.GetComponent<Collider> ().enabled = false;
		canMove = false;
		particle1.enableEmission = false;
		Destroy (this.gameObject, hitAudio.length);
	}

 }
