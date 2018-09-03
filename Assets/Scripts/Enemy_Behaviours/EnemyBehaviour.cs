using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyBehaviour : MonoBehaviour {

    protected bool canMove;
    protected float minXPoint = -14f;
    protected float maxXPoint = 14f;

    public float MovementSpeed;
    public Transform ArrivePoint;

    void Start()
    {
        EnemyMovement();
    }

    protected virtual void EnemyMovement()
    {
        float rng = Random.Range(-14f, 14f);
        transform.DOMoveZ(ArrivePoint.transform.position.z, 2f);
        transform.DOMoveX(ArrivePoint.transform.position.x + rng, 2f);
        canMove = true;
    }
}