using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public BulletEvent OnShoot;
	public BulletEvent OnSelfDestroy;

	public State CurrentState = State.InPool;

	private void OnCollisionEnter (Collision collision) {
		if (CurrentState == State.InUse)
			DestroyMe();
	}

	void Update () {
		if (CurrentState == State.InUse) {
			transform.position += direction * force;
		}
	}

	#region API

	#region Shoot

	Vector3 direction; 
	float force;

	public void Shoot (Vector3 _direction, float _force) {
		CurrentState = State.InUse;
		if (OnShoot != null) {
			OnShoot (this);
		}
		direction = _direction;
		force = _force;
	}

	#endregion

	public void DestroyMe () {
		CurrentState = State.InPool;
		if (OnShoot != null) {
			OnSelfDestroy (this);
		}
	}

	#endregion

	#region Dichiarazione tipi

	public delegate void BulletEvent(Bullet bullet);

	public enum State {
		InPool,
		InUse
	}

	#endregion
}
