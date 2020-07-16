using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drift : MonoBehaviour
{
	[Header("Settings")]
	public ArcadeKart kart;
	private bool drifting = false;

	private void Update()
	{
		CheckForDrift();
	}

	//Checking inputs if player is drifting
	public void CheckForDrift()
	{
		if (Input.GetAxis("Horizontal") != 0f && Input.GetKey(KeyCode.Space) && !drifting) SetDriftValues();
		else if (drifting && !Input.GetKey(KeyCode.Space)) SetNormalValues();
	}

	//Set Values to wheels if player is drifting
	private void SetDriftValues()
	{
		drifting = true;
		foreach (Transform wc in kart.Wheels)
		{
			WheelFrictionCurve sideways = new WheelFrictionCurve();
			sideways.extremumSlip = 0.05f;
			sideways.extremumValue = 0.02f;
			sideways.asymptoteSlip = 0.5f;
			sideways.asymptoteValue = 0.75f;
			sideways.stiffness = 3f;
			wc.GetComponentInChildren<WheelCollider>().sidewaysFriction = sideways;
		}
		kart.enabled = false;
	}

	//Set values to normal state when player does not drifting
	private void SetNormalValues()
	{
		drifting = false;
		foreach (Transform wc in kart.Wheels)
		{
			WheelFrictionCurve sideways = new WheelFrictionCurve();
			sideways.extremumSlip = 0.2f;
			sideways.extremumValue = 1f;
			sideways.asymptoteSlip = 0.5f;
			sideways.asymptoteValue = 0.75f;
			sideways.stiffness = 0f;
			wc.GetComponentInChildren<WheelCollider>().sidewaysFriction = sideways;
		}
		kart.enabled = true;
	}
}
