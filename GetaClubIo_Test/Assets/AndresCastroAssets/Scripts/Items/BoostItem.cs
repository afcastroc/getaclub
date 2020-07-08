using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostItem : Item
{
	public float topSpeedToAdd = 0f;
	public float accelerationToAdd = 0f;

	//Check if collide with player and active the boost
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == GameConst.PLAYER_TAG)
		{
			ArcadeKart kart = other.GetComponentInParent<ArcadeKart>();
			float lastTopSpeed = kart.baseStats.TopSpeed;
			float lastacceleration = kart.baseStats.Acceleration;

			kart.baseStats.TopSpeed += topSpeedToAdd;
			kart.baseStats.Acceleration += accelerationToAdd;
			StartCoroutine(EffectDuration(kart, lastTopSpeed, lastacceleration));
		}
	}

	//Duration of the effect
	IEnumerator EffectDuration(ArcadeKart kart, float lastTop, float lastAcceleration)
	{
		yield return new WaitForSeconds(durationTime);
		kart.baseStats.TopSpeed = lastTop;
		kart.baseStats.Acceleration = lastAcceleration;
	}
}
