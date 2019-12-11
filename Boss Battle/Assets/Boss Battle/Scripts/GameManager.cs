using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public Hero  hero = null;
	public Turret turret = null;

	public Text heroHealth = null;
	public Text turretHealth  = null;
	public Text magicOrb= null;

	void Update()
	{
		DisplayProperties ();

	}

	void  DisplayProperties()
	{
		heroHealth.text = "Hero: " + hero.health.ToString ();
		turretHealth.text = "Turret: " + turret.health.ToString ();
		magicOrb.text = "MagicOrb: " + hero.magicOrbAmount.ToString ();

	}

}
