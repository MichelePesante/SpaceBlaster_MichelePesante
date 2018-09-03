using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInput : MonoBehaviour {

	[Header("Shoot Settings")]
	public KeyCode PlayerShootInputKey = KeyCode.J;
    public float EnemyShootAttackSpeed;
	public float ShootForce;
	public Transform ShootStartingPosition;

    private float enemyTimer;
	private BulletPoolManager bulletManager;
    private PlayerMovement player;
    private Enemy enemy;

	// Use this for initialization
	void Start () {
		bulletManager = FindObjectOfType<BulletPoolManager> ();
        if (GetComponent<PlayerMovement>() != null)
        {
            player = GetComponent<PlayerMovement>();
        }
        else if (GetComponent<Enemy>() != null)
        {
            enemy = GetComponent<Enemy>();
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (player)
        {
            if (Input.GetKeyDown(PlayerShootInputKey))
            {
                Shoot();
            }
        }
        if (enemy)
        {
            enemyTimer += Time.deltaTime;
            if (enemyTimer >= EnemyShootAttackSpeed)
            {
                Shoot();
                enemyTimer = 0f;
            }
        }
	}

	void Shoot () {
		Bullet bulletToShoot = bulletManager.GetBullet ();
		bulletToShoot.transform.position = ShootStartingPosition.position;
		bulletToShoot.Shoot (transform.forward, ShootForce);
	}
}
