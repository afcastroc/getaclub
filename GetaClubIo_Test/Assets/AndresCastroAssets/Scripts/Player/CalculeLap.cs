using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculeLap : MonoBehaviour
{
	[Header("Settings")]
	public Transform waypoints;
	public float minDistance = 0f;
	public bool canFinishLap = false;

	private Transform currentWaypoint;
	private int index = 0;

	//Setup the first waypoint for player
	private void Start()
	{
		currentWaypoint = waypoints.GetChild(index);
	}

	//Calcule the waypoint distance and decide next waypoint
	private void Update()
	{
		float distance = Vector3.Distance(transform.position, currentWaypoint.position);
		if (distance < minDistance)
		{
			index++;
			if (index >= waypoints.childCount)
			{
				index = 0;
				canFinishLap = true;
			}
			currentWaypoint = waypoints.GetChild(index);
		}
	}

	//Return if player can finish lap
	public bool CheckForEndLap()
	{
		return canFinishLap;
	}

	//Prepare player to next map
	public void ResetToNewLap()
	{
		canFinishLap = false;
	}
}
