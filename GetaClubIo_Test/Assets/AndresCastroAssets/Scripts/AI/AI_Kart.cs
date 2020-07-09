using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Kart : MonoBehaviour
{
	[Header("AISettings")]
	public GameDificulty dificulty;
	public Transform circuit;
	public float steeringSensitivity = 0.01f;
	private Vector3 target;

	private int currentWP = 0;
	private ArcadeKart ak;
	private GameObject tracker;
	private int currentTrackerWP = 0;
	private float lookAhead = 10;
	private AIInput input;

	//Setup TrackerObject
	public void Start()
	{
		SetupAIKart();
	}

	void Update()
	{
		ProgressTracker();
		CalculeSteer();
	}

	public void SetupAIKart()
	{
		input = GetComponent<AIInput>();
		ak = this.GetComponent<ArcadeKart>();
		ak.SetCanMove(true);

		target = circuit.GetChild(currentWP).transform.position;

		tracker = new GameObject();
		tracker.transform.position = gameObject.transform.position;
		tracker.transform.rotation = gameObject.transform.rotation;
	}

	//Setup difficult from AGameManager
	public void SetupDifficult()
	{
		if (dificulty == GameDificulty.easy)
		{
			ak.baseStats.TopSpeed -= 1;
			ak.baseStats.Acceleration -= 1;
			steeringSensitivity = 0.011f;
		}
		if (dificulty == GameDificulty.normal)
		{
			ak.baseStats.TopSpeed += 1;
			ak.baseStats.Acceleration += 1;
			steeringSensitivity = 0.011f;
		}
		else if (dificulty == GameDificulty.hard)
		{
			ak.baseStats.TopSpeed += 2;
			ak.baseStats.Acceleration += 2;
			steeringSensitivity = 0.015f;
		}
	}

	//Tracker postion and rotation by waypoint
	void ProgressTracker()
	{
		if (Vector3.Distance(gameObject.transform.position, tracker.transform.position) > lookAhead) return;
		tracker.transform.LookAt(circuit.GetChild(currentTrackerWP).transform.position);
		tracker.transform.Translate(0, 0, 1.0f);

		if (Vector3.Distance(tracker.transform.position, circuit.GetChild(currentTrackerWP).transform.position) < 1)
		{
			currentTrackerWP++;
			if (currentTrackerWP >= circuit.childCount) currentTrackerWP = 0;
		}
	}

	public void CalculeSteer()
	{
		ProgressTracker();
		Vector3 localTarget = gameObject.transform.InverseTransformPoint(tracker.transform.position);
		float targetAngle = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;
		float steer = Mathf.Clamp(targetAngle * steeringSensitivity, -1, 1) * Mathf.Sign(ak.baseStats.Acceleration);

		float brake = 0;
		float accel = 0.5f;

		ak.baseStats.Braking = brake;
		input.verticalValue = accel;
		input.horizontalValue = steer;
	}
}


