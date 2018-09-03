using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticShooterEnemy : EnemyBehaviour {

    private bool isGoingRight = true;

	void Update () {
        PersonalMovement();
    }

    private void PersonalMovement()
    {
        if (canMove)
        {
            if (isGoingRight)
            {
                transform.position += new Vector3 (MovementSpeed, 0f, 0f);
                if (transform.position.x >= ArrivePoint.transform.position.x + maxXPoint)
                {
                    isGoingRight = false;
                }
            }
            else
            {
                transform.position -= new Vector3 (MovementSpeed, 0f, 0f);
                if (transform.position.x <= ArrivePoint.transform.position.x + minXPoint)
                {
                    isGoingRight = true;
                }
            }
        }
    }
}