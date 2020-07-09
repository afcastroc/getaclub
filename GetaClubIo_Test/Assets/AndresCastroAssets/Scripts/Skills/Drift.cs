using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drift : MonoBehaviour
{
	public ArcadeKart kart;
	private bool drifting = false;

	[Header("Drift")]
	public float extremumSlip = 0f;
	public float extremumValue = 0f;
	public float AsymSlip = 0f;
	public float AsymValue = 0f;
	public float Stiffness = 0f;

	private void Update()
	{
		if (Input.GetAxis("Horizontal") != 0f && Input.GetKey(KeyCode.Space) && !drifting)
		{
			drifting = true;
			foreach (Transform wc in kart.Wheels)
			{
				WheelFrictionCurve sideways = new WheelFrictionCurve();
				sideways.extremumSlip = extremumSlip;
				sideways.extremumValue = extremumValue;
				sideways.asymptoteSlip = AsymSlip;
				sideways.asymptoteValue = AsymValue;
				sideways.stiffness = Stiffness;
				wc.GetComponentInChildren<WheelCollider>().sidewaysFriction = sideways;
			}
			kart.enabled = false;
		}
		else if (drifting && !Input.GetKey(KeyCode.Space))
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
}
