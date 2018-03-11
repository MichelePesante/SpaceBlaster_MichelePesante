using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour {

	private NavMeshAgent agent;
	private int destinationPoint = 0;

	public Transform[] points;
	public Transform startingTransform;
	public Transform arriveTransform;

	void Start () {
		agent = GetComponent<NavMeshAgent> ();

		points = new Transform[2];
		points [0] = startingTransform;
		points [1] = arriveTransform;

		GoToNextPoint ();
	}


	void Update () {
		if (!agent.pathPending && agent.remainingDistance < 0.5f) {
			GoToNextPoint ();
		}
	}

	public void GoToNextPoint () {
		if (points.Length == 0)
			return;
		agent.destination = points [destinationPoint].position;
		destinationPoint = (destinationPoint + 1) % points.Length;
	}
}
