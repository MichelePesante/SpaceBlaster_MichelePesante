using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserEnemy : EnemyBehaviour {

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
            if (Vector3.Distance(transform.position, playerToFollow.transform.position) > 0f)
            {
                transform.position += transform.forward * MovementSpeed;
            }
        }
    }
}
