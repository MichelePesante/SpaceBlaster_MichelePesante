using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicShooterEnemy : EnemyBehaviour {

    private bool isGoingRight = true;
    private Player playerToFollow;

    void Start()
    {
        playerToFollow = FindObjectOfType<Player>();
        EnemySpawn();
    }

    void Update()
    {
        PersonalMovement();
    }

    private void PersonalMovement()
    {
        if (isAlive)
        {
            transform.LookAt(playerToFollow.transform);
            if (canMove)
            {
                if (isGoingRight)
                {
                    transform.position += new Vector3(MovementSpeed, 0f, 0f);
                    if (transform.position.x >= ArrivePoint.transform.position.x + maxXPoint)
                    {
                        isGoingRight = false;
                    }
                }
                else
                {
                    transform.position -= new Vector3(MovementSpeed, 0f, 0f);
                    if (transform.position.x <= ArrivePoint.transform.position.x + minXPoint)
                    {
                        isGoingRight = true;
                    }
                }
            }
        }
    }
}
