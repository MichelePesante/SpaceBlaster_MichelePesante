using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyBehaviour : MonoBehaviour {

    protected bool canMove;
    protected bool isAlive = true;
    protected float respawnTimer = 0f;
    protected float minXPoint = -14f;
    protected float maxXPoint = 14f;

    public float MovementSpeed;
    public Transform ArrivePoint;
    public Transform SpawnTransform;

    void Start()
    {
        EnemySpawn();
    }

    public void EnemySpawn()
    {
        float rng = Random.Range(-14f, 14f);
        transform.DOMoveZ(ArrivePoint.position.z, 2f);
        transform.DOMoveX(ArrivePoint.position.x + rng, 2f);
        canMove = true;
    }

    public void EnemyDeath()
    {
        isAlive = false;
        transform.position = SpawnTransform.position;
        if (GetComponent<ShootInput>() != null)
        {
            GetComponent<ShootInput>().enabled = false;
        }
    }

    public void EnemyRespawn()
    {
        if (!isAlive)
        {
            respawnTimer += Time.deltaTime;
            if (respawnTimer >= 2f)
            {
                EnemySpawn();
                isAlive = true;
                respawnTimer = 0f;
            }
            if (GetComponent<ShootInput>() != null)
            {
                GetComponent<ShootInput>().enabled = true;
            }
        }
    }
}