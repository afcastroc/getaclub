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

	public void Start()
	{
		SetupAIKart();
	}

	void Update()
	{
		ProgressTracker();
		CalculeSteer();
	}

	//Setup TrackerObject
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
		if (dificulty == GameDificulty.easy) SetDifficultParams(-1, -1, 0.011f);
		else if (dificulty == GameDificulty.normal) SetDifficultParams(1, 1, 0.011f);
		else if (dificulty == GameDificulty.hard) SetDifficultParams(2, 2, 0.015f);
	}

	/*Register the speed, acceleration and steer sensitivity top parameters to the AI according to its difficulty
	 * @parm: the speed according difficult level
	 * @parm: the acceleration according difficult level
	 * @parm: the steer sensitivity according difficult level
	 * @return: void
	 */
	public void SetDifficultParams(int speed, int accel, float steerSensitivity)
	{
		ak.baseStats.TopSpeed += speed;
		ak.baseStats.Acceleration += accel;
		steeringSensitivity = steerSensitivity;
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

	//Calcule the steer factor
	public void CalculeSteer()
	{
		ProgressTracker();
		Vector3 localTarget = gameObject.transform.InverseTransformPoint(tracker.transform.position);
		float targetAngle = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;
		float steer = Mathf.Clamp(targetAngle * steeringSensitivity, -1, 1) * Mathf.Sign(ak.baseStats.Acceleration);
		AssignInputsToIA(0, 0.5f, steer);
	}

	/*Assign the brake, acceleration and steer to IA
	 * @parm: the brake to set into IA
	 * @parm: the acceleration to set into IA
	 * @parm: the steer sensitivity to set into IA
	 * @return: void
	 */
	public void AssignInputsToIA(float brake, float accel, float steer)
	{
		ak.baseStats.Braking = brake;
		input.verticalValue = accel;
		input.horizontalValue = steer;
	}
}


