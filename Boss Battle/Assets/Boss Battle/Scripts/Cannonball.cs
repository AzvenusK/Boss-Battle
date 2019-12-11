using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour 
{
	public int hitPoint = 20;
	public float minForce = 200.0f;
	public float maxForce = 300.0f;
	public float delayTime = 2.0f;
	public AudioClip hitAudio = null;
	public AudioClip shootAudio = null;
	public ParticleSystem particle = null;
	private bool isAwake = true;
	void Awake(){
		this.GetComponent<Rigidbody> ().AddRelativeForce (new Vector3 (0, Random.Range (minForce, maxForce), Random.Range (minForce, maxForce)));
		this.GetComponent<AudioSource> ().PlayOneShot (shootAudio);
	} 

	void OnTriggerEnter (Collider other){
		if (isAwake) {
			isAwake = false;

			this.GetComponent<AudioSource> ().PlayOneShot (shootAudio);

			StartCoroutine (DisableParticle ());
		}
	}

	IEnumerator DisableParticle(){
		yield return new WaitForSeconds (delayTime);

		particle.enableEmission = false;

		hitPoint = 0;
	}
}
