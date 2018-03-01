using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInput : MonoBehaviour {

	[Header("Shoot Settings")]
	public KeyCode ShootInputKey = KeyCode.J; 
	public float ShootForce = 0f;
	public Transform ShootStartingPosition;

	private BulletPoolManager bulletManager;

	// Use this for initialization
	void Start () {
		bulletManager = FindObjectOfType<BulletPoolManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (ShootInputKey)) {
			Shoot ();
		}
	}

	void Shoot () {
		Bullet bulletToShoot = bulletManager.GetBullet ();
		bulletToShoot.transform.position = ShootStartingPosition.position;
		bulletToShoot.Shoot (transform.forward, ShootForce);
	}
}
