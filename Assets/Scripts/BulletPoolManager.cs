using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : MonoBehaviour {

	private Vector3 poolPositionOutOfScreen = new Vector3 (1000, 1000, 1000);

	public Bullet BulletPrefab;
	public int BulletsLimit = 20;

	private List<Bullet> bullets = new List<Bullet>();

	void Start () {
		for (int i = 0; i < BulletsLimit; i++) {
			Bullet bulletToAdd = (Instantiate (BulletPrefab));
			bulletToAdd.OnShoot += OnBulletShoot;
			bulletToAdd.OnSelfDestroy += OnBulletDestroy;
			OnBulletDestroy (bulletToAdd);
			bullets.Add (bulletToAdd);
		}
	}

	void OnDisable () {
		foreach (Bullet bullet in bullets) {
			bullet.OnShoot -= OnBulletShoot;
			bullet.OnSelfDestroy -= OnBulletDestroy;
		}
	}

	private void OnBulletShoot (Bullet bullet) {
		
	}

	private void OnBulletDestroy (Bullet bullet) {
		bullet.transform.position = poolPositionOutOfScreen;
	}

	public Bullet GetBullet () {
		foreach (Bullet bullet in bullets) {
			if (bullet.CurrentState == Bullet.State.InPool) {
				return bullet;
			}
		}
		Debug.Log ("Pool esaurito");
		return null;
	}
}
